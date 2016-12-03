using UnityEngine;
using System.Collections;
using System;

public class Gondola : MonoBehaviour {
	public float speed;

	void Update() {
		Move ();
	}

	void OnCollisionStay2D(Collision2D c) {
		if (c.gameObject.CompareTag ("Player")) {
			c.gameObject.transform.parent = transform;
		}
	}

	void OnCollisionExit2D(Collision2D c) {
		if (c.gameObject.CompareTag ("Player")) {
			c.gameObject.transform.parent = null;
		}
	}

	private void Move() {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
}
