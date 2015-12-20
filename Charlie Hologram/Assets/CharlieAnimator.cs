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
			animation.CrossFade ("Custom");
		}

	}

	void LateUpdate() {
		Transform neck = GameObject.Find ("Cat_Neck_01SHJnt").transform;
		Transform camera = GameObject.Find ("ARCamera").transform;

		Vector3 lookAngle = Quaternion.LookRotation (camera.transform.position).eulerAngles;
		float lookFactor = 1.0f;
		lookAngle = new Vector3 (lookAngle.x * lookFactor, lookAngle.y * lookFactor, lookAngle.z * lookFactor);
		Vector3 neckAngle = new Vector3 (0, 160, 290);

		neck.rotation = Quaternion.Euler(neckAngle + lookAngle);
	}
}
