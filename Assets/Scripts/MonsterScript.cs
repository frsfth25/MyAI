using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour {


	 bool playerInSight;
	float posX;

	// Use this for initialization
	void Start () 
	{
		playerInSight = false;
		posX = gameObject.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerInSight) 
		{
			posX -= 0.1f;
			transform.position = new Vector2 (posX, 0);		
			posX -= 0.1f;
		}

		if (posX < -10)
			Destroy (gameObject);
	}


	void OnTriggerEnter2D(Collider2D other) {
		playerInSight = true;
		//Debug.Log (playerInSight);
	}
}
