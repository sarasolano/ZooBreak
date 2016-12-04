using UnityEngine;
using System.Collections;

public class LionPatroller : MonoBehaviour {

	private Animator anim;
	private Rigidbody2D rb;

	public float speed;
	private bool right = true;

	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		//the lion is constantly moving
		rb.velocity = new Vector2 (speed, rb.velocity.y);
	}

	void FixedUpdate () {
		//the lion is constantly moving, so the animation is always set to walking
		anim.SetFloat("Speed", 1);
	}

	void OnTriggerEnter2D ( Collider2D other) {
		//lion turns around when it reaches the end of its patrol section 
		if (other.CompareTag ("Edge")) {
			Flip ();
		}
	}

	//flips the lion image and changes its speed so it moves to the opposite direction
	void Flip() {
		right = !right;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
		speed = -speed;
	}
}
