using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This function is an example Interact() script. It's a placeholder to ensure objects are interactable.
//This script's only purpose is to change the sprite of the interactable object.

//This ensures the SpriteRenderer of the object is operational so that no errors are thrown.
[RequireComponent(typeof(SpriteRenderer))]
public class changeSpriteUponInteraction : Interactable
{
    //state of the object after interaction
    public Sprite open;
    //initial state of the object
    public Sprite closed;
    private SpriteRenderer sr;
    //variable used to check the state of the object
    private bool isOpen;

    //This invokes the Interact() function that it inherits from the Interactable class. The if statement makes it a toggle.
    public override void Interact()
    {
        if(isOpen)
            sr.sprite = closed;
        else
            sr.sprite= open;

        isOpen = !isOpen;
    }

    //This insures that the object, when invoked, starts with the initial sprite "closed".
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closed;
    }

}
