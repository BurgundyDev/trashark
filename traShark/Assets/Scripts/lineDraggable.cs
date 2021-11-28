using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class lineDraggable : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private bool isDragging;
    private void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;    
    }
    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }
    public void Destruction()
    {
        Destroy(gameObject);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}