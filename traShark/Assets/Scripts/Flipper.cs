using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }
}
