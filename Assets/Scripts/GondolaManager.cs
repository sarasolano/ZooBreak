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

	private Stack<GameObject> gondolas;

	[SerializeField]
	private GameObject currentRope;

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

		gondolas = new Stack<GameObject> ();
		for (int i = 0; i < 30; i++) {
			count++;
			SpawnRope ();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		DateTime now = DateTime.Now;
		if ((now - curr).TotalSeconds >= 2) {
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

		if (count % 5 == 0) {
			GameObject gon = Instantiate (gondola);
			gon.transform.parent = currentRope.transform;
			gon.transform.localPosition = Vector3.zero;
			gon.transform.localPosition = new Vector3 (0,-1.8f,0);
		}

		currentRope.GetComponent<Rope> ().next = tmp.transform;
		currentRope = tmp;
		currentRope.GetComponent<Rope> ().next = firstRope.transform;
	}
}
