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

	Animator boss1Animator;

	//bool movingMode = false;
	bool attackMode = false;

	// Use this for initialization
	void Start () 
	{
		//movingMode = true;
		boss1Animator =  GetComponent<Animator> ();

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

	/*	if (GameObject.Find ("firepng(Clone)") == null) {
			Debug.Log ("ADA!");
			boss1Animator.SetInteger ("State", 0);
		} */
	}

	void TimeDown()
	{
		if (!attackMode)
			timer++;
		if (timer % 4 == 0)
		{
			timer = 0;
			attackMode = true;
			boss1Animator.SetInteger ("State", 1);
			Invoke ("SpitFire", 0.5f);//SpitFire ();
		}
	}

	void SpitFire()
	{
		//int fakeTime = timer;

		var cloneBull = Instantiate(bullet,transform.position, Quaternion.identity) as GameObject;
		rb2d = cloneBull.GetComponent<Rigidbody2D> ();
		rb2d.isKinematic = false;
		//GameObject target = GameObject.FindGameObjectWithTag ("Player");
		rb2d.AddForce(new Vector2( launchSpeed, transform.position.y ));
		Destroy (cloneBull, 1.5f);

		//Debug.Log (timer + " " + fakeTime);
		boss1Animator.SetInteger ("State", 0);
		attackMode = false;
	}

	void DestroyFire (GameObject thisOne)
	{
		Destroy (thisOne);
	}
}
