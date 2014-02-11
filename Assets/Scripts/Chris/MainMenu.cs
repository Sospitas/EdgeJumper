using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public GUISkin guiskin;
	public float buttonWidth;
	public float buttonHeight;
	
	
	// Amount the originalWidth is to be multiplied by
	// (Between 0 and 1)
	public float buttonOffset;
	
	public AudioClip buttonClick;
	
	private Vector3 scale;
	private float originalWidth;
	private float originalHeight;
	
	void Start()
	{
		useGUILayout = false;
		
		if(Application.platform == RuntimePlatform.IPhonePlayer)
		{
			originalWidth = 1024;
			originalHeight = 768;
		}
		else
		{
			originalWidth = 1920;
			originalHeight = 1080;
		};
	}
	
	// GUI
	void OnGUI()
	{
		GUI.skin = guiskin;
		
		scale.x = Screen.width/originalWidth;
		scale.y = Screen.height/originalHeight;
		scale.z = 1;
		
		// Save the original matrix
		Matrix4x4 originalMatrix = GUI.matrix;
		
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
		
		if(GUI.Button (new Rect(originalWidth * buttonOffset - buttonWidth/2, 0 + (int)(originalHeight * 0.35f), buttonWidth, buttonHeight), "Play"))
		{
			audio.PlayOneShot(buttonClick);
			// Load Game Level
			Application.LoadLevel ("Level1");
		}
		
		if(GUI.Button (new Rect(originalWidth * buttonOffset - buttonWidth/2, 0 + (int)(originalHeight * 0.45f), buttonWidth, buttonHeight), "Level Select"))
		{
			audio.PlayOneShot(buttonClick);
			// Load Level Select Scene
			Application.LoadLevel ("LevelSelect");
		}
		
		if(GUI.Button (new Rect(originalWidth * buttonOffset - buttonWidth/2, 0 + (int)(originalHeight * 0.55f), buttonWidth, buttonHeight), "Quit"))
		{
			audio.PlayOneShot(buttonClick);
			// Quit The Game (Only works when actually running
			Application.Quit();
		}
		
		// Reset matrix back to the original
		GUI.matrix = originalMatrix;
	}	
}