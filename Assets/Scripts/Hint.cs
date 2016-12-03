using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Hint : MonoBehaviour {

	private string word;
	private char represent;
	private string unscramble;
	private HashSet<int> unscrambleOrder;
	public bool solved;

	public void CreateHint(string word, char represent, string unscramble, HashSet<int> unscrambleOrder) {
		this.word = word;
		this.represent = represent;
		this.unscramble = unscramble;
		this.unscrambleOrder = unscrambleOrder;
	}

	void Update() {
		if (solved && UnscrambleManager.Instance.currentHint == this) {
			UnscrambleManager.Instance.unscramble.text = word;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		InputField field = UnscrambleManager.Instance.unscramble.transform.GetChild (0).GetComponent<InputField> ();

		UnscrambleManager.Instance.currentHint = this;
		Text par = field.transform.parent.parent.GetComponent<Text> ();
		par.gameObject.SetActive (true);

		if (!UnscrambleManager.Instance.showedTutorial) {
			UnscrambleManager.Instance.showedTutorial = true;
			par.text = "Unscramble the letters to find the name of an animal. Press Esc to exit the editor.";
		} else {
			par.text = "";
		}

		field.text = "";
		field.characterLimit = word.Length;

		if (!solved) {
			UnscrambleManager.Instance.unscramble.text = unscramble;
		} 
		Debug.Log (unscramble + " --> " + word + ": " + represent);
	}




	public string Word() {
		return word;
	}

}
