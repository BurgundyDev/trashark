using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMinigame : Interactable
{
    //minigame related to object of this class
    public GameObject minigame;
    //state of the object after being finished with its respective minigame
    public Sprite saved;
    //initial state of the object
    public Sprite trashed;
    private SpriteRenderer sr;
    public bool isSaved;

    //This invokes the Interact() function that it inherits from the Interactable class. The if statement makes it a toggle.
    public override void Interact()
    {
        minigame.SetActive(true);
    }

    //This insures that the object, when invoked, starts with the initial sprite "closed".
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = trashed;
        minigame.SetActive(false);
    }

    private void Update()
    {
        if(isSaved)
        {
            sr.sprite = saved;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(isSaved==false)
        {
            other.GetComponent<PlayerMovementBehaviour>().OpenInteractableIcon();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<PlayerMovementBehaviour>().CloseInteractableIcon();
    }

    public void Saving()
    {
        isSaved = true;
    }
}
