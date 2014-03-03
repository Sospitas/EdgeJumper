﻿using UnityEngine;
using System.Collections;

//Steven Brown
public class EndLevelScript : MonoBehaviour 
{
	public string nextLevel;
	
	public GUISkin guiskin;
	public float buttonWidth;
	public float buttonHeight;
	
	public MovementScript moveScript;
	
	private Vector3 scale;
	private float originalWidth = 1920;
	private float originalHeight = 1080;
	
	private bool inTrigger = false;
	private bool onMobile = false;
	
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
		else
		{
			originalWidth = 1920;
			originalHeight = 1080;
		}
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.transform.tag == "Player")
		{
			inTrigger = true;
		}
	}
	
	void OnTriggerStay()
	{
		if(onMobile == false)
		{
			if(Input.GetKey (KeyCode.E))
			{
				PlayerPrefsX.SetBool(nextLevel.Remove(0, 5), true);
				Application.LoadLevel(nextLevel);
			}
		}
		else if(onMobile == true)
		{
			if(Input.touches.Length > 0)
			{
				if(PauseMenu.isPaused == false)
				{
					for(int i = 0; i < Input.touches.Length; i++)
					{
						if(Input.touches[i].position.x > (Screen.width * moveScript.mobileMovementVal) && Input.touches[i].position.x < Screen.width - (Screen.width * moveScript.mobileMovementVal))
						{
							PlayerPrefsX.SetBool(nextLevel.Remove(0, 5), true);
							Application.LoadLevel (nextLevel);
						}
					}	
				}
				
			}
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		if(col.transform.tag == "Player")
		{
			inTrigger = false;
		}
	}
	
	void OnGUI()
	{
		if(PauseMenu.isPaused == false)
		{
			if(inTrigger == true)
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
					GUI.Label (new Rect( originalWidth/2 - buttonWidth/2, originalHeight * 0.1f, buttonWidth, buttonHeight), 
						"Touch The Screen \nTo Continue ");
				}
				else 
				{
					GUI.Label (new Rect( originalWidth/2 - buttonWidth/2, originalHeight * 0.1f, buttonWidth, buttonHeight), 
						"Press 'e' to continue \nto the next level");
				}
				GUI.matrix = originalMatrix;
			}
		}
	}
}
