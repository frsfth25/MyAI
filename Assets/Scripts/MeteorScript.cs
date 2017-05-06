using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour {

	bool isInSight = false;

	float posX = 0f;
	float posY = 0f;

	float acc = 0.01f;

	// Use this for initialization
	void Start () {
		posX = gameObject.transform.position.x;
		posY = gameObject.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (isInSight) {
			posX -= (0.1f+acc);
			posY -= (0.1f+acc);
			transform.position = new Vector2 (posX, posY);
			if (posY <= 0f)
				Destroy (gameObject,0.25f);
			acc =  acc * 1.25f;
		}
	}

	void OnTriggerEnter2D (Collider2D col2d)
	{
		Debug.Log ("detected");

		if (col2d.gameObject.tag == "Player") {

			isInSight = true;

		}
	}
}
