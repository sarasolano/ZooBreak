using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryScene2 : MonoBehaviour {

	// the buttons at the bottom of the screen
	public Button BackButton;
	public Button AvatarButton;

	//This initializes the button so that when you click it, you go to the next scene 
	void Start () {
		BackButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("StoryScene1"));
		AvatarButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("AvatarScene"));
	}
}
