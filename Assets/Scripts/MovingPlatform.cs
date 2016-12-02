using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public bool right;
	private Vector3 nextPos;

	private Vector3 posA;
	private Vector3 posB;

	public float speed;
	public Transform child;
	public Transform childB;

	void Start() {
		posA = child.localPosition;
		posB = childB.localPosition;
		nextPos = posB;
	}

	void Update() {
		Move ();
	}

	void OnCollisionEnter (Collision col) {
		if(col.gameObject.name == "prop_powerCube")
		{
			Destroy(col.gameObject);
		}
	}

	private void Move(){
		child.localPosition = Vector3.MoveTowards (child.localPosition, nextPos, speed * Time.deltaTime);

		if (Vector3.Distance (child.localPosition, nextPos) <= 0.1) {
			ChangeDest ();
		}
	}

	private void ChangeDest() {
		nextPos = nextPos != posA ? posA : posB;
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
}
