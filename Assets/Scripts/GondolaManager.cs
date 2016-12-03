using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GondolaManager : MonoBehaviour {
	private int count = 0;
	private float delay = 4;
	private DateTime curr;

	public GameObject rope;
	public GameObject gondola;

	public GameObject currentRope;

	public Transform firstRope;

	private static GondolaManager instance;

	public static GondolaManager Instance {
		get { // an instance getter
			if (instance == null) {
				instance = GameObject.FindObjectOfType<GondolaManager> ();
			}
			return instance;
		}
	}

	// Use this for initialization
	void Start () {
		curr = DateTime.Now;
		for (int i = 0; i < 50; i++) {
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
		if ((now - curr).TotalSeconds >= 4) {
			SpawnGondola (firstRope);

			for (int i = 0; i < 5; i++) {
				SpawnRope ();
				count++;
			}

			curr = now;
		}
	}

	private void SpawnRope() {
		GameObject tmp = Instantiate (rope);
		tmp.transform.position = currentRope.transform.GetChild (0).position;
		currentRope.GetComponent<Rope> ().next = tmp.transform;
		currentRope = tmp;
		currentRope.GetComponent<Rope> ().next = firstRope.transform;
	}

	private void SpawnGondola(Transform parent) {
		GameObject gon = Instantiate (gondola);
		gon.transform.localPosition = new Vector3 (0,-1.8f,0) + parent.position;
	}
}
