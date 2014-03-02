using UnityEngine;
using System.Collections;

public class FollowTrackPointsScript : MonoBehaviour 
{
	public GameObject[] trackPoints;
	
	public float startTimeDelay, movePause;
	
	public float horSpeed, vertSpeed;
	private int currTrackPoint;
	private float nextCall;
	private bool xEqual, yEqual;
	
	private bool rotateOverTime = false;
	private Vector3 targetPos;
	
	private Quaternion targetRot;
	// Use this for initialization
	void Start () 
	{
		nextCall = 0.0f;
		xEqual = yEqual = false;
		currTrackPoint = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{		
		if(Time.time > nextCall && Time.time > startTimeDelay)
		{
			//Debug.Log("Current Track Point: " +currTrackPoint);
			//Debug.Log("YEqual: " + yEqual);
			//Debug.Log("XEqual: " + xEqual);
			MoveToNextTrackPoint();
		}
		else
		{
			//this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRot, 0.025f);
		}
	}
	
	void MoveToNextTrackPoint()
	{
		rotateOverTime = false;
		
		if(currTrackPoint < trackPoints.Length)
		{
			if(this.transform.position.x != trackPoints[currTrackPoint].transform.position.x)
			{
				Vector3 moveToX = new Vector3(trackPoints[currTrackPoint].transform.position.x, 0.0f, 0.0f);
				Vector3 moveFromX = new Vector3(this.transform.position.x, 0.0f, 0.0f);
				Vector3 newXPos = Vector3.MoveTowards(moveFromX, moveToX, Time.deltaTime * vertSpeed);
				this.transform.position = new Vector3(newXPos.x, this.transform.position.y, this.transform.position.z);
			}
			else 
			{
				xEqual = true;	
			}
			
			if(this.transform.position.y != trackPoints[currTrackPoint].transform.position.y)
			{
				Vector3 moveToY = new Vector3(0.0f, trackPoints[currTrackPoint].transform.position.y, 0.0f);
				Vector3 moveFromY = new Vector3(0.0f, this.transform.position.y, 0.0f);
				Vector3 newYPos = Vector3.MoveTowards(moveFromY, moveToY, Time.deltaTime * horSpeed);
				this.transform.position = new Vector3(this.transform.position.x, newYPos.y, this.transform.position.z);
			}
			else
			{
				yEqual = true;	
			}
			
			if(xEqual && yEqual)
			{
				currTrackPoint++;
				nextCall = Time.time + movePause;
				
				targetRot = Quaternion.Euler (this.transform.rotation.eulerAngles + new Vector3(0, 0, 90));
				
				xEqual = yEqual = false;
				rotateOverTime = true;
			}	
		}
		else 
		{
			currTrackPoint = 0;	
		}
	}
}