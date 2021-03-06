﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour {

	// the back button, which takes you back to the avatar scene
	public Button BackButton;
	public Button Lock_lev1, Lock_lev2, Lock_lev3, Lock_lev4, Lock_lev5, Lock_lev6;
	public Button Ent_lev1, Ent_lev2, Ent_lev3, Ent_lev4, Ent_lev5, Ent_lev6;


	void Start () {
		//This initializes the button so that when you click it, you go to the appropriate scene
		BackButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("AvatarScene"));



		if (!AllLevelManager.level1Over) {
			Lock_lev1.onClick.AddListener (() =>
				SceneManager.LoadScene ("Level1"));
			Lock_lev1.onClick.AddListener (() =>
				{OnLevel1();});
		}
		if (AllLevelManager.level1Over && !AllLevelManager.level2Over) {
			Level1Over ();
			Lock_lev2.onClick.AddListener (() =>
				SceneManager.LoadScene ("Level2"));
			Lock_lev2.onClick.AddListener (() =>
				{OnLevel2();});
		}
		if (AllLevelManager.level1Over && AllLevelManager.level2Over && !AllLevelManager.level3Over) {
			Level1Over ();
			Level2Over ();
			Lock_lev3.onClick.AddListener (() =>
				SceneManager.LoadScene ("Level3"));
			Lock_lev3.onClick.AddListener (() =>
				{OnLevel3();});
		}
		if (AllLevelManager.level1Over && AllLevelManager.level2Over && AllLevelManager.level3Over && !AllLevelManager.level4Over) {
			Level1Over ();
			Level2Over ();
			Level3Over ();
			Lock_lev4.onClick.AddListener (() =>
				SceneManager.LoadScene ("Level4"));
			Lock_lev4.onClick.AddListener (() =>
				{OnLevel4();});
		}
		if (AllLevelManager.level1Over && AllLevelManager.level2Over && AllLevelManager.level3Over && AllLevelManager.level4Over && !AllLevelManager.level5Over) {
			Level1Over ();
			Level2Over ();
			Level3Over ();
			Level4Over ();
			Lock_lev5.onClick.AddListener (() =>
				SceneManager.LoadScene ("Level5"));
			Lock_lev5.onClick.AddListener (() =>
				{OnLevel5();});
		}
		if (AllLevelManager.level1Over && AllLevelManager.level2Over && AllLevelManager.level3Over && AllLevelManager.level4Over && AllLevelManager.level5Over && !AllLevelManager.level6Over) {
			Level1Over ();
			Level2Over ();
			Level3Over ();
			Level4Over ();
			Level5Over ();
			Lock_lev6.onClick.AddListener (() =>
				SceneManager.LoadScene ("Level6"));
			Lock_lev6.onClick.AddListener (() =>
				{OnLevel6();});
		}
		if (AllLevelManager.level1Over && AllLevelManager.level2Over && AllLevelManager.level3Over && AllLevelManager.level4Over && AllLevelManager.level5Over && AllLevelManager.level6Over) {
			Level1Over ();
			Level2Over ();
			Level3Over ();
			Level4Over ();
			Level6Over ();
		}
	}




	//helper methods to avoid redundancy when later levels are complete,
	//but you want to continue to be able to play earlier levels

	//ensures that the level 1 lock switches to the level 1 "enter" button
	void Level1Over (){
		Lock_lev1.gameObject.SetActive (false);
		Ent_lev1.gameObject.SetActive (true);
		Ent_lev1.onClick.AddListener (() =>
			SceneManager.LoadScene ("Level1"));
		Ent_lev1.onClick.AddListener (() =>
			{OnLevel1();});
	}

	//ensures that the level 2 lock switches to the level 2 "enter" button
	void Level2Over (){
		Lock_lev2.gameObject.SetActive (false);
		Ent_lev2.gameObject.SetActive (true);
		Ent_lev2.onClick.AddListener (() =>
			SceneManager.LoadScene ("Level2"));
		Ent_lev2.onClick.AddListener (() =>
			{OnLevel2();});
	}

	//ensures that the level 3 lock switches to the level 3 "enter" button
	void Level3Over (){
		Lock_lev3.gameObject.SetActive (false);
		Ent_lev3.gameObject.SetActive (true);
		Ent_lev3.onClick.AddListener (() =>
			SceneManager.LoadScene ("Level3"));
		Ent_lev3.onClick.AddListener (() =>
			{OnLevel3();});
	}

	//ensures that the level 4 lock switches to the level 4 "enter" button
	void Level4Over (){
		Lock_lev4.gameObject.SetActive (false);
		Ent_lev4.gameObject.SetActive (true);
		Ent_lev4.onClick.AddListener (() =>
			SceneManager.LoadScene ("Level4"));
		Ent_lev4.onClick.AddListener (() =>
			{OnLevel4();});
	}

	//ensures that the level 5 lock switches to the level 5 "enter" button
	void Level5Over (){
		Lock_lev5.gameObject.SetActive (false);
		Ent_lev5.gameObject.SetActive (true);
		Ent_lev5.onClick.AddListener (() =>
			SceneManager.LoadScene ("Level5"));
		Ent_lev5.onClick.AddListener (() =>
			{OnLevel5();});
	}

	//ensures that the level 6 lock switches to the level 6 "enter" button
	void Level6Over (){
		Lock_lev6.gameObject.SetActive (false);
		Ent_lev6.gameObject.SetActive (true);
		Ent_lev6.onClick.AddListener (() =>
			SceneManager.LoadScene ("Level6"));
		Ent_lev6.onClick.AddListener (() =>
			{OnLevel6();});
	}




	//helper methods to set global variable of which level you're on
	void OnLevel1(){
		AllLevelManager.currLevel = 1;
	}
	void OnLevel2(){
		AllLevelManager.currLevel = 2;
	}
	void OnLevel3(){
		AllLevelManager.currLevel = 3;
	}
	void OnLevel4(){
		AllLevelManager.currLevel = 4;
	}
	void OnLevel5(){
		AllLevelManager.currLevel = 5;
	}
	void OnLevel6(){
		AllLevelManager.currLevel = 6;
	}
}
