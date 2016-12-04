using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IndividualLevelManager : MonoBehaviour {
	public Button MapButton;
	public GameObject greyHalf1, greyHalf2, half1, half2, bridgeComplete;
	public Text loseText;

	private int bridgeCount;


	// Use this for initialization
	void Start () {
		MapButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("MainMap"));
	}

	//takes care of the UI when bridge pieces are collected (level5)
	public void CollectBridge(){
		Debug.Log ("in collect bridge");

		if (bridgeCount == 0) {
			Debug.Log ("bridge piece 1");
			greyHalf1.SetActive (false);
			half1.SetActive (true);
			bridgeCount++;
		} else {
			greyHalf2.SetActive (false);
			half2.SetActive (true);
			Debug.Log ("bridge piece 2");
			bridgeComplete.SetActive (true);
		}
	}

	//when an animal/weapon hits you --> text tells you that you die
	public void SetLoseText(){
		Debug.Log ("in lose text");
		StartCoroutine (LoseText ());
	}

	IEnumerator LoseText(){
		loseText.text = "You're dead!";
		yield return new WaitForSeconds(2);
		loseText.text = "";
	}
}
