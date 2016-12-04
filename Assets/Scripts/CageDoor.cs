using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CageDoor : MonoBehaviour {
	public bool found, wrong;
	string finalHint;
	UnscrambleManager manager;

	void Start() {
		manager = UnscrambleManager.Instance;
	}

	void Update() {
		InputField field = manager.cageDoorText.transform.GetChild (0).GetComponent<InputField> ();
		if (found) {
			field.DeactivateInputField ();
			manager.cageDoorText.color = Color.green;
			manager.cageDoorText.text = manager.currentWord;
		} else if (wrong) {
			manager.cageDoorText.color = Color.red;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			manager.unscramble.transform.parent.gameObject.SetActive (false);

			finalHint = manager.finalHint.ToString();
			manager.cageDoorText.transform.parent.gameObject.SetActive (true);
			InputField field = manager.cageDoorText.transform.GetChild (0).GetComponent<InputField> ();
			manager.cageDoorText.color = Color.black;

			// check if all hints for the last puzzle have been found
			if (finalHint.Length == manager.currentWord.Length) {
				manager.cageDoorText.text = finalHint;
				field.ActivateInputField ();
			} else { // if hints haven't been found
				field.DeactivateInputField ();
				manager.cageDoorText.text = "No hint to show";
				manager.cageDoorText.color = Color.red;
			}
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag("Player")) {
			manager.cageDoorText.transform.parent.gameObject.SetActive (false);
		}
	}
}
