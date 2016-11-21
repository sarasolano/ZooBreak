using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour {

	private static GameManager instance;

	// static property of a GameManager 
	public static GameManager Instance {
		get { // an instance getter
			if (instance == null) {
				instance = GameObject.FindObjectOfType<GameManager> ();
			}
			return instance;
		}
	}
		
	//variables keeping track of gamestate
	public int currLevel = 1;
	public int currHint = 0;









}
