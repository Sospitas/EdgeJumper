using UnityEngine;
using System.Collections;


//Steven Brown 
public class MovementScript : MonoBehaviour
{
	//Defaults Variable Values:
	//moveSpeed  = 5
	//maxVel = 18
	//jumpForce = 70
	//moveDampX = 1
	//mobileMovement = 0.35f
	
	public float moveSpeed;
	public float maxVel;
	public float jumpForce;
	public float moveDampX;
	public float mobileMovementVal;
	public Material green, gray;
	
	private float distanceToGround, distanceToSides;
	
	private bool rightMove = false;
	private bool leftMove = false;
	//private bool jump = false;
	
	private bool leftGrounded = false;
	private bool rightGrounded = false;
	
	private bool onMobile = false;
	
	// Use this for initialization
	void Start ()
	{
		Physics.gravity = new Vector3(0, -9.81f, 0);
		if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
		{
			onMobile = true;
		}
		this.rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
		distanceToGround = this.collider.bounds.extents.y;
		distanceToSides = this.collider.bounds.extents.x;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(onMobile == true)
		{
			InputsMobile();
		}
		else
		{
			InputsPC ();
		}
	}
	
	void FixedUpdate()
	{	
		if(Time.timeSinceLevelLoad > 2.0f)
		{
			LimitVelocity();
		}
		Movement();
	}
	
	//Once the players y velocity goes over the max velocity it will be capped to the max velocity.
	void LimitVelocity()
	{
		if(this.rigidbody.velocity.y > (Physics.gravity.y / Physics.gravity.y * maxVel))
		{
			this.rigidbody.velocity = new Vector3(this.rigidbody.velocity.x, maxVel, 0.0f);
		}
		else if(this.rigidbody.velocity.y < (Physics.gravity.y / Physics.gravity.y * -maxVel))
		{
			this.rigidbody.velocity = new Vector3(this.rigidbody.velocity.x, -maxVel, 0.0f);
		}
	}
	
	void InputsPC()
	{
		// Right movement input 
		if(Input.GetKey (KeyCode.D) && !wallSlideRight() || Input.GetKey (KeyCode.RightArrow) && !wallSlideRight())
		{
			leftMove = false;
			rightMove = true;
		}
		// Left movement input 
		else if(Input.GetKey (KeyCode.A) && !wallSlideLeft() || Input.GetKey (KeyCode.LeftArrow) && !wallSlideLeft())
		{
			rightMove = false;
			leftMove = true;
		}
		//No movement input
		else 
		{
			rightMove = leftMove = false;
		}
	}
	
	void InputsMobile()
	{
		// Right movement input 
		if(Input.touches.Length > 0)
		{
			for(int i = 0; i < Input.touchCount; i++)
			{
				//Move Left
				if(Input.GetTouch(i).position.x < (Screen.width * mobileMovementVal) && !wallSlideLeft())
				{
					leftMove = true;
					rightMove = false;
				}
				else if(wallSlideLeft() == true)
				{
					leftMove = false;
				}
				
				// Move Right
				if(Input.GetTouch(i).position.x > Screen.width - (Screen.width * mobileMovementVal) && !wallSlideRight())
				{
					rightMove = true;
					leftMove = false;
				}
				else if(wallSlideRight() == true)
				{
					rightMove = false;
				}
			}
		}
		//No movement input
		else 
		{
			rightMove = leftMove = false;
		}
	}
	
	//This will control the movement due to the inputs.
	void Movement ()
	{
		if(rightMove)
		{
			this.rigidbody.velocity = new Vector3(1.0f * moveSpeed, this.rigidbody.velocity.y, 0);
		}
		else if(leftMove)
		{
			this.rigidbody.velocity = new Vector3(-1.0f * moveSpeed, this.rigidbody.velocity.y, 0);
		}
		else
		{
			this.rigidbody.velocity = Vector3.Lerp(this.rigidbody.velocity, new Vector3(0.0f, this.rigidbody.velocity.y, 0.0f), moveDampX);
		}
	}
	
