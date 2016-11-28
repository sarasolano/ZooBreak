using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryScene : MonoBehaviour {

	// the buttons at the bottom of the screen
	public Button BackButton;
	public Button AvatarButton;
	public Text storyText;

	//This initializes the button so that when you click it, you go to the next scene 
	void Start () {
		BackButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("StartScene"));
		AvatarButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("AvatarScene"));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			storyText.text = "You have managed to escape from your enclosure. " +
				"Now, it is up to you to free your fellow humans from each of the other cages.";

		}
	}
}
