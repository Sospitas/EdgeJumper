using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
	public GUISkin guiskin;
	public float buttonWidth;
	public float buttonHeight;
	
	public static bool isPaused = false;
	public AudioClip buttonClick;
	
	private Vector3 scale;
	private float originalWidth = 1920;
	private float originalHeight = 1080;
	
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
		if(isPaused == true)
		{
			GUI.skin = guiskin;
			
			scale.x = Screen.width/originalWidth;
			scale.y = Screen.height/originalHeight;
			scale.z = 1;
			
			// Save the original matrix
			Matrix4x4 originalMatrix = GUI.matrix;
			
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
			
			if(GUI.Button (new Rect( originalWidth/2 - buttonWidth/2, originalHeight * 0.25f, buttonWidth, buttonHeight), "Resume"))
			{
				Time.timeScale = 1.0f;
				isPaused = false;
			}
			
			if(GUI.Button (new Rect( originalWidth/2 - buttonWidth/2, originalHeight * 0.50f, buttonWidth, buttonHeight), "Level Select"))
			{
				Time.timeScale = 1.0f;
				isPaused = false;
				Application.LoadLevel ("LevelSelect");
			}
			
			if(GUI.Button (new Rect( originalWidth/2 - buttonWidth/2, originalHeight * 0.75f, buttonWidth, buttonHeight), "Main Menu"))
			{
				PlayerPrefs.SetInt("LastLevel", Application.loadedLevel);
				PlayerPrefs.Save();
				
				Time.timeScale = 1.0f;
				isPaused = false;
				Application.LoadLevel ("MainMenu");
			}
			
			GUI.matrix = originalMatrix;
		}
	}
}
