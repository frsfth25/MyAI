using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Move : MonoBehaviour {

	public GameObject bullet;

	bool hasBegun = false;

	int timer=0;

	bool moveUp = false;
	bool moveDown = false;

//	float curPosX = 0f;
	float curPosY = 0f;

	private Rigidbody2D rb2d;
	private float launchSpeed = -750f;

	// Use this for initialization
	void Start () 
	{
		curPosY = transform.position.y;
		hasBegun = true;
		if (hasBegun == true)
			moveUp = true;
		InvokeRepeating ("TimeDown", 0.25f, 1f);

		//cloneBull.GetComponent<Rigidbody2D>().AddForce(cloneBull.transform.forward * 5000);
		//Destroy (cloneBull, 2.0f);
	}
	
	void Update()
	{
		if (moveUp == true) {
			if (transform.position.y <= 5f) {
				curPosY += 0.025f;
				transform.position = new Vector2 (transform.position.x, curPosY);
			} else {
				moveUp = false;
				moveDown = true;
			}
		} else if (moveDown == true) {
			if (transform.position.y >= 0f) {
				curPosY -= 0.025f;
				transform.position = new Vector2 (transform.position.x, curPosY);
			} else {
				moveUp = true;
				moveDown = false;
			}
		}
	}

	void TimeDown()
	{
		timer++;

		if (timer % 3 == 0)
			SpitFire ();
	}

	void SpitFire()
	{
		var cloneBull = Instantiate(bullet,transform.position, Quaternion.identity);
		rb2d = cloneBull.GetComponent<Rigidbody2D> ();
		rb2d.isKinematic = false;
		GameObject target = GameObject.FindGameObjectWithTag ("Player");
		rb2d.AddForce(new Vector2( launchSpeed, target.transform.position.y ));
		Destroy (cloneBull, 2.0f);
	}
}
