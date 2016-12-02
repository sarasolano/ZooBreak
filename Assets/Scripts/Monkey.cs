using UnityEngine;
using System.Collections;

public class Monkey : MonoBehaviour {

	public GameObject bananaPrefab;
	public Transform bananaPos;

	//spawn banana at monkey's hand 
	public void SpawnBanana(){
		Instantiate (bananaPrefab, bananaPos.position, Quaternion.Euler(new Vector3(0, 0 ,300)));
	}
		
}
