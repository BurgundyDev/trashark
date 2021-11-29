using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CircleCollider2D))]
public class Leave : MonoBehaviour
{
    private void Start()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
   
    }
    private void OnMouseDown()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}