	//Use a raycast to check if the player is grounded.
	public bool isGrounded(bool gravityFlipped = false)
	{
		if(gravityFlipped == false)
		{
			// Check both left and right edge of player bounds
			if(Physics.Raycast((new Vector3(this.transform.position.x - this.transform.collider.bounds.extents.x/2, 
				this.transform.position.y, this.transform.position.z)), Vector3.down, distanceToGround + 0.1f))
			{
				leftGrounded = true;
			}
			else if(Physics.Raycast((new Vector3(this.transform.position.x + this.transform.collider.bounds.extents.x/2,
				this.transform.position.y, this.transform.position.z)), Vector3.down, distanceToGround + 0.1f))
			{
				rightGrounded = true;
			}
			else
			{
				leftGrounded = false;
				rightGrounded = false;
			}
		}
		else
		{
			// Check both left and right edge of player bounds
			if(Physics.Raycast((new Vector3(this.transform.position.x - this.transform.collider.bounds.extents.x/2, 
				this.transform.position.y, this.transform.position.z)), Vector3.up, distanceToGround + 0.1f))
			{
				leftGrounded = true;
			}
			else if(Physics.Raycast((new Vector3(this.transform.position.x + this.transform.collider.bounds.extents.x/2,
				this.transform.position.y, this.transform.position.z)), Vector3.up, distanceToGround + 0.1f))
			{
				rightGrounded = true;
			}
			else
			{
				leftGrounded = false;
				rightGrounded = false;
			}
		}
		
		if(leftGrounded == true || rightGrounded == true)
		{
			return true;
		}
		return false;
		//return Physics.Raycast(this.transform.position, -Vector3.up, distanceToGround + 0.05f);
	}
	
	//Check if the player is wall sliding on the left side. This will stop the movement Velocity in this 
	//Direction.
	public bool wallSlideLeft()
	{
		if(Physics.Raycast(this.transform.position, Vector3.left, distanceToSides + 0.05f))
		{
			this.rigidbody.velocity = new Vector3(0.0f, this.rigidbody.velocity.y, 0.0f);
			return true;
		}
		else if(Physics.Raycast((new Vector3(this.transform.position.x, this.transform.position.y + this.rigidbody.collider.bounds.extents.y/2, 
			this.transform.position.z)), Vector3.left, distanceToSides + 0.05f))
		{
			this.rigidbody.velocity = new Vector3(0.0f, this.rigidbody.velocity.y, 0.0f);
			return true;
		}
		else if(Physics.Raycast((new Vector3(this.transform.position.x, this.transform.position.y - this.rigidbody.collider.bounds.extents.y/2, 
			this.transform.position.z)), Vector3.left, distanceToSides + 0.05f))
		{
			this.rigidbody.velocity = new Vector3(0.0f, this.rigidbody.velocity.y, 0.0f);
			return true;
		}
		return false;
	}
	
	//Check if the player is wall sliding on the right side. This will stop the movement velocity in this
	//Direction.
	public bool wallSlideRight()
	{
		if(Physics.Raycast(this.transform.position, Vector3.right, distanceToSides + 0.05f))
		{
			this.rigidbody.velocity = new Vector3(0.0f, this.rigidbody.velocity.y, 0.0f);
			return true;	
		}
		else if(Physics.Raycast((new Vector3(this.transform.position.x, this.transform.position.y + this.rigidbody.collider.bounds.extents.y/2, 
			this.transform.position.z)), Vector3.right, distanceToSides + 0.05f))
		{
			this.rigidbody.velocity = new Vector3(0.0f, this.rigidbody.velocity.y, 0.0f);
			return true;
		}
		else if(Physics.Raycast((new Vector3(this.transform.position.x, this.transform.position.y - this.rigidbody.collider.bounds.extents.y/2, 
			this.transform.position.z)), Vector3.right, distanceToSides + 0.05f))
		{
			this.rigidbody.velocity = new Vector3(0.0f, this.rigidbody.velocity.y, 0.0f);
			return true;
		}
		return false;
	}
}
