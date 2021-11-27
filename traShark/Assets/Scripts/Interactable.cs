using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used to tag objects as Interactable and pass through the Interact() function

//This just ensures that the object does end up possessing the collider.
[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    //This ensures the given BoxCollider2D is a Trigger
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    //This is the abstract function that is later called by other Interactable objects. This is done for compatibility and interoperability.
    public abstract void Interact();

    //This should invoke OpenInteractableIcon from the PlayerMovementBehaviour.cs script, which should disable the TickIcon object, yet it does not do that, at all. I couldn't determine why.
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<PlayerMovementBehaviour>().OpenInteractableIcon();
    }

    //This should invoke CloseInteractableIcon from the PlayerMovementBehaviour.cs script, which should disable the TickIcon object, yet as the previous snippet does not work, we have no idea whether this works.
    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<PlayerMovementBehaviour>().CloseInteractableIcon();
    }
}