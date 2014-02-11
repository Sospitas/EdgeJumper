using UnityEngine;
using System.Collections;

enum LevelsPage
{
	LEVELS_FIRST = 0,
	LEVELS_SECOND,
	NUM_LEVELS_PAGES,
}

public class LevelSelect : MonoBehaviour
{
	public GUISkin guiskin;
	public float buttonWidth;
	public float buttonHeight;
	
	public float centreButtonOffsetX;
	public float centreButtonOffsetY;
	
	public float buttonOffset;
	
	public AudioClip buttonClick;
	
	private Vector3 scale;
	private float originalWidth = 1920;
	private float originalHeight = 1080;
	
	private LevelsPage levels = LevelsPage.LEVELS_FIRST;
	
	void Start()
	{
		useGUILayout = false;
		
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
		
		if(GUI.Button (new Rect(originalWidth * centreButtonOffsetX - buttonWidth/2 - 75, 0 + (int)(originalHeight * 0.75f), 300, buttonHeight), "Back"))
		{
			Application.LoadLevel ("MainMenu");
		}
		
		if(levels > 0)
		{
			// Previous (does nothing on first page)
			if(GUI.Button (new Rect(originalWidth * 0.4f - buttonWidth/2, 0 + (int)(originalHeight * 0.45f), 100, 100), "<"))
			{
				--levels;
			}
		}
			
		if(levels < LevelsPage.NUM_LEVELS_PAGES - 1)
		{
			// Next
			if(GUI.Button (new Rect(originalWidth * 0.8f - buttonWidth/2, 0 + (int)(originalHeight * 0.45f), 100, 100), ">"))
			{
				++levels;
			}
		}
		
		if(levels == LevelsPage.LEVELS_FIRST)
		{
			if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX - 0.1f) - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY - 0.15f)), buttonWidth, buttonHeight), "1"))
			{
				Application.LoadLevel ("Level1");
			}
			if(GUI.Button (new Rect(originalWidth * centreButtonOffsetX - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY - 0.15f)), buttonWidth, buttonHeight), "2"))
			{
				Application.LoadLevel ("Level2");
			}
			else if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX + 0.1f) - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY - 0.15f)), buttonWidth, buttonHeight), "3"))
			{
				Application.LoadLevel ("Level3");
			}
			else if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX - 0.1f) - buttonWidth/2, 0 + (int)(originalHeight * centreButtonOffsetY), buttonWidth, buttonHeight), "4"))
			{
				Application.LoadLevel ("Level4");
			}
			else if(GUI.Button (new Rect(originalWidth * centreButtonOffsetX - buttonWidth/2, 0 + (int)(originalHeight * centreButtonOffsetY), buttonWidth, buttonHeight), "5"))
			{
				Application.LoadLevel ("Level5");
			}
			else if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX + 0.1f) - buttonWidth/2, 0 + (int)(originalHeight * centreButtonOffsetY), buttonWidth, buttonHeight), "6"))
			{
				Application.LoadLevel ("Level6");
			}
			else if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX - 0.1f) - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY + 0.15f)), buttonWidth, buttonHeight), "7"))
			{
				Application.LoadLevel ("Level7");
			}
			else if(GUI.Button (new Rect(originalWidth * centreButtonOffsetX - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY + 0.15f)), buttonWidth, buttonHeight), "8"))
			{
				Application.LoadLevel ("Level8");
			}
			else if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX + 0.1f) - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY + 0.15f)), buttonWidth, buttonHeight), "9"))
			{
				Application.LoadLevel ("Level9");
			}
		}
		else if(levels == LevelsPage.LEVELS_SECOND)
		{
			if(GUI.Button (new Rect(originalWidth * centreButtonOffsetX - buttonWidth/2, 0 + (int)(originalHeight * 0.45f), buttonWidth, buttonHeight), "10"))
			{
				Application.LoadLevel ("Level10");
			}
		}
		
		GUI.matrix = originalMatrix;
	}
}
