using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private Animator anim;
	private Rigidbody2D rb;

	public float speed;
	private bool left = true;

	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		if (left) {
			rb.velocity = new Vector2 (-speed, rb.velocity.y);
		} else {
			Debug.Log ("moving right");
			rb.velocity = new Vector2 (speed, rb.velocity.y);
		}
	}


	void OnTriggerEnter2D ( Collider2D other) {
		if (other.CompareTag ("Left")) {
			Debug.Log ("bump left");
			Flip ();
		}

		if (other.CompareTag ("Right")) {
			Flip ();
		}
			
	}


	void Flip() {
		left = !left;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
