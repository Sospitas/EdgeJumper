using UnityEngine;
using System.Collections;

public class ParentScript : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
//	void OnTriggerEnter(Collider col)
//	{
//		if(col.transform.tag == "Player")
//		{
//			col.transform.parent = this.transform;			
//		}
//	}
	
	void OnTriggerStay(Collider col)
	{
		if(col.transform.tag == "Player")
		{
			col.transform.parent = this.transform;			
		}	
	}
	
	void OnTriggerExit(Collider col)
	{
		if(col.transform.tag == "Player")
		{
			col.transform.parent = null;
		}
	}
}
