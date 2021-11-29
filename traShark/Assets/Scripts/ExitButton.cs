using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CircleCollider2D))]
public class ExitButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;    
    }
    private void OnMouseDown()
    {
        Application.Quit();
    }
}