using UnityEngine;
using System.Collections;

public class Banana : MonoBehaviour {

	public float speed;
	public float lifeTime;

	void Start(){
		StartCoroutine(KillAfterSeconds(lifeTime));
	}

	void Update () {
		transform.position += Vector3.up * speed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			//then restart level
			Destroy(gameObject);
		}
	}

	IEnumerator KillAfterSeconds(float seconds){
		yield return new WaitForSeconds(seconds);
		Destroy(gameObject);
	}
}
