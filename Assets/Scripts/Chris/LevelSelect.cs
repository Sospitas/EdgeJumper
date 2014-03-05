// Superceded by LevelSelectX.
// Keeping the script just in case.

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
	public int numberOfLevels;
	
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
			GUI.enabled = PlayerPrefsX.GetBool("1");
			if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX - 0.1f) - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY - 0.15f)), buttonWidth, buttonHeight), "1"))
			{
				Application.LoadLevel ("Level1");
			}
			
			GUI.enabled = PlayerPrefsX.GetBool("2");
			if(GUI.Button (new Rect(originalWidth * centreButtonOffsetX - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY - 0.15f)), buttonWidth, buttonHeight), "2"))
			{
				Application.LoadLevel ("Level2");
			}
			
			GUI.enabled = PlayerPrefsX.GetBool("3");
			if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX + 0.1f) - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY - 0.15f)), buttonWidth, buttonHeight), "3"))
			{
				Application.LoadLevel ("Level3");
			}
			
			GUI.enabled = PlayerPrefsX.GetBool("4");
			if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX - 0.1f) - buttonWidth/2, 0 + (int)(originalHeight * centreButtonOffsetY), buttonWidth, buttonHeight), "4"))
			{
				Application.LoadLevel ("Level4");
			}
			
			GUI.enabled = PlayerPrefsX.GetBool("5");
			if(GUI.Button (new Rect(originalWidth * centreButtonOffsetX - buttonWidth/2, 0 + (int)(originalHeight * centreButtonOffsetY), buttonWidth, buttonHeight), "5"))
			{
				Application.LoadLevel ("Level5");
			}
			
			GUI.enabled = PlayerPrefsX.GetBool("6");
			if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX + 0.1f) - buttonWidth/2, 0 + (int)(originalHeight * centreButtonOffsetY), buttonWidth, buttonHeight), "6"))
			{
				Application.LoadLevel ("Level6");
			}
			
			GUI.enabled = PlayerPrefsX.GetBool("7");
			if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX - 0.1f) - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY + 0.15f)), buttonWidth, buttonHeight), "7"))
			{
				Application.LoadLevel ("Level7");
			}
			
			GUI.enabled = PlayerPrefsX.GetBool("8");
			if(GUI.Button (new Rect(originalWidth * centreButtonOffsetX - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY + 0.15f)), buttonWidth, buttonHeight), "8"))
			{
				Application.LoadLevel ("Level8");
			}
			
			GUI.enabled = PlayerPrefsX.GetBool("9");
			if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX + 0.1f) - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY + 0.15f)), buttonWidth, buttonHeight), "9"))
			{
				Application.LoadLevel ("Level9");
			}
		}
		else if(levels == LevelsPage.LEVELS_SECOND)
		{
			GUI.enabled = PlayerPrefsX.GetBool("10");
			if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX - 0.1f) - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY - 0.15f)), buttonWidth, buttonHeight), "10"))
			{
				Application.LoadLevel ("Level10");
			}
			
			GUI.enabled = PlayerPrefsX.GetBool("11");
			if(GUI.Button (new Rect(originalWidth * centreButtonOffsetX - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY - 0.15f)), buttonWidth, buttonHeight), "11"))
			{
				Application.LoadLevel ("Level11");
			}
			
			GUI.enabled = PlayerPrefsX.GetBool("12");
			if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX + 0.1f) - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY - 0.15f)), buttonWidth, buttonHeight), "12"))
			{
				Application.LoadLevel ("Level12");
			}
			
			GUI.enabled = PlayerPrefsX.GetBool("13");
			if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX - 0.1f) - buttonWidth/2, 0 + (int)(originalHeight * centreButtonOffsetY), buttonWidth, buttonHeight), "13"))
			{
				Application.LoadLevel ("Level13");
			}
			
			GUI.enabled = PlayerPrefsX.GetBool("14");
			if(GUI.Button (new Rect(originalWidth * centreButtonOffsetX - buttonWidth/2, 0 + (int)(originalHeight * centreButtonOffsetY), buttonWidth, buttonHeight), "14"))
			{
				Application.LoadLevel ("Level14");
			}
			
			GUI.enabled = PlayerPrefsX.GetBool("15");
			if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX + 0.1f) - buttonWidth/2, 0 + (int)(originalHeight * centreButtonOffsetY), buttonWidth, buttonHeight), "15"))
			{
				Application.LoadLevel ("Level15");
			}
			
			GUI.enabled = PlayerPrefsX.GetBool("16");
			if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX - 0.1f) - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY + 0.15f)), buttonWidth, buttonHeight), "16"))
			{
				Application.LoadLevel ("Level16");
			}
		}
		
		GUI.enabled = true;
		
		GUI.matrix = originalMatrix;
	}
}
