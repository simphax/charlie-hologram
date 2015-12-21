using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class CheeseSpawner : MonoBehaviour, ITrackableEventHandler {

	public Transform CheeseModel;
	bool tracked = false;
	float spawnTime = 0.0f;

	// Use this for initialization
	void Start () {
		TrackableBehaviour trackableBehaviour = GetComponentInParent<TrackableBehaviour>();
		trackableBehaviour.RegisterTrackableEventHandler (this);
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
		if (!tracked) {
			Transform cheese = this.transform.FindChild ("Cheese(Clone)");
			if (cheese == null) {
				Debug.Log ("Spawning new cheese!");
				spawnTime = Time.time;
				Transform newCheese = GameObject.Instantiate (CheeseModel) as Transform;
				newCheese.parent = this.gameObject.transform;
				newCheese.localPosition = new Vector3 (0, 0.147f, 0.29f);
				newCheese.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
				newCheese.localRotation = Quaternion.identity;

				Renderer cheeseRenderer = newCheese.GetComponent<Renderer> ();
				cheeseRenderer.material.SetInt ("Random Seed", (int)UnityEngine.Random.Range (0, 10000));
				cheeseRenderer.enabled = false;
			} else {
				spawnTime = Time.time;
				cheese.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
			}
		} else {
			Transform cheese = this.transform.FindChild ("Cheese(Clone)");
			if (cheese != null) {
				cheese.localScale = Vector3.Lerp (new Vector3 (0.0f, 0.0f, 0.0f), new Vector3 (0.3f, 0.3f, 0.3f), (Time.time - spawnTime) * 8.0f);
			}
		}
	}
}
