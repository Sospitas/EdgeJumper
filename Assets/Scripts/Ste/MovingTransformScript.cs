using UnityEngine;
using System.Collections;

public class MovingTransformScript : MonoBehaviour 
{
	
	public Vector3 moveAmount;
	//Default moveSpeed = 1
	public float moveSpeed;
	public bool moveLeft, pingPong;
	public float movePause;
	public float startTimeDelay;
	private Vector3 moveTo;
	private Vector3 originalPos;
	private float nextCall;
	private bool reset;
	
	
	
	
	// Use this for initialization
	void Start () 
	{
		nextCall = 0.0f;
		
		originalPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		if(moveLeft)
		{
			moveTo = new Vector3(this.transform.position.x + moveAmount[0], this.transform.position.y + moveAmount[1], this.transform.position.z); 	
		}
		else 
		{
			moveTo = new Vector3(originalPos.x - moveAmount[0], originalPos.y - moveAmount[1] , this.transform.position.z); 
		}
		
	}
	
	// Update is called once per frame
	void Update () 
	{	
		
		if(Time.time > nextCall && Time.time > startTimeDelay)
		{
			if(pingPong)
			{
				pingPongObject();
			}
			else 
			{
				moveAndReset();	
			}
		}
	}
	
	//This will 'ping pong' the object betweek it's origin and the target then back to the origin - the target.
	void pingPongObject()
	{
		if(moveLeft)
		{	
			this.transform.position = Vector3.MoveTowards(this.transform.position, moveTo, Time.deltaTime * moveSpeed);
			if(this.transform.position == moveTo)
			{
				moveLeft = false;
				moveTo = new Vector3(originalPos.x - moveAmount[0], originalPos.y - moveAmount[1], this.transform.position.z); 
				nextCall = Time.time + movePause;
			}
		}
		else 
		{	
			this.transform.position = Vector3.MoveTowards(this.transform.position, moveTo, Time.deltaTime * moveSpeed);
			if(this.transform.position == moveTo)
			{
				moveLeft = true;
				moveTo = new Vector3(originalPos.x + moveAmount[0], originalPos.y + moveAmount[1], this.transform.position.z);
				nextCall = Time.time + movePause;
			}
		}
	}
	
	
	//This will move to the position set in the inspector panel and then immediately move back to the original position.
	void moveAndReset()
	{
		if(!reset)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, moveTo, Time.deltaTime * moveSpeed);
			if(this.transform.position == moveTo)
			{
				reset = true;
			}
		}
		else 
		{
			this.transform.position = originalPos;
			reset = false;
		}
	}
	
}
