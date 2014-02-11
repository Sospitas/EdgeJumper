﻿using UnityEngine;
using System.Collections;

//Christopher Stephens
public class GravityTutorial : MonoBehaviour 
{
	public GUISkin guiskin;
	public float buttonWidth;
	public float buttonHeight;
	
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
	}
	
	void OnTriggerStay(Collider col)
	{
		if(col.transform.tag == "Player")
		{
			inTrigger = true;
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
			GUI.skin = guiskin;
				
			scale.x = Screen.width/originalWidth;
			scale.y = Screen.height/originalHeight;
			scale.z = 1;
			
			// Save the original matrix
			Matrix4x4 originalMatrix = GUI.matrix;
			
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
			
			if(onMobile == true)
			{
				if(inTrigger == false)
				{
					GUI.Label(new Rect(originalWidth/2 - buttonWidth/2, originalHeight * 0.1f, buttonWidth, buttonHeight),
						"Tapping the screen \nwhile touching the floor \nwill flip gravity!");	
				}
			}
			else
			{
				if(inTrigger == false)
				{
					GUI.Label(new Rect(originalWidth/2 - buttonWidth/2, originalHeight * 0.1f, buttonWidth, buttonHeight),
						"Pressing space \nwhile touching the floor \nwill flip gravity!");
				}
			}
			
			GUI.matrix = originalMatrix;
		}
	}
}
