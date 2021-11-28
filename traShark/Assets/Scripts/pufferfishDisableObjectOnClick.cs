using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class pufferfishDisableObjectOnClick : MonoBehaviour
{
    private void Start()
    {
        GetComponent<PolygonCollider2D>().isTrigger = true;    
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
