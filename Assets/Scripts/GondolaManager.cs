using UnityEngine;
using System.Collections.Generic;

public class GondolaManager : MonoBehaviour {

	GameObject rope;
	GameObject gondola;

	private Stack<GameObject> gondolas;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < n / k; i++) {
			SpawnRope ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void CreateGondolas(int n) {
		for (int i = 0; i < n; i++) {
			gondolas.Push (Instantiate (gondola));
		}
	}

	private void SpawnRope() {
		
	}
}
