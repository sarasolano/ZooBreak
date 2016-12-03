using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UnscrambleManager : MonoBehaviour {

	private static string FILENAME = "extra_files/animal_words.txt";
	private List<string> words;
	private Dictionary<char, List<string>> letterToWords;
	private Dictionary<string, List<string>> permutations;

	public Text unscramble;
	public Hint[] hintsTypes;
	public Transform[] hintSpots;

	public List<Hint> hints;
	public string currentWord;

	public Hint currentHint;
	public bool showedTutorial;

	private static UnscrambleManager instance;

	public static UnscrambleManager Instance {
		get { // an instance getter
			if (instance == null) {
				instance = GameObject.FindObjectOfType<UnscrambleManager> ();
			}
			return instance;
		}
	}

	void Awake() {
		hints = new List<Hint> ();
		words = new List<string> ();
		letterToWords = new Dictionary<char, List<string>> ();
		permutations = new Dictionary<string, List<string>> ();
		GetWords ();
		SpawnObjects ();
		showedTutorial = false;
		currentHint = null;
		InputField field = unscramble.transform.GetChild (0).GetComponent<InputField> ();
		Text par = field.transform.parent.parent.GetComponent<Text> ();
		par.gameObject.SetActive (false);
	}
		
	void Update() {
		InputField field = unscramble.transform.GetChild (0).GetComponent<InputField> ();
		Text par = field.transform.parent.parent.GetComponent<Text> ();

		if (par.gameObject.activeSelf && Input.GetKey(KeyCode.Escape)) {
			par.gameObject.SetActive (false);
		}

		if (unscramble.text.Length > 0 && field.text.Length == currentHint.Word().Length) {
			if (field.text.Equals (currentHint.Word ())) {
				currentHint.solved = true;
			}
		}
	}

	private void SpawnObjects() {
		KeyValuePair<string, List<Hint>> word = SelectWord ();

		while (word.Key.Length != hints.Count) {
			word = SelectWord ();
		}

		currentWord = word.Key;

		Debug.Log (currentWord);

		int j = 0;
		foreach (int i in generateNRandom(hintSpots.Length, hints.Count)) {
			hints [j].transform.position = hintSpots [i].position;
			j++;
		}
	}

	// randomized selection of the word for unscramble game
	private KeyValuePair<string, List<Hint>> SelectWord() {
		int r = Random.Range (0, words.Count);

		string w = words [r];

		List<char> cl = new List<char> ();
		foreach (char c in w) {
			cl.Add (c);
		}

		// sorts letters depending on how many words contain them
		cl.Sort (delegate(char c1, char c2) {
			return letterToWords[c1].Count.CompareTo(letterToWords[c2].Count);
		});

		int count = 0;
		foreach (char c in cl) {
			string s = GetRandomWord (c, w);

			HashSet<int> rand = generateNRandom(s.Length, s.Length);


			StringBuilder unscramble = new StringBuilder ();
			foreach (int i in rand) {
				unscramble.Append (s[i]);
			}

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
			s.Add (Random.Range (0, n));
		}
		return s;
	}
}
