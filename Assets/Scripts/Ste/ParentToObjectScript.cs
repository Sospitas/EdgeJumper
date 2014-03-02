using UnityEngine;
using System.Collections;

public class ParentToObjectScript : MonoBehaviour 
{
	public GravityFlip gravScript;
	RaycastHit hit;
	Vector3 rayCastFromLeft, rayCastFromRight;
	private float rayDist;
	
	void Start()
	{
		rayDist	= transform.position.y + transform.collider.bounds.extents.y;	
	}
	// Update is called once per frame
	void Update () 
	{
		//If the gravity has flipped - the y
		rayCastFromLeft = new Vector3(this.transform.position.x - this.transform.collider.bounds.extents.x - 0.1f, 
			this.transform.position.y, this.transform.position.z);	
		rayCastFromRight = new Vector3(this.transform.position.x + this.transform.collider.bounds.extents.x + 0.1f,
			this.transform.position.y, this.transform.position.z);	
		ParentToMovableObj();
		//Debug.DrawRay(rayCastFromLeft, Physics.gravity.normalized, Color.red);
		Debug.DrawLine(rayCastFromLeft, new Vector3(rayCastFromLeft.x, rayCastFromLeft.y + rayDist, rayCastFromLeft.z));
	}
	
	void ParentToMovableObj()
	{
		//Check the rightside 
		if(Physics.Raycast(rayCastFromLeft, Physics.gravity.normalized, out hit, rayDist + 0.1f))
		{
			if(hit.transform.tag == "Movable")
			{
				Debug.Log("Parented");
				this.transform.parent = hit.collider.transform;
			}	
		}//Check the left side
		else if(Physics.Raycast(rayCastFromRight, Physics.gravity.normalized, out hit, rayDist + 0.1f))
		{
			if(hit.transform.tag == "Movable")
			{
				this.transform.parent = hit.collider.transform;
			}
		}
		else 
		{
			this.transform.parent = null;	
		}
	}
}
