using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AvatarSceneScript : MonoBehaviour {

	// the buttons at the bottom of the screen
	public Button BackButton;
	public Button MapButton;

	//avatar selection
	public Button Man_Afro;
	public Button Man_Brown;
	public Button Man_White;
	public Button Woman_Afro;
	public Button Woman_Brown;
	public Button Woman_White;


	//This initializes the button so that when you click it, you go to the appropriate scene 
	void Start () {
		BackButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("StoryScene"));
		
		MapButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("MainMap"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
