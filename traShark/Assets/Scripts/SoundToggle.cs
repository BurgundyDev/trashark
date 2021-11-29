using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class SoundToggle : MonoBehaviour
{
    public bool mute;
    public Sprite muted;
    public Sprite playing;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if(AudioListener.volume == 0)
        {
            mute = true;
        }
        else if(AudioListener.volume == 1)
        {
            mute = false;
        }
        GetComponent<CircleCollider2D>().isTrigger = true;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mute == false)
        {
            AudioListener.volume = 1;
            spriteRenderer.sprite = playing;
        }
        else if(mute == true)
        {
            AudioListener.volume = 0;
            spriteRenderer.sprite = muted;
        }
    }

    private void OnMouseDown()
    {
        if(mute == false)
        {
            mute = true;
        }
        else if(mute == true)
        {
            mute = false;    
        }
    }
}
