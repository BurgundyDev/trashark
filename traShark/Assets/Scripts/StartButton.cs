using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CircleCollider2D))]
public class StartButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;    
    }
    private void OnMouseDown()
    {
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }
}