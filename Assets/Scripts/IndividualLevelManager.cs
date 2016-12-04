using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IndividualLevelManager : MonoBehaviour {
	public Button MapButton;
	public GameObject greyHalf1, greyHalf2, half1, half2, bridgeComplete;
	public Text loseText;
	public GameObject[] avatars;
	public Transform avatarLoc;

	private int bridgeCount;
	private GameObject avatar;

	void Awake() {
		chooseAvatar ();
	}

	// Use this for initialization
	void Start () {
		MapButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("MainMap"));
	}

	//takes care of the UI when bridge pieces are collected (level5)
	public void CollectBridge(){

		if (bridgeCount == 0) {
			greyHalf1.SetActive (false);
			half1.SetActive (true);
			bridgeCount++;
		} else {
			greyHalf2.SetActive (false);
			half2.SetActive (true);
			bridgeComplete.SetActive (true);
		}
	}

	//when an animal/weapon hits you --> text tells you that you die
	public void SetLoseText(){
		StartCoroutine (LoseText ());
	}
	 
	private void chooseAvatar() {
		Debug.Log (avatars.Length + " ---> " + AllLevelManager.avatar);
		avatar = Instantiate(avatars [AllLevelManager.avatar]) as GameObject;
		avatar.transform.position = avatarLoc.position;
	}

	IEnumerator LoseText(){
		loseText.text = "You're dead!";
		yield return new WaitForSeconds(2);
		loseText.text = "";
	}
}
