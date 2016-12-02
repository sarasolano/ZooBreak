using UnityEngine;
using System.Collections;

public class LionFollow : MonoBehaviour {

	private Animator anim;
	private Rigidbody2D rb;

	public float speed;
	private bool right = true;

	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if (right) {
			rb.velocity = new Vector2 (speed, rb.velocity.y);
		} else {
			rb.velocity = new Vector2 (-speed, rb.velocity.y);
		}
	}


	void FixedUpdate () {
		anim.SetFloat("Speed", 1);
	}

	void OnTriggerEnter2D ( Collider2D other) {
		if (other.CompareTag ("Edge")) {
			Flip ();
		}
	}


	void Flip() {
		right = !right;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
