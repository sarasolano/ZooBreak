using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level5Manager : MonoBehaviour {

	public Button MapButton;
	public GameObject greyHalf1, greyHalf2, half1, half2, bridgeComplete;



	private int bridgeCount;

	// Use this for initialization
	void Start () {
		MapButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("MainMap"));
		bridgeCount = 0;
	}

	// Update is called once per frame
	void Update () {
		AllLevelManager.level5Over = true;
	}

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
}
