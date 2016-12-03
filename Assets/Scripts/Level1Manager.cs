using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1Manager : MonoBehaviour {
	public Button MapButton;

	// Use this for initialization
	void Start () {
		MapButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("MainMap"));
	}
	
	// Update is called once per frame
	void Update () {
		AllLevelManager.level1Over = true;
	}
}
