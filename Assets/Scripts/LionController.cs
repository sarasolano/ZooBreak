using UnityEngine;
using System.Collections;

public class LionController : MonoBehaviour {

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
		//TODO: FIGURE OUT HOW TO SET SPEED WHEN IT'S AUTOMATICALLY MOVING
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat("Speed", 1);

		//check which direction the character is facing
		if (move > 0 && !right) {
			Flip ();
		} else if (move < 0 && right) {
			Flip ();
		}
	}

	void OnTriggerEnter2D ( Collider2D other) {
//		if (other.CompareTag ("Left")) {
//			Flip ();
//		}
//
//		if (other.CompareTag ("Right")) {
//			Flip ();
//		}
			
	}


	void Flip() {
		right = !right;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
