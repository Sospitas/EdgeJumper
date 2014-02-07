using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour 
{
	void OnCollisionEnter()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
