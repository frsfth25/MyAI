using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Manager : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log ("spacedown");
			anim.SetInteger ("State", 1);

		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			Debug.Log ("spaceup");
			anim.SetInteger ("State", 0);
		}

	}
}
