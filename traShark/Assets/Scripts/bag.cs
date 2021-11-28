using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class bag : MonoBehaviour
{
    // The plane the object is currently being dragged on
    private Plane dragPlane;
	private Vector2 boxSize = new Vector2(40f,40f);
    // The difference between where the mouse is on the drag plane and 
    // where the origin of the object is on the drag plane
    private Vector3 offset;
    private int rybka;
    public int followers;
    private Camera myMainCamera; 

    void Start()
    {
        myMainCamera = Camera.main; // Camera.main is expensive ; cache it here
        GetComponent<PolygonCollider2D>().isTrigger = true;
    }

    private void Update()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position,boxSize, 0, Vector2.zero);

		if(hits.Length > 0)
		{
            rybka = 0;

			foreach(RaycastHit2D rc in hits)
			{
				if(rc.transform.GetComponent<axolotlMinigameScript>())
				{
                    rybka =+ 1;
				}
			}

            if(rybka == 0)
            {
                Destroy(gameObject);
            }
		}
    }

    void OnMouseDown()
    {
        dragPlane = new Plane(myMainCamera.transform.forward, transform.position); 
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition); 

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist); 
        offset = transform.position - camRay.GetPoint(planeDist);
    }

    void OnMouseDrag()
    {   
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition); 

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        transform.position = camRay.GetPoint(planeDist) + offset;
    }

    public void Destruction()
    {
        Destroy(gameObject);
    }
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
