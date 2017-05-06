using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHit : MonoBehaviour {

	bool alreadyHit = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col2d)
	{
		//Debug.Log ("Player Hit!");
		if (col2d.gameObject.tag == "Player") {
			if (alreadyHit == false) {
				Debug.Log ("Player Hit!");
				alreadyHit = true;
				
			}
		}
	}

	void ResetHit()
	{
		alreadyHit = false;
	}

}
