using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float Lbound;
	public float Rbound;

	private Transform target;


	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}


	// Update is called once per frame
	void LateUpdate () {
		Vector3 velocity = Vector3.zero;
		Vector3 up = target.transform.up * 5.5f;
		Vector3 forward = target.transform.forward * 10.0f;
		Vector3 needPos = target.transform.position - forward + up;
		transform.position = Vector3.SmoothDamp(transform.position, needPos,
			ref velocity,0.05f);
		transform.LookAt (target.transform);
		transform.rotation = target.transform.rotation;


		if (transform.position.x < Lbound) {
			Vector3 temp = transform.position;
			temp.x = Lbound;
			transform.position = temp;
			//Debug.DrawLine(
		}
		if (transform.position.x > Rbound) {
			Vector3 temp = transform.position;
			temp.x = Rbound;
			transform.position = temp;
		}

		//hard bounds up and down
		//not follow character on y
		//test with different resolutions!

	}
	
//	void OnDrawGizmosSelected() {
//
//		// Display the explosion radius when selected
//		Gizmos.color = new Color(1, 1, 0, 0.75F);
//		Gizmos.DrawSphere (Vector3(Lbound, 0, 0), 5.0f);
//	}






//	public GameObject player;
//
//	private Vector3 offset;
//
//	void Start () {
//		offset = transform.position - player.transform.position;
//	}
//
//	void LateUpdate () {
//		transform.position = player.transform.position + offset;
//		transform.LookAt(player.transform);
//
//	}



}
