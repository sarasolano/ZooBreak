using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Hint : MonoBehaviour {

	private string word;
	private char represent;
	private string unscramble;
	public bool solved, addedToFinal, wrong;
	private InputField field;

	private string finalword;

	public void CreateHint(string word, char represent, string unscramble, HashSet<int> unscrambleOrder) {
		this.word = word;
		this.represent = represent;
		this.unscramble = unscramble;
		field = UnscrambleManager.Instance.unscramble.transform.GetChild (0).GetComponent<InputField> ();
	}

	void Update() {
		if (UnscrambleManager.Instance.currentHint != this)
			return;
		
		if (solved ) {
			UnscrambleManager.Instance.unscramble.text = word;
			UnscrambleManager.Instance.unscramble.color = new Color32 (40, 201, 70, 255);
			field.DeactivateInputField ();
			if (!addedToFinal) {
				UnscrambleManager.Instance.AddToFinal ();
				addedToFinal = true;
			}

		} else if (wrong) {
			UnscrambleManager.Instance.unscramble.color = Color.red;
		} else {
			field.ActivateInputField ();
			UnscrambleManager.Instance.unscramble.color = Color.black;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (solved)
			return;

		UnscrambleManager.Instance.currentHint = this;
		Text par = field.transform.parent.parent.GetComponent<Text> ();
		par.gameObject.SetActive (true);

		if (!UnscrambleManager.Instance.showedTutorial) {
			UnscrambleManager.Instance.showedTutorial = true;
			par.text = "Unscramble the letters to find the name of an animal. " +
				"\n Press Return to exit the editor.";
		} else {
			par.text = "";
		}
			
		field.text = "";
		field.characterLimit = word.Length;

		UnscrambleManager.Instance.unscramble.text = unscramble;

		Debug.Log (unscramble + " --> " + word + ": " + represent);
	}

	public string Word() {
		return word;
	} 

	public char Represent() {
		return represent;
	}

}
