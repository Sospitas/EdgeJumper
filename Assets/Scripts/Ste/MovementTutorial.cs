using UnityEngine;
using System.Collections;
//Steven Brown 
public class MovementTutorial : MonoBehaviour 
{
	public GUISkin guiskin;
	public float buttonWidth;
	public float buttonHeight;
	
	
	private Vector3 scale;
	private float originalWidth = 1920;
	private float originalHeight = 1080;
	
	private bool moveRight, moveLeft = false;
	private bool onMobile;
	
	void Start()
	{
		useGUILayout = false;
		
		if(Application.platform == RuntimePlatform.Android)
		{
			onMobile = true;
		}
		else if(Application.platform == RuntimePlatform.IPhonePlayer)
		{
			onMobile = true;
			originalWidth = 2048;
			originalHeight = 1536;
		}
	}
	void OnTriggerStay()
	{
		if(this.tag == "MoveRight")
		{
			moveRight = true;
		}
		else if(this.tag == "MoveLeft")
		{
			moveLeft = true;	
		}
	}
	
	void OnTriggerExit()
	{
		if(this.tag == "MoveRight")
		{
			moveRight = false;
		}
		else if(this.tag == "MoveLeft")
		{
			moveLeft = false;	
		}
	}
	
	void OnGUI()
	{

		GUI.skin = guiskin;
			
		scale.x = Screen.width/originalWidth;
		scale.y = Screen.height/originalHeight;
		scale.z = 1;
		
		// Save the original matrix
		Matrix4x4 originalMatrix = GUI.matrix;
		
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
		if(onMobile)
		{
			if(moveLeft)
			{
				GUI.Label(new Rect( originalWidth/2 - buttonWidth/2, originalHeight * 0.01f, buttonWidth, buttonHeight), 
					"Touch < to move left");
			}
			else if(moveRight)
			{
				GUI.Label(new Rect( originalWidth/2 - buttonWidth/2, originalHeight * 0.01f, buttonWidth, buttonHeight), 
					"Touch > to move right");
			}
		}
		else 
		{
			if(moveLeft)
			{
				GUI.Label(new Rect( originalWidth/2 - buttonWidth/2, originalHeight * 0.01f, buttonWidth, buttonHeight), 
					"Press 'a' to move left");
			}
			else if(moveRight)
			{
				GUI.Label(new Rect( originalWidth/2 - buttonWidth/2, originalHeight * 0.01f, buttonWidth, buttonHeight), 
					"Press 'd' to move right");
			}
		}
		GUI.matrix = originalMatrix;
	}
	
}
