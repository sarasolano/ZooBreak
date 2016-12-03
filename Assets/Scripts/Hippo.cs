using UnityEngine;
using System.Collections;

public class Hippo : MonoBehaviour {

	public Transform endPos;
	private Vector3 startPt;
	private Vector3 endPt;
	private float secondsForOneLength = 6.0f;


	//sets the positions for hippo movement
	void Start()
	{
		startPt = transform.position;
		endPt = endPos.position;
	}

	//makes the hippo bob up and down
	void Update()
	{
		transform.position = Vector3.Lerp(startPt, endPt,
			Mathf.SmoothStep(0f,1f,
				Mathf.PingPong(Time.time/secondsForOneLength, 1f)
			) );
	}
}
