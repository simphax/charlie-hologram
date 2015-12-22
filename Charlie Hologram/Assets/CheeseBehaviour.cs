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
		if (Tracked) {
			Transform cat = GameObject.Find ("Cat_SHJntGrp").transform;
			Vector3 catPosition = cat.position;
			catPosition.y += 10f;
			float distance = Vector3.Distance (catPosition, gameObject.transform.position);
			float zDelta = Math.Abs (cat.position.z - gameObject.transform.position.z);
			float xDelta = Math.Abs (cat.position.x - gameObject.transform.position.x);
			float yDelta = Math.Abs (cat.position.y - gameObject.transform.position.y);

			//Debug.Log (distance);
			/*Debug.Log ("X: " + xDelta);
			Debug.Log ("Y: " + yDelta);
			Debug.Log ("Z: " + zDelta);
			*/
			if (distance < 30 && xDelta < 10 && !eaten) {
				Debug.Log ("Cheese will get eaten!");
				CharlieAnimator charlieAnimator = GameObject.Find ("Cat_Lowpoly").GetComponent<CharlieAnimator>();
				eaten = charlieAnimator.GiveCheese (this);
			}
	 	}
	}
}
