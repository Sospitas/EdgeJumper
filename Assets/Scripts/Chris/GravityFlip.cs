using UnityEngine;
using System.Collections;

public class GravityFlip : MonoBehaviour
{
	public MovementScript moveScript;
	
	public bool flipped = false;
	
	private bool hasMoveScript = false;
	
	// Use this for initialization
	void Start ()
	{
		moveScript = GameObject.Find ("PlayerCube").GetComponent<MovementScript>();
		
		if(moveScript != null)
		{
			hasMoveScript = true;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(hasMoveScript == true)
		{
			Inputs ();
			
			if(flipped == true)
			{
				Physics.gravity = new Vector3(0, 9.81f, 0);
			}
			else
			{
				Physics.gravity = new Vector3(0, -9.81f, 0);
			}
		}
	}
	
	void Inputs ()
	{		
		if(Input.GetKeyDown (KeyCode.Space))
		{
			if(moveScript.isGrounded(flipped))
			{
				flipped = !flipped;
			}
		}
		else if(Input.touches.Length > 0)
		{
			for(int i = 0; i < Input.touches.Length; i++)
			{
				if(Input.GetTouch(i).position.x < Screen.width - 200 && Input.GetTouch(i).position.x > 200 && moveScript.isGrounded(flipped))
				{
					flipped = !flipped;
				}
			}
		}	

	}
}
