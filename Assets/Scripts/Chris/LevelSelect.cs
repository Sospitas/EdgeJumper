using UnityEngine;
using System.Collections;

enum LevelsPage
{
	LEVELS_FIRST = 0,
	LEVELS_SECOND,
	LEVELS_THIRD,
	LEVELS_FOURTH,
	NUM_LEVELS_PAGES,
}

public class LevelSelect : MonoBehaviour
{
	public GUISkin guiskin;
	public float buttonWidth;
	public float buttonHeight;
	public AudioClip buttonClick;
	
	private Vector3 scale;
	private float originalWidth = 1920;
	private float originalHeight = 1080;
	
	private LevelsPage levels = LevelsPage.LEVELS_FIRST;
	
	void Start()
	{
		if(Application.platform == RuntimePlatform.IPhonePlayer)
		{
			originalWidth = 1024;
			originalHeight = 768;
		}
	}
	
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
		if(levels == LevelsPage.LEVELS_FIRST)
		{
			if(GUI.Button(new Rect(originalWidth * 0.25f - buttonWidth/2, originalHeight * 0.33f, buttonWidth, buttonHeight), "Level 1"))
			{
				//audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("Level1");
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.50f - buttonWidth/2, originalHeight * 0.33f, buttonWidth, buttonHeight), "Level 2"))
			{
				//audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("Level2");
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.75f - buttonWidth/2, originalHeight * 0.33f, buttonWidth, buttonHeight), "Level 3"))
			{
				//audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("Level3");
			}
			
			GUI.Button(new Rect(originalWidth * 0.25f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Previous");
			
			if(GUI.Button (new Rect(originalWidth * 0.50f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Main Menu"))
			{
				//audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("MainMenu");
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.75f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Next"))
			{
				//audio.PlayOneShot(buttonClick);
				// Show second set of levels
				levels = LevelsPage.LEVELS_SECOND;
			}
		}
		
		// SECOND Level Selection Buttons
		if(levels == LevelsPage.LEVELS_SECOND)
		{
			if(GUI.Button(new Rect(originalWidth * 0.25f - buttonWidth/2, originalHeight * 0.33f, buttonWidth, buttonHeight), "Level 4"))
			{
				//audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("Level4");
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.50f - buttonWidth/2, originalHeight * 0.33f, buttonWidth, buttonHeight), "Level 5"))
			{
				//audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("Level5");
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.75f - buttonWidth/2, originalHeight * 0.33f, buttonWidth, buttonHeight), "Level 6"))
			{
				//audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("Level6");
			}
			
			if(GUI.Button (new Rect(originalWidth * 0.25f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Previous"))
			{
				levels = LevelsPage.LEVELS_FIRST;
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.50f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Main Menu"))
			{
				//audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("MainMenu");
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.75f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Next"))
			{
				levels = LevelsPage.LEVELS_THIRD;
			}
		}
		
		// THIRD Level Selection Page
		if(levels == LevelsPage.LEVELS_THIRD)
		{
			if(GUI.Button(new Rect(originalWidth * 0.25f - buttonWidth/2, originalHeight * 0.33f, buttonWidth, buttonHeight), "Level 7"))
			{
				Application.LoadLevel("Level7");
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.50f - buttonWidth/2, originalHeight * 0.33f, buttonWidth, buttonHeight), "Level 8"))
			{
				//audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("Level8");
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.75f - buttonWidth/2, originalHeight * 0.33f, buttonWidth, buttonHeight), "Level 9"))
			{
				//audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("Level9");
			}
			
			if(GUI.Button (new Rect(originalWidth * 0.25f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Previous"))
			{
				levels = LevelsPage.LEVELS_SECOND;
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.50f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Main Menu"))
			{
				//audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("MainMenu");
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.75f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Next"))
			{
				levels = LevelsPage.LEVELS_FOURTH;
			}
		}
		
		// FOURTH Level Selection Page
		if(levels == LevelsPage.LEVELS_FOURTH)
		{
			if(GUI.Button(new Rect(originalWidth * 0.25f - buttonWidth/2, originalHeight * 0.33f, buttonWidth, buttonHeight), "Level 10"))
			{
				Application.LoadLevel("Level10");
			}
			
			if(GUI.Button (new Rect(originalWidth * 0.25f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Previous"))
			{
				levels = LevelsPage.LEVELS_THIRD;
			}
			
			if(GUI.Button(new Rect(originalWidth * 0.50f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Main Menu"))
			{
				//audio.PlayOneShot(buttonClick);
				Application.LoadLevel ("MainMenu");
			}
			
			GUI.Button(new Rect(originalWidth * 0.75f - buttonWidth/2, originalHeight * 0.66f, buttonWidth, buttonHeight), "Next");
		}
		
		GUI.matrix = originalMatrix;
	}
}
