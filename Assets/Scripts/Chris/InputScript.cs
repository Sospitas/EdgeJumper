using UnityEngine;
using System.Collections;

public class InputScript : MonoBehaviour
{	
	private bool hasPauseScript = false;
	
	// Update is called once per frame
	void Update ()
	{
		Inputs ();
	}
	
	void Inputs ()
	{
		if(Input.GetKeyDown (KeyCode.Escape))
		{
			if(PauseMenu.isPaused == false)
			{
				PauseGame ();
			}
			else
			{
				UnpauseGame ();
			}
		}
	}
	
	void PauseGame ()
	{
		Time.timeScale = 0.0f;
		PauseMenu.isPaused = true;
	}
	
	void UnpauseGame ()
	{
		Time.timeScale = 1.0f;
		PauseMenu.isPaused = false;
	}
}
