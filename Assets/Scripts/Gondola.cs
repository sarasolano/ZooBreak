using UnityEngine;
using System.Collections;
using System;

// Constructs a Gondola
public class Gondola : MonoBehaviour {
	// the speed of the gondola
	public float speed;

	// updates the movement of the gondola
	void Update() {
		Move ();
	}
		
	void OnCollisionStay2D(Collision2D c) {
		// when gondola collides with the player make player move with it by making it a parent
		if (c.gameObject.CompareTag ("Player")) {
			c.gameObject.transform.parent = transform;
		}
	}

	void OnCollisionExit2D(Collision2D c) {
		// when gondola exits collision with free player
		if (c.gameObject.CompareTag ("Player")) {
			c.gameObject.transform.parent = null;
		}
	}

	// moves the gondola to the right
	private void Move() {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
}
