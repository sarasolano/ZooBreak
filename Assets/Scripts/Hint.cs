using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// Constructs a Hint class
public class Hint : MonoBehaviour {
	private string word; // the word of the hint
	private char represent; // the charater the hint represents
	private string unscramble; // the unscrambled word
	public bool solved, addedToFinal, wrong; // bools of state
	private InputField field; // the input field for the unscrambling of the hint 

	private string finalword; // the final word

	// creates a hint
	public void CreateHint(string word, char represent, string unscramble, HashSet<int> unscrambleOrder) {
		this.word = word;
		this.represent = represent;
		this.unscramble = unscramble;
		field = UnscrambleManager.Instance.unscramble.transform.GetChild (0).GetComponent<InputField> ();
	}

	void Update() {
		// check if this is the current hint
		if (UnscrambleManager.Instance.currentHint != this)
			return;

		if (solved) { // make unscramble green if solved and change text
			UnscrambleManager.Instance.unscramble.text = word;
			UnscrambleManager.Instance.unscramble.color = new Color32 (40, 201, 70, 255);
			field.DeactivateInputField ();
			if (!addedToFinal) { // add letter to final it hasn't been added
				UnscrambleManager.Instance.AddToFinal ();
				addedToFinal = true;
			}
		} else if (wrong) { // make unscramble red if it is wrong
			UnscrambleManager.Instance.unscramble.color = Color.red;
		} else { // make unscramble black if normal or hasn't reached word limit
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

		// check if tutorial has already been shown
		if (!UnscrambleManager.Instance.showedTutorial) {
			UnscrambleManager.Instance.showedTutorial = true;
			par.text = "Unscramble the letters to find the name of an animal. " +
				"\n Press ESCAPE to exit the editor.";
		} else {
			par.text = "";
		}
			
		field.text = "";
		field.characterLimit = word.Length;

		// add the unscramble word
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
