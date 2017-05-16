using UnityEngine;
using System.Collections;

public class LocalController : MonoBehaviour {

	Vector3 faraway;
	void Start () {
		faraway = new Vector3 (10000, 0, 0);

		Instantiate (Resources.Load("HUD2"), Vector3.zero, transform.rotation, null);
		Instantiate (Resources.Load ("Maze"), Vector3.zero, transform.rotation, null);
		Instantiate (Resources.Load("DungeonPlayer"), new Vector3(0,6,0), Quaternion.identity, null);

		//Instantiate (Resources.Load("HUD2"), Vector3.zero, transform.rotation, null);
		Instantiate (Resources.Load ("Maze"),faraway, transform.rotation, null);
		Instantiate (Resources.Load("DungeonPlayer"), (new Vector3(0,6,0) + faraway), Quaternion.identity, null);


	
	}

	void Update () {
	
	}
}
