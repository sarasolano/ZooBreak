using UnityEngine;
using System.Collections;

//automatically attach a rigidbody 
[RequireComponent(typeof(Rigidbody2D))]

public class Banana : MonoBehaviour {
	//destroy when banana is no longer in camera view 
	void OnBecameInvisible(){
		Destroy (gameObject);
	}
}
		
