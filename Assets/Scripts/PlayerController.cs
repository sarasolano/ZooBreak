using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

	public float maxSpeed;
	public float jumpForce = 200f;
	public LayerMask wiGround;
	public Transform isGround;

	private Vector3 startPos;
	private GameObject manager; 

	bool right = true;
	bool ground = false;
	float grRadius = 0.2f;

	Animator anim;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		startPos = this.transform.position;
		manager = GameObject.FindGameObjectWithTag ("LevelManager");
	}

	void Update() {
		if (ground && Input.GetKeyDown (KeyCode.UpArrow)) {
			anim.SetBool ("Ground", false);
			rb.AddForce (new Vector2 (0,jumpForce));
		}
	}


	//takes care of what happens if you collide with 
	//an enemy, the hippo's pond, or the bridge pieces
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Enemy")) {
			this.transform.position = startPos;
			manager.GetComponent<IndividualLevelManager> ().SetLoseText ();
		}
		if (other.CompareTag ("Pond")) {
			StartCoroutine(Sinking());
			manager.GetComponent<IndividualLevelManager> ().SetLoseText ();
		}
		if (other.CompareTag ("BridgeHalf")) {
			other.gameObject.SetActive (false);
			GameObject manager = GameObject.FindGameObjectWithTag ("LevelManager");
			manager.GetComponent<IndividualLevelManager>().CollectBridge ();
		}
	
	}


	//this takes care of the sinking if you hit the hippo's pond
	//you return to the starting position after you "die"
	IEnumerator Sinking() {
		yield return new WaitForSeconds(2);
		this.transform.position = startPos;
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
