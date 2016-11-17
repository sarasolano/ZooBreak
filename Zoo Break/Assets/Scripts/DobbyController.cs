using UnityEngine;
using System.Collections;

public class DobbyController : MonoBehaviour {

	public float maxSpeed;
	bool right = true;
	Animator anim;
	Rigidbody2D rb;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//make the character move 
		float move = Input.GetAxis ("Horizontal");

		Debug.Log (move);
		anim.SetFloat("Speed", Mathf.Abs(move));

		rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);

		//check which direction the character is facing
		if (move > 0 && !right) {
			Flip ();
		} else if (move < 0 && right) {
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
