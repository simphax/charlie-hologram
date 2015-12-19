using UnityEngine;
using System.Collections;

public class CharlieAnimator : MonoBehaviour {

	Animation animation;
	// Use this for initialization
	void Start () {
		animation = gameObject.GetComponent<Animation> ();
		animation.wrapMode = WrapMode.Loop;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("a")) {
			animation.CrossFade ("Idle_Seating");
		}
		if (Input.GetKeyDown ("s")) {
			animation.CrossFade ("Lying Eating");
		}
		if (Input.GetKeyDown ("d")) {
			animation.CrossFade ("Attack_Seating");
		}
		if (Input.GetKeyDown ("f")) {
			animation.CrossFade ("BindPose");
		}
		if (Input.GetKeyDown ("g")) {
			animation.CrossFade ("Idle");
		}
		if (Input.GetKeyDown ("h")) {
			animation.CrossFade ("Start Eating");
		}
		if (Input.GetKeyDown ("j")) {
			animation.CrossFade ("Eating");
		}
		if (Input.GetKeyDown ("k")) {
			animation.CrossFade ("EndEating");
		}
		if (Input.GetKeyDown ("l")) {
			animation.CrossFade ("Meowing");
		}
	}
}
