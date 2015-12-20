﻿using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class CharlieAnimator : MonoBehaviour, ITrackableEventHandler {

	Animation animation;
	bool idle = true;
	bool tracked = false;
	CheeseBehaviour cheese;
	float fatness = 2.0f;

	// Use this for initialization
	void Start () {
		TrackableBehaviour trackableBehaviour = GetComponentInParent<TrackableBehaviour>();
		trackableBehaviour.RegisterTrackableEventHandler (this);
		animation = gameObject.GetComponent<Animation> ();
		animation.wrapMode = WrapMode.Loop;
	}

	public void OnTrackableStateChanged (TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
		if (newStatus == TrackableBehaviour.Status.TRACKED) {
			tracked = true;
		} else {
			tracked = false;
		}
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
			idle = false;
			animation.CrossFade ("Eating");
		}
		if (Input.GetKeyDown ("j")) {
			idle = true;
			animation.CrossFade ("Start Rest");
		}
		if (Input.GetKeyDown ("k")) {
			animation.CrossFade ("Lying Eating");
		}
		if (Input.GetKeyDown ("l")) {
			idle = true;
			animation.CrossFade ("Custom");
		}

	}

	void LateUpdate() {
		if(idle) {
			Transform neck = GameObject.Find ("Cat_Neck_01SHJnt").transform;
			Transform camera = GameObject.Find ("ARCamera").transform;

			Vector3 lookAngle = Quaternion.LookRotation (camera.transform.position).eulerAngles;
			float lookFactor = 1.0f;
			lookAngle = new Vector3 (lookAngle.x * lookFactor, lookAngle.y * lookFactor, lookAngle.z * lookFactor);
			Vector3 neckAngle = new Vector3 (-20, 160, 160+105);

			neck.rotation = Quaternion.Euler(neckAngle + lookAngle);


		}

		Transform head1 = GameObject.Find ("Cat_Head_TopSHJnt").transform;
		Transform head2 = GameObject.Find ("Cat_Head_JawSHJnt").transform;
		Transform spine = GameObject.Find ("Cat_Spine_01SHJnt").transform;
		Transform spine2 = GameObject.Find ("Cat_Spine_02SHJnt").transform;
		Transform spine3 = GameObject.Find ("Cat_Spine_03SHJnt").transform;

		spine.localScale = new Vector3 (1.0f, fatness, 1.0f);
		spine2.localScale = new Vector3 (1.0f, fatness/2.8f, 1.0f);
		spine3.localScale = new Vector3 (1.0f, fatness/2.8f, 1.0f);
		//head2.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
	}

	public void GiveCheese(CheeseBehaviour cheese) {
		if (tracked && idle) {
			Debug.Log ("Charlie has been given cheese!");
			this.cheese = cheese;
			animation.CrossFade ("Attack_Seating");
			StartCoroutine ("TakeCheese");
			idle = false;
		}
	}

	IEnumerator TakeCheese() {
		yield return new WaitForSeconds(0.2f);

		Transform paw = GameObject.Find ("Cat_r_FrontLeg_BallSHJnt").transform;

		float yDistance = Math.Abs (paw.position.y - cheese.transform.position.y);

		//if (yDistance < 8) {
		//	Debug.Log ("Y Distance is still < 8");
			cheese.transform.SetParent (paw);
			cheese.transform.localPosition = new Vector3 (-0.09f, 0.05f, 0);
			cheese.transform.localScale = new Vector3 (0.08f, 0.08f, 0.08f);

			yield return new WaitForSeconds(0.6f);

			animation.CrossFade ("Custom Eating");

			Transform cat = GameObject.Find ("Cat_Lowpoly").transform;
			cheese.transform.SetParent (cat);
			cheese.transform.localPosition = new Vector3 (0f, 0.147f, 1.3f);

			yield return new WaitForSeconds(2.0f);
			Destroy (cheese.gameObject);
			idle = true;
			animation.CrossFade ("Custom");
		//}
	}
}
