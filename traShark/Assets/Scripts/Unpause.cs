using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CircleCollider2D))]
public class Unpause : MonoBehaviour
{
    private GameObject gc;
    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");
        GetComponent<CircleCollider2D>().isTrigger = true;    
    }
    private void OnMouseDown()
    {
        gc.GetComponent<UIManagerScript>().pauseControl();
    }
}