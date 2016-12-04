using UnityEngine;
using System.Collections;

// Creates moving platform
public class MovingPlatform : MonoBehaviour {
	// the next position of the player
	private Vector3 nextPos;

	// the positions where to move the player
	private Vector3 posA;
	private Vector3 posB;

	public float speed;
	public Transform child; // platform object
	public Transform childB; // second point (point B)

	// initializes variables
	void Start() {
		posA = child.localPosition;
		posB = childB.localPosition;
		nextPos = posB;
	}

	void Update() {
		Move ();
	}

	private void Move(){
		// moves the player's position
		child.localPosition = Vector3.MoveTowards (child.localPosition, nextPos, speed * Time.deltaTime);

		// if distance between current pos and nextpos is close enough then change dest
		if (Vector3.Distance (child.localPosition, nextPos) <= 0.1) {
			ChangeDest ();
		}
	}

	// changes the destination of the platform
	private void ChangeDest() {
		nextPos = nextPos != posA ? posA : posB;
	}

	void OnCollisionStay2D(Collision2D c) {
		// makes the player move with the platform
		if (c.gameObject.CompareTag ("Player")) {
			c.gameObject.transform.parent = transform;
		}
	}

	void OnCollisionExit2D(Collision2D c) {
		// makes the player stop moving with the platform
		if (c.gameObject.CompareTag ("Player")) {
			c.gameObject.transform.parent = null;
		}
	}
}
