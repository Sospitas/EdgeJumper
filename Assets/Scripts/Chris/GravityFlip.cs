using UnityEngine;
using System.Collections;

public class GravityFlip : MonoBehaviour
{
	public MovementScript moveScript;
	
	public bool flipped = false;
	
	private bool hasMoveScript = false;
	
	private Vector3 groundDir = Vector3.down;
	
	// Use this for initialization
	void Start ()
	{
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
				groundDir = Vector3.up;
				Physics.gravity = new Vector3(0, 9.81f, 0);
			}
			else
			{
				groundDir = Vector3.down;
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
