using UnityEngine;
using System.Collections;

public class Monkey : MonoBehaviour {

	public GameObject bananaPrefab;
	public Transform bananaPos;

	private Animator anim;

	private float throwTimer;
	private float throwCoolDown = 2;
	private bool canThrow = true;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Update(){
		ThrowBanana ();
	}

	//set animation to throw periodically 
	void ThrowBanana(){
		throwTimer += Time.deltaTime;

		if (throwTimer >= throwCoolDown) {
			canThrow = true;
			throwTimer = 0;
		}

		if (canThrow) {
			canThrow = false;
			anim.SetTrigger ("Throw");
		}
	}

	//spawn banana from monkey's hand 
	public void SpawnBanana(){
		Instantiate (bananaPrefab, bananaPos.position, Quaternion.Euler(new Vector3(0, 0 ,300)));

	}
		
}
