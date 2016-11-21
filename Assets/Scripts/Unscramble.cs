using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Unscramble : MonoBehaviour {
	
	private static Unscramble instance;

	// static property of a GameManager 
	public static Unscramble Instance {
		get { // an instance getter
			if (instance == null) {
//				instance = GameObject.FindGameObjectWithTag ("Unscramble");
			}
			return instance;
		}
	}



	public void displayHint () {
		SceneManager.LoadScene ("Unscramble4");
	}


}
