using UnityEngine;
using System.Collections;

public class LionFollow : MonoBehaviour {

	public GameObject Target { get; set; }

	public float speed;
	private bool right = true;

	private Animator anim;
	private Rigidbody2D rb;

	private float idleTimer;
	private float idleCoolDown = 2;


	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () {

		LookAtTarget ();

		idleTimer += Time.deltaTime;
		//if player is in the lion's sight, then it follows the player  
		if (Target != null) {
			rb.velocity = new Vector2 (speed, rb.velocity.y);
			anim.SetBool("Follow", true);
		} 
		// if the player is not in the lion's sight, then it is idle
		else if (idleTimer >= idleCoolDown) { 
			idleTimer = 0;
			anim.SetBool("Follow", false);
			rb.velocity = new Vector2 (0, rb.velocity.y);
		} 

	}

	void LookAtTarget() {
		if (Target != null) {
			//calculate if player is to the right or left of the lion 
			float xDir = Target.transform.position.x - transform.position.x;
			if (xDir < 0 && right || xDir > 0 && !right) {
				Flip ();
			}
		}
	}

	void Flip() {
		right = !right;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
		speed = -speed;
	}
}
