using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AvatarScene : MonoBehaviour {

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


	//text that tells the player which avatar they selected
	public Text Selection0;
	public Text Selection1;
	public Text Selection2;
	public Text Selection3;
	public Text Selection4;
	public Text Selection5;


	//This initializes the button so that when you click it, you go to the appropriate scene 
	void Start () {
		BackButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("StoryScene"));
		
		MapButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("MainMap"));


		//determine which avatar the player selects
		Man_Afro.onClick.AddListener (() =>
			{Player0();});
		Man_Brown.onClick.AddListener (() =>
			{Player1();});
		Man_White.onClick.AddListener (() =>
			{Player2();});
		Woman_Afro.onClick.AddListener (() =>
			{Player3();});
		Woman_Brown.onClick.AddListener (() =>
			{Player4();});
		Woman_White.onClick.AddListener (() =>
			{Player5();});
		
	}


	void Player0 (){
		AllLevelManager.avatar = 0;

		//this lets the player know that they have selected their avatar
		//you need to make sure that the other text boxes are turned off, because
		//they player may change their mind and select a new avatar
		Selection0.gameObject.SetActive (true);
		Selection1.gameObject.SetActive (false);
		Selection2.gameObject.SetActive (false);
		Selection3.gameObject.SetActive (false);
		Selection4.gameObject.SetActive (false);
		Selection5.gameObject.SetActive (false);
	}
	void Player1 (){
		AllLevelManager.avatar = 1;
		Selection0.gameObject.SetActive (false);
		Selection1.gameObject.SetActive (true);
		Selection2.gameObject.SetActive (false);
		Selection3.gameObject.SetActive (false);
		Selection4.gameObject.SetActive (false);
		Selection5.gameObject.SetActive (false);
	}
	void Player2 (){
		AllLevelManager.avatar = 2;
		Selection0.gameObject.SetActive (false);
		Selection1.gameObject.SetActive (false);
		Selection2.gameObject.SetActive (true);
		Selection3.gameObject.SetActive (false);
		Selection4.gameObject.SetActive (false);
		Selection5.gameObject.SetActive (false);
	}
	void Player3 (){
		AllLevelManager.avatar = 3;
		Selection0.gameObject.SetActive (false);
		Selection1.gameObject.SetActive (false);
		Selection2.gameObject.SetActive (false);
		Selection3.gameObject.SetActive (true);
		Selection4.gameObject.SetActive (false);
		Selection5.gameObject.SetActive (false);
	}
	void Player4 (){
		AllLevelManager.avatar = 4;
		Selection0.gameObject.SetActive (false);
		Selection1.gameObject.SetActive (false);
		Selection2.gameObject.SetActive (false);
		Selection3.gameObject.SetActive (false);
		Selection4.gameObject.SetActive (true);
		Selection5.gameObject.SetActive (false);
	}
	void Player5 (){
		AllLevelManager.avatar = 5;
		Selection0.gameObject.SetActive (false);
		Selection1.gameObject.SetActive (false);
		Selection2.gameObject.SetActive (false);
		Selection3.gameObject.SetActive (false);
		Selection4.gameObject.SetActive (false);
		Selection5.gameObject.SetActive (true);
	}
}
