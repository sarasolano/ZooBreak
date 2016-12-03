using UnityEngine;
using System.Collections;

public class LionSight : MonoBehaviour {

	public LionFollow lion;
	private Animator anim;

	void Start(){
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		//set target 
		if (other.tag == "Player") {
			lion.Target = other.gameObject;
		} 
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Player"){
			lion.Target = null;
		}
	}
}
