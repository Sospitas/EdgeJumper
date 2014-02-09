using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour
{
	public GUISkin guiskin;
	public float buttonWidth;
	public float buttonHeight;
	public AudioClip buttonClick;
	
	private Vector3 scale;
	private float originalWidth = 1920;
	private float originalHeight = 1080;
	
	private bool firstLevels = true;
	
	void OnGUI ()
	{
		GUI.skin = guiskin;
		
		scale.x = Screen.width/originalWidth;
		scale.y = Screen.height/originalHeight;
		scale.z = 1;
		
		// Save the original matrix
		Matrix4x4 originalMatrix = GUI.matrix;
		
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
		
		// First Levels Selection Buttons
		if(firstLevels == true)
		{
			if(GUI.Button(new Rect(originalWidth * 0.25f - buttonWidth/2, originalHeight * 0.33f, buttonWidth, buttonHeight), "Level 1"))
			{
				audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("Level1");
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.50f - buttonWidth/2, originalHeight * 0.33f, buttonWidth, buttonHeight), "Level 2"))
			{
				audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("Level2");
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.75f - buttonWidth/2, originalHeight * 0.33f, buttonWidth, buttonHeight), "Level 3"))
			{
				audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("Level3");
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.25f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Level 4"))
			{
				audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("Level4");
			}
			
			if(GUI.Button (new Rect(originalWidth * 0.50f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Main Menu"))
			{
				audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("MainMenu");
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.75f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Next"))
			{
				audio.PlayOneShot(buttonClick);
				// Show second set of levels
				firstLevels = false;
			}
		}
		
		// Second Level Selection Buttons
		if(firstLevels == false)
		{
			if(GUI.Button(new Rect(originalWidth * 0.25f - buttonWidth/2, originalHeight * 0.33f, buttonWidth, buttonHeight), "Level 5"))
			{
				audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("Level5");
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.50f - buttonWidth/2, originalHeight * 0.33f, buttonWidth, buttonHeight), "Level 6"))
			{
				audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("Level6");
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.75f - buttonWidth/2, originalHeight * 0.33f, buttonWidth, buttonHeight), "Level 7"))
			{
				audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("Level7");
			}
			
			if(GUI.Button (new Rect(originalWidth * 0.25f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Level 8"))
			{
				audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("Level8");
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.50f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Main Menu"))
			{
				audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("MainMenu");
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.75f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Previous"))
			{
				audio.PlayOneShot(buttonClick);
				firstLevels = true;
			}
		}
		
		GUI.matrix = originalMatrix;
	}
}
