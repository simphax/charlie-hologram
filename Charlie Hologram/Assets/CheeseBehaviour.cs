using UnityEngine;
using System.Collections;
using System;
using Vuforia;

public class CheeseBehaviour : MonoBehaviour, ITrackableEventHandler {
	
	bool eaten = false;
	public bool Tracked = false;

	// Use this for initialization
	void Start () {
		TrackableBehaviour trackableBehaviour = GetComponentInParent<TrackableBehaviour>();
		trackableBehaviour.RegisterTrackableEventHandler (this);
	}

	public void OnTrackableStateChanged (TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
		if (newStatus == TrackableBehaviour.Status.TRACKED) {
			Tracked = true;
		} else {
			Tracked = false;
		}
	}

	
	// Update is called once per frame
	void Update () {
		/*if (tracked) {
			Transform cat = GameObject.Find ("Cat_SHJntGrp").transform;
			Vector3 catPosition = cat.position;
			catPosition.y += 0.5f;
			float distance = Vector3.Distance (catPosition, gameObject.transform.position);
			float zDistance = Math.Abs (cat.position.z - gameObject.transform.position.z);
			float xDistance = Math.Abs (cat.position.x - gameObject.transform.position.x);
			float yDistance = Math.Abs (cat.position.y - gameObject.transform.position.y);
			/*
			Debug.Log (distance);
			Debug.Log ("X: " + xDistance);
			Debug.Log ("Y: " + yDistance);
			Debug.Log ("Z: " + zDistance);
			*//*
			if (distance < 27 && !eaten) {
				Debug.Log ("Cheese will get eaten!");
				CharlieAnimator charlieAnimator = GameObject.Find ("Cat_Lowpoly").GetComponent<CharlieAnimator>();
				eaten = charlieAnimator.GiveCheese (this);
			}
	 	}*/
	}
}
