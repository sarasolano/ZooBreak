using UnityEngine;
using System;
using System.Collections;

public class Rope : MonoBehaviour {

	public Transform next;
	public Transform prev;

	public GameObject gondola;

	public bool gondolaRope;

	public int nextGondola;

	void Start () {
		nextGondola = 0;
		gondolaRope = false;
	}

	public void moveGondola() {
		nextGondola++;
	}
}
