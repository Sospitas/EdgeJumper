using UnityEngine;
using System.Collections;

public class InitialLevelLock : MonoBehaviour
{
	public bool resetLevelLock = false;
	public bool unlockAllLevels = false;
	public int numberOfLevels;
	// Use this for initialization
	void Start ()
	{
		if(resetLevelLock == true)
		{
			LockAllLevels();
			resetLevelLock = false;
		}
		
		if(unlockAllLevels == true)
		{
			UnlockAllLevels();
			unlockAllLevels = false;
		}
	}
	
	void LockAllLevels()
	{
		for(int i = 1; i <= numberOfLevels; i++)
		{
			PlayerPrefsX.SetBool (i.ToString(), false);
		}
		
		PlayerPrefsX.SetBool ("1", true);
	}
	
	void UnlockAllLevels()
	{
		for(int i = 1; i <= numberOfLevels; i++)
		{
			PlayerPrefsX.SetBool(i.ToString(), true);
		}
	}
}
