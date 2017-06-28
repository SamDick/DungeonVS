using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloStarter : MonoBehaviour {

	void Start () {
		Instantiate (Resources.Load ("Dungeon/HUD"), Vector3.zero, transform.rotation, null);
		if (GameObject.Find ("SoloPlayer(Clone)") == null){
			
			Instantiate (Resources.Load ("Dungeon/SoloPlayer"), new Vector3 (0, 6, 0), transform.rotation, null);
		}

		Instantiate (Resources.Load ("Dungeon/DungeonV2"), Vector3.zero, transform.rotation, null);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("SoloPlayer(Clone)") == null){
			Instantiate (Resources.Load ("Dungeon/SoloPlayer"), new Vector3 (0, 6, 0), transform.rotation, null);
			Instantiate (Resources.Load ("Dungeon/DungeonV2"), Vector3.zero, transform.rotation, null);
		}
		if (GameObject.Find ("HUD(Clone)") == null){
			Instantiate (Resources.Load ("Dungeon/HUD"), Vector3.zero, transform.rotation, null);
		}
		
	}
}
