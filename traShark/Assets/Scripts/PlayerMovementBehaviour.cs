using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a general script for controlling Player movement and interaction.

public class PlayerMovementBehaviour : MonoBehaviour
{
	public GameObject interactIcon;

	private Vector2 boxSize = new Vector2(1f,1f);
	// Variables for player's movement
	// Default player's speed applied every time player
	// generate any input signal (like keyboard press)
	public float playerSpeedDefault = 6.0f;
	// The current player's speed
	private float playerSpeedCurrent = 0.0f;
	// Slow down over time
	public float playerDecreaseSpeed = 0.99f;
	// Direction of the last move that we've made
	private Vector3 playerLastDirection = new Vector3();
	// Use List to have multiple input sources for every direction possible
	public List<KeyCode> buttonUp;
	public List<KeyCode> buttonDown;
	public List<KeyCode> buttonLeft;
	public List<KeyCode> buttonRight;
    	// Move the player according to assigned buttons
	void PlayerMove()
	{
		Vector3 thisFrameMove = new Vector3();
		thisFrameMove += CheckMove(buttonUp, Vector3.up);
		thisFrameMove += CheckMove(buttonDown, Vector3.down);
		thisFrameMove += CheckMove(buttonLeft, Vector3.left);
		thisFrameMove += CheckMove(buttonRight, Vector3.right);

		thisFrameMove.Normalize ();

		if(thisFrameMove.magnitude > 0)
		{
			playerSpeedCurrent = playerSpeedDefault;
			playerLastDirection = thisFrameMove;
		}
		else
		{
			playerSpeedCurrent *= playerDecreaseSpeed;
		}
			
		this.transform.Translate(playerLastDirection * Time.deltaTime *
			playerSpeedCurrent, Space.Self);
	}	
	Vector3 CheckMove(List<KeyCode> keyCodeList, Vector3 move)
	{
		foreach (KeyCode element in keyCodeList)
		{
			// Input.GetKey returns true while the user holds down the key
			// identified by 'element'
			if(Input.GetKey(element))
			{
				return move;
			}
		}

		return Vector3.zero;
	}
	
	public void OpenInteractableIcon()
	{
		interactIcon.SetActive(true);
	}
	public void CloseInteractableIcon()
	{
		interactIcon.SetActive(false);
	}
	//Check if player is able to interact with other objects.
	private void CheckInteraction()
	{
		RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position,boxSize, 0, Vector2.zero);

		if(hits.Length > 0)
		{
			foreach(RaycastHit2D rc in hits)
			{
				if(rc.transform.GetComponent<Interactable>())
				{
					rc.transform.GetComponent<Interactable>().Interact();
					return;
				}
			}
		}
	}
    // Start is called before the first frame update
    void Start()
    {
		interactIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

		if(Input.GetKeyDown(KeyCode.E))
			CheckInteraction();
    }
}
