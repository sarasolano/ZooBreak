using UnityEngine;
using System.Collections;
using System;

public class Gondola : MonoBehaviour {
	public float speed;

	private DateTime curr;

	void Start() {
		curr = DateTime.Now;
	}

	void FixedUpdate() {
		DateTime now = DateTime.Now;
		if ((now - curr).TotalSeconds >= 2 && Vector3.Distance (transform.localPosition, Vector3.zero) <= 1.8f) {
			curr = now;
			Move ();
		}
	}

	private void Move() {
		Rope parent = transform.parent.gameObject.GetComponent<Rope>();
		transform.parent = parent.next;
		transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime);
		transform.localPosition = new Vector3 (0, -1.8f, 0);
	}
}
