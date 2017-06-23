using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloStarter : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Instantiate (Resources.Load("HUD"), Vector3.zero, transform.rotation, null);
		Instantiate (Resources.Load ("Maze"), Vector3.zero, transform.rotation, null);
		Instantiate (Resources.Load("SoloPlayer"), new Vector3(0,6,0), Quaternion.identity, null);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
