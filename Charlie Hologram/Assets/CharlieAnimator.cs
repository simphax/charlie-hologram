using UnityEngine;
using System.Collections;

public class CharlieAnimator : MonoBehaviour {

	Animation animation;
	bool idle = true;

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
			Vector3 neckAngle = new Vector3 (0, 160, 290);

			neck.rotation = Quaternion.Euler(neckAngle + lookAngle);


			Transform head1 = GameObject.Find ("Cat_Head_TopSHJnt").transform;
			Transform head2 = GameObject.Find ("Cat_Head_JawSHJnt").transform;
			Transform spine = GameObject.Find ("Cat_Spine_01SHJnt").transform;
			Transform spine2 = GameObject.Find ("Cat_Spine_02SHJnt").transform;
			Transform spine3 = GameObject.Find ("Cat_Spine_03SHJnt").transform;

			spine.localScale = new Vector3 (1.0f, 2f, 1.0f);
			spine2.localScale = new Vector3 (1.0f, 0.7f, 1.0f);
			spine3.localScale = new Vector3 (1.0f, 0.7f, 1.0f);
			//head2.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		}
	}
}
