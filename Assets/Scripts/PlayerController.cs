using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

	public float maxSpeed;
	bool right = true;


	bool ground = false;
	public Transform isGround;
	float grRadius = 0.2f;
	public float jumpForce = 200f;
	public LayerMask wiGround;

	Animator anim;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update() {
		if (ground && Input.GetKeyDown (KeyCode.UpArrow)) {
			anim.SetBool ("Ground", false);
			rb.AddForce (new Vector2 (0,jumpForce));
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		//if you fall off the screen
		if (other.CompareTag ("Border")) {
			Debug.Log("you ded start level over");
		}

		if (other.CompareTag ("Lock")) {
			Debug.Log ("collided with lock");
			GameManager.Instance.currHint += 1;
			SceneManager.LoadScene ("Unscramble4");
		}
	
	}

	// Update is called once per frame
	void FixedUpdate () {
		//make the character move 
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs(move));

		//make the character jump
		ground = Physics2D.OverlapCircle (isGround.position, grRadius, wiGround);
		anim.SetBool ("Ground", ground);
		anim.SetFloat ("vSpeed", rb.velocity.y);
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
