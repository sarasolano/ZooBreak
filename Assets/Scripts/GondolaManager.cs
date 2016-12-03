using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

// manager for the gondola spawning
public class GondolaManager : MonoBehaviour {
	private static int N = 50; 
	private static int DELAY = 4;
	private static float OFFSET = -1.8f; // the offet between the rope center and a gondola center
	private int count = 0; // the count of ropes in the scene
	private DateTime curr; // the current time for second counting use

	public GameObject rope; // the rope object
	public GameObject gondola;// the gondola object

	public GameObject currentRope; // the last rope spawned

	public Transform firstRope; // the first rope in the scene

	private static GondolaManager instance; // the instance of the GondolaManager
	public static GondolaManager Instance {
		get { // an instance getter
			if (instance == null) {
				instance = GameObject.FindObjectOfType<GondolaManager> ();
			}
			return instance;
		}
	}
		
	void Start () {
		curr = DateTime.Now; // the time now
		// initialization of ropes and gondolas
		for (int i = 0; i < N; i++) { 
			count++;
			SpawnRope ();

			if (count % 3 == 0) {
				SpawnGondola (currentRope.transform);
			}
		}
		SpawnGondola (firstRope);
	}

	void FixedUpdate () {
		DateTime now = DateTime.Now;
		if ((now - curr).TotalSeconds >= DELAY) { // if the interval has passed
			SpawnGondola (firstRope); // spawn fondola in the first rope

			for (int i = 0; i < N / 10; i++) { // spawn N/10 ropes
				SpawnRope ();
				count++;
			}

			curr = now;
		}
	}

	// spawns a rope object in the scene
	private void SpawnRope() {
		GameObject tmp = Instantiate (rope); 
		tmp.transform.position = currentRope.transform.GetChild (0).position;
		// creates the link between the current and new rope
		currentRope.GetComponent<Rope> ().next = tmp.transform;
		currentRope = tmp;
		currentRope.GetComponent<Rope> ().next = firstRope.transform;
	}

	private void SpawnGondola(Transform parent) {
		GameObject gon = Instantiate (gondola);
		// new location of the gondole minus the offset between its senter and location of the parent
		gon.transform.localPosition = new Vector3 (0,OFFSET,0) + parent.position;
	}
}
