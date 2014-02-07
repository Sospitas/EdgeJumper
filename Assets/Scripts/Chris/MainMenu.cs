using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public GUISkin guiskin;
	public float buttonWidth;
	public float buttonHeight;
	
	public Texture2D menuTexture;
	
	private Vector3 scale;
	private float originalWidth = 1920;
	private float originalHeight = 1080;
	
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
		
		GUI.Label (new Rect(550, 50, 1080, 400), menuTexture);
		
		if(GUI.Button (new Rect(originalWidth/2 - buttonWidth/2, 0 + (int)(originalHeight * 0.4), buttonWidth, buttonHeight), "Play"))
		{
			// Load Game Level
			Application.LoadLevel ("Level1");
		}
		
		if(GUI.Button (new Rect(originalWidth/2 - buttonWidth/2, 0 + (int)(originalHeight * 0.6), buttonWidth, buttonHeight), "Level Select"))
		{
			// Load Level Select Scene
			Application.LoadLevel ("LevelSelect");
		}
		
		if(GUI.Button (new Rect(originalWidth/2 - buttonWidth/2, 0 + (int)(originalHeight * 0.8), buttonWidth, buttonHeight), "Quit"))
		{
			// Quit The Game (Only works when actually running
			Application.Quit();
		}
		
		// Reset matrix back to the original
		GUI.matrix = originalMatrix;
	}	
}