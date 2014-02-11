using UnityEngine;
using System.Collections;

public class OrientationScript : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad(transform.gameObject);
		
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.orientation = ScreenOrientation.AutoRotation;
	}
}
