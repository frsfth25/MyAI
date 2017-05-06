using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Move : MonoBehaviour {

	GameObject player;

	int timer = 0;

	bool aerialMode = true;
	bool groundMode = false;

	bool ascendMode = false;
	bool descendMode = false;

//	int attackTime = 5;

	Transform laser;

	// Use this for initialization
	void Start () {
		laser = transform.GetChild(0);

		InvokeRepeating ("TimeCount", 0f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (timer);
		if (aerialMode == true) {
			player = GameObject.FindGameObjectWithTag ("Player");
			transform.position = Vector2.MoveTowards (transform.position, new Vector2 (player.transform.position.x, transform.position.y), Time.deltaTime * 2.5f);
		}

		if (descendMode == true) {
			transform.position = Vector2.MoveTowards (transform.position, new Vector2 (0, 0), Time.deltaTime * 5f);
			if (transform.position.x == 0 && transform.position.y == 0) {
				aerialMode = false;
				groundMode = true;
				descendMode = false;
				ascendMode = false;
			}
		}

		if (groundMode == true) {
			//tembak - tembak
		}

		if (ascendMode == true) {
			transform.position = Vector2.MoveTowards (transform.position, new Vector2 (0, 4.8f), Time.deltaTime * 5f);
			if (transform.position.x == 0 && transform.position.y == 4.8f) {
				groundMode = false;
				aerialMode = true;
				ascendMode = false;
				descendMode = false;
				resetTime ();
			}
		}
	}

	void TimeCount()
	{
		if (descendMode == true || ascendMode == true)
			freezeTime();
		else
			increaseTime ();

		if (timer == 0) {
			aerialMode = true;
		}
		if (timer == 10) {
			descendMode = true;
		}
		if (timer == 15) {
			ascendMode = true;
		}
		 
		if (timer % 3 == 0 && aerialMode == true) {
			{
				laser.gameObject.SetActive (true);
				
			}
		} else {
			laser.gameObject.SetActive (false);
			laser.SendMessage ("ResetHit");
		}
	}

	void resetTime()
	{
		timer = 0;
	}

	void increaseTime()
	{
		timer++;
	}

	void freezeTime()
	{
		return;//timer = timer;
	}
}
