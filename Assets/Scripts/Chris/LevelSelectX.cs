using UnityEngine;
using System.Collections;

enum LevelsPageX
{
	LEVELS_FIRST = 0,
	LEVELS_SECOND,
	LEVELS_THIRD,
	NUM_LEVELS_PAGES,
}

public class LevelSelectX : MonoBehaviour
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
	
	private LevelsPageX levels = LevelsPageX.LEVELS_FIRST;
	private int level = 0;
	
	private int levelOffset;
	private int row = 0;
	
	private int numLevelsPages;
	
	void Start()
	{
		useGUILayout = false;
		
		levelOffset = 0;
		
		numLevelsPages = Mathf.CeilToInt(numberOfLevels/9.0f);
		
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
		
		row = 0;
		
		if(GUI.Button (new Rect(originalWidth * centreButtonOffsetX - buttonWidth/2 - 75, 0 + (int)(originalHeight * 0.75f), 300, buttonHeight), "Back"))
		{
			Application.LoadLevel ("MainMenu");
		}
		
		if(level > 0)
		{
			// Previous (does nothing on first page)
			if(GUI.Button (new Rect(originalWidth * 0.4f - buttonWidth/2, 0 + (int)(originalHeight * 0.45f), 100, 100), "<"))
			{
				levelOffset -= 9;
				--level;
				//--levels;
			}
		}
			
//		if(levels < LevelsPageX.NUM_LEVELS_PAGES - 1)
//		{
//			// Next
//			if(GUI.Button (new Rect(originalWidth * 0.8f - buttonWidth/2, 0 + (int)(originalHeight * 0.45f), 100, 100), ">"))
//			{
//				levelOffset += 9;
//				++levels;
//			}
//		}
		
		if(level < numLevelsPages - 1)
		{
			// Next
			if(GUI.Button (new Rect(originalWidth * 0.8f - buttonWidth/2, 0 + (int)(originalHeight * 0.45f), 100, 100), ">"))
			{
				levelOffset += 9;
				++level;
				//++levels;
			}
		}
		
		float j = 0;
		
		for(int i = levelOffset + 1; i <= levelOffset + 9; i++)
		{
			if(i <= numberOfLevels)
			{
				if(i % 3 == 1)
				{
					row += 1;
					j = 0;
				}
				
				float additiveX = -0.1f + (j * 0.1f);
				float additiveY = -0.15f + ((row - 1) * 0.15f);
				
				switch(row)
				{
				case 1:
					GUI.enabled = PlayerPrefsX.GetBool(i.ToString());
					if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX + additiveX) - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY + additiveY)), buttonWidth, buttonHeight), i.ToString()))
					{
						Application.LoadLevel ("Level" + i.ToString());
					}
					break;
				case 2:
					GUI.enabled = PlayerPrefsX.GetBool(i.ToString());
					if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX + additiveX) - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY + additiveY)), buttonWidth, buttonHeight), i.ToString()))
					{
						Application.LoadLevel ("Level" + i.ToString());
					}
					break;
				case 3:
					GUI.enabled = PlayerPrefsX.GetBool(i.ToString());
					if(GUI.Button (new Rect(originalWidth * (centreButtonOffsetX + additiveX) - buttonWidth/2, 0 + (int)(originalHeight * (centreButtonOffsetY + additiveY)), buttonWidth, buttonHeight), i.ToString()))
					{
						Application.LoadLevel ("Level" + i.ToString());
					}
					break;
				default:
					break;
				}
				j++;
			}
		}
		
		GUI.enabled = true;
		
		GUI.matrix = originalMatrix;
	}
}
