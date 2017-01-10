using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		this.SendMessageUpwards ("Detected", col);
	}

	void OnTriggerExit(Collider col)
	{
		this.SendMessageUpwards ("DetectedFalse", col);
	}
}
