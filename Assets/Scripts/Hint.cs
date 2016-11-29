using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hint : MonoBehaviour {

	private KeyValuePair<string, string> word;
	private UnscrambleManager manager;

	void OnCollisionEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			showHint ();
		}
	}

	private void showHint() {
		
	}
}
