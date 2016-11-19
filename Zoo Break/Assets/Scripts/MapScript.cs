using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapScript : MonoBehaviour {

	// the back button, which takes you back to the avatar scene
	public Button BackButton;

	 
	void Start () {
		//This initializes the button so that when you click it, you go to the appropriate scene
		BackButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("AvatarScene"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
