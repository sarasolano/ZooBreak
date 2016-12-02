﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour {
	// the start button, which takes you to the story scene
	public Button StartButton;

	//This initializes the button so that when you click it, you start the game 
	void Start () {
		StartButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("StoryScene1"));
	}
}
