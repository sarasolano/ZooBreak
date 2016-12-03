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
		Vector3 tempPos = needPos;
		tempPos.y = 0.0f;
		needPos = tempPos;

		transform.position = Vector3.SmoothDamp(transform.position, needPos,
			ref velocity,0.05f);
		transform.LookAt (target.transform);
		transform.rotation = target.transform.rotation;



		//these provide bounds so that the camera will stop moving
		//to the right or left
		if (transform.position.x < Lbound) {
			Vector3 temp = transform.position;
			temp.x = Lbound;
			transform.position = temp;
		}
		if (transform.position.x > Rbound) {
			Vector3 temp = transform.position;
			temp.x = Rbound;
			transform.position = temp;
		}

	}

}
