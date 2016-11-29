using UnityEngine;
using System.Collections;

public class Monkey : MonoBehaviour {


	private Animator anim;

	public GameObject banana;

	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetTrigger ("Throw"); 
	}
	
	void ThrowBanana(){
		//AudioSource.PlayClipAtPoint(laserSound, transform.position);
		Instantiate(banana, transform.position + Vector3.up, Quaternion.identity);
	}

}
