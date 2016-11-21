﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

//	// Update is called once per frame
//	void LateUpdate () {
//		Vector3 velocity = Vector3.zero;
//		Vector3 forward = target.transform.forward * 10.0f;
//		Vector3 needPos = target.transform.position - forward;
//		transform.position = Vector3.SmoothDamp(transform.position, needPos,
//			ref velocity,0.05f);
//		transform.LookAt (target.transform);
//		transform.rotation = target.transform.rotation;
//	}


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
	}
	


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
