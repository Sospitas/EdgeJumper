using UnityEngine;
using System.Collections;

//Steven Brown
public class FallDeathScript : MonoBehaviour 
{
	//Defaults:
	//deathVal 
	public float deathVel;
	
	private bool canDie = false;

	void FixedUpdate()
	{
		checkSpeed();
	}
	
	//Check if the player is falling too fast. If so change the bool.
	void checkSpeed()
	{
		if(this.transform.parent.rigidbody.velocity.y > (Physics.gravity.y / Physics.gravity.y * deathVel) 
			|| this.transform.parent.rigidbody.velocity.y < (Physics.gravity.y / Physics.gravity.y * -deathVel))
		{
			canDie = true;
		}
		else 
		{
			canDie = false;	
		}
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Floor")
		{
			if(canDie)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
