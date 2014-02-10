using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public GUISkin guiskin;
	public float buttonWidth;
	public float buttonHeight;
	
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
		
		if(GUI.Button (new Rect(originalWidth/2 - buttonWidth/2, 0 + (int)(originalHeight * 0.2f), buttonWidth, buttonHeight), "Play"))
		{
			audio.PlayOneShot(buttonClick);
			// Load Game Level
			Application.LoadLevel ("Level1");
		}
		
		if(PlayerPrefs.HasKey ("LastLevel"))
		{
			if(GUI.Button (new Rect(originalWidth/2 - buttonWidth/2, 0 + (int)(originalHeight * 0.4f), buttonWidth, buttonHeight), "Resume"))
			{
				Application.LoadLevel(PlayerPrefs.GetInt("LastLevel"));
			}
		}
		else
		{
			GUI.Button (new Rect(originalWidth/2 - buttonWidth/2, 0 + (int)(originalHeight * 0.4f), buttonWidth, buttonHeight), "Resume");
		}
		
		if(GUI.Button (new Rect(originalWidth/2 - buttonWidth/2, 0 + (int)(originalHeight * 0.6f), buttonWidth, buttonHeight), "Level Select"))
		{
			audio.PlayOneShot(buttonClick);
			// Load Level Select Scene
			Application.LoadLevel ("LevelSelect");
		}
		
		if(GUI.Button (new Rect(originalWidth/2 - buttonWidth/2, 0 + (int)(originalHeight * 0.8), buttonWidth, buttonHeight), "Quit"))
		{
			audio.PlayOneShot(buttonClick);
			// Quit The Game (Only works when actually running
			Application.Quit();
		}
		
		// Reset matrix back to the original
		GUI.matrix = originalMatrix;
	}	
}