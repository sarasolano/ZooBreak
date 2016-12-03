using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinningScene : MonoBehaviour {
	// the restart button, which takes you to the start scene
	public Button ReStartButton;

	// Use this for initialization
	void Start () {
		ReStartButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("StartScene"));
	}
}
