using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class osmiornicaMinigame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.childCount == 0)
        {
            transform.parent.GetComponent<StartMinigame>().Saving();
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<lineDraggable>().Destruction();
    }
}
