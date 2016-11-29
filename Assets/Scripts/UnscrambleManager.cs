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

	public Hint[] hints;

	void Awake() {
		words = new List<string> ();
		letterToWords = new Dictionary<char, List<string>> ();
		permutations = new Dictionary<string, List<string>> ();
		SortWords ();
	}

	// sorts all words in FILENAME
	private void SortWords() {
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

	// randomized selection of the word for unscramble game
	public KeyValuePair<string, KeyValuePair<string, string>[]> SelectWord() {
		int r = Random.Range (0, words.Count);
		string w = words [r];
		KeyValuePair<string, string>[] unscramble = new KeyValuePair<string, string>[w.Length];

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
			List<string> per = GetPermutations (s);
			r = Random.Range (0, per.Count);
			unscramble [count] = new KeyValuePair<string, string> (s, per[r]);
			count++;
		}

		return new KeyValuePair<string, KeyValuePair<string, string>[]> (w, unscramble);
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

	// gets all the possible permutations for the string if they haven't been generated
	private List<string> GetPermutations(string s) {
		if (!permutations.ContainsKey (s))
			permutations.Add (s, Permute(s.ToCharArray()));
		return permutations[s];
	}

	// generates all possible permutations for the array arr
	private static List<string> Permute(char[] arr) {
		List<string> toReturn = new List<string> ();
		int x = arr.Length - 1;
		Per(arr, arr, 0, x, toReturn);
		return toReturn;
	}

	//helper for the permutation method
	private static void Per(char[] str, char[] a, int k, int m, List<string> list) {
		if (k == m && !str.Equals(a)) {
			StringBuilder s = new StringBuilder ();
			foreach (char c in a) {
				s.Append (c);
			}
			list.Add(s.ToString());
		}
		else
			for (int i = k; i <= m; i++) {
				Swap(ref a[k], ref a[i]);
				Per(str, a, k + 1, m, list);
				Swap(ref a[k], ref a[i]);
			}
	}

	// swaps the reference a and b
	private static void Swap(ref char a, ref char b) {
		if (a == b) return;
		a ^= b;
		b ^= a;
		a ^= b;
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
