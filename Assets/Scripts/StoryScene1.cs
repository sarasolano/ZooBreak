using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryScene1 : MonoBehaviour {

	// the buttons at the bottom of the screen
	public Button BackButton;
	public Button NextButton;

	//This initializes the button so that when you click it, you go to the next scene 
	void Start () {
		BackButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("StartScene"));
		NextButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("StoryScene2"));
	}
}
