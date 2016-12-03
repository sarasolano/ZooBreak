using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UnscrambleManager : MonoBehaviour {

	private static string FILENAME = "extra_files/animal_words2.txt";
	private List<string> words;
	private Dictionary<char, List<string>> letterToWords;

	public Text unscramble;
	public Text finalHintText;
	public Text cageDoorText;

	public Hint[] hintsTypes;
	public Transform[] hintSpots;

	public List<Hint> hints;
	public string currentWord;

	public Hint currentHint;
	public CageDoor door;
	public bool showedTutorial; 
	 
	// the final hint unscrambles
	public StringBuilder finalHint = new StringBuilder();

	// instance of the manager
	private static UnscrambleManager instance;
	public static UnscrambleManager Instance {
		get { // an instance getter
			if (instance == null) {
				instance = GameObject.FindObjectOfType<UnscrambleManager> ();
			}
			return instance;
		}
	}

	// initializing variables
	void Awake() {
		hints = new List<Hint> ();
		words = new List<string> ();
		letterToWords = new Dictionary<char, List<string>> ();
		GetWords ();
		SpawnObjects ();
		showedTutorial = false;
		currentHint = null;
		InputField field = unscramble.transform.GetChild (0).GetComponent<InputField> ();
		Text par = field.transform.parent.parent.GetComponent<Text> ();
		par.gameObject.SetActive (false);
		cageDoorText.transform.parent.gameObject.SetActive (false);
	}
		
	void Update() {
		InputField field = unscramble.transform.GetChild (0).GetComponent<InputField> ();
		Text par = field.transform.parent.parent.GetComponent<Text> ();

		//if currenthint.solved = true 
			//set coroutine --> par.gameObject.SetActive (false);
		if (par.gameObject.activeSelf && Input.GetKey(KeyCode.Return)) {
			par.gameObject.SetActive (false);
		}

		// if the player guessed a solution of the correct length 
		if (unscramble.text.Length > 0 && field.text.Length == currentHint.Word().Length) {
			if (field.text.Equals (currentHint.Word ())) {
				currentHint.solved = true;
				currentHint.wrong = false;


			} else {
				currentHint.wrong = true;
			}
		}

		//check if final hint is correct 
		field = cageDoorText.transform.GetChild (0).GetComponent<InputField> ();
		if (field.text.Length == currentWord.Length){
			if (field.text.Equals (currentWord)) {
				door.found = true;
			} else {
				door.wrong = true;
			}
		}
	}
		
	public void AddToFinal() {
		finalHint.Append (currentHint.Represent());
		finalHintText.text = finalHint.ToString ();
	}

	// spawns hint objects in the scene
	private void SpawnObjects() {
		// selects a random word and its hints
		KeyValuePair<string, List<Hint>> word = SelectWord ();

		// checks if the word is valid for unscramble
		while (word.Key.Length != hints.Count) {
			word = SelectWord ();
		}

		currentWord = word.Key;

		// sets the input field for the last word unscramble to the length limit
		InputField field = cageDoorText.transform.GetChild (0).GetComponent<InputField> ();
		field.characterLimit = currentWord.Length;

		Debug.Log (currentWord);

		// locates the hint objects 
		int j = 0;
		HashSet<int> set = generateNRandom (hintSpots.Length, currentWord.Length);
		Debug.Log (hints.Count);
		foreach (int i in set) {
			Debug.Log ("spot: " + i);
			Transform spot = hintSpots [i];
			hints [j].transform.position = spot.position;
			j++;
		}
	}

	// randomized selection of the word for unscramble game
	private KeyValuePair<string, List<Hint>> SelectWord() {
		int r = Random.Range (0, words.Count);
		string w = words [r]; // Gets a random word from the dictionary

		List<char> cl = new List<char> (); // the list or chars in the list
		foreach (char c in w) {
			cl.Add (c);
		}

		// sorts letters based on how many words contains each char
		cl.Sort (delegate(char c1, char c2) {
			return letterToWords[c1].Count.CompareTo(letterToWords[c2].Count);
		});

		int count = 0; // counts the chars in cl
		foreach (char c in cl) {
			string s = GetRandomWord (c, w);
			//generated random numbers for the unscramble
			HashSet<int> rand = generateNRandom(s.Length, s.Length);

			// the unscrambled word
			StringBuilder unscramble = new StringBuilder ();
			foreach (int i in rand) {
				unscramble.Append (s[i]);
			}

			// created Hint objects
			r = Random.Range (0, w.Length);
			if (hints.Count < count + 1) {
				Hint h = Instantiate (hintsTypes [r / hintsTypes.Length]).GetComponent<Hint> ();
				hints.Add (h);
			}
			Hint hint = hints[count];
			hint.CreateHint (s, c, unscramble.ToString(), rand);

			count++;
		}
		return new KeyValuePair<string, List<Hint>> (w, hints);
	}

	// gets all words in FILENAME
	private void GetWords() {
		string w;
		StreamReader file = new StreamReader(FILENAME);

		while ((w = file.ReadLine ()) != null) {
			string lower = w.ToLower ();
			foreach (char c in lower) {
				if (!letterToWords.ContainsKey (c)) {
					letterToWords.Add(c, new List<string>());
				}

				letterToWords [c].Add (lower);
			}
			words.Add (lower);
		}

		file.Close ();
	}

	// get a random word from the dictionary based on char c
	private string GetRandomWord(char c, string baseW) {
		List<string> l = letterToWords [c];
		int r = Random.Range (0, l.Count);
		string s = l [r];

		while (s.Equals (baseW)) {
			r = Random.Range (0, l.Count);
			s = l [r];
		} 
		return s;
	}

	// generates n unique random numbers between 0 and max (exclusive)
	private HashSet<int> generateNRandom(int max, int n) {
		HashSet<int> s = new HashSet<int> ();
		s.Add (Random.Range (0, max));
		while (s.Count < n) {
			s.Add (Random.Range (0, max));
		}
		return s;
	}
}
