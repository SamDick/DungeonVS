using UnityEngine;
using System.Collections;

public class HUDkeeper : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		GameObject.DontDestroyOnLoad (gameObject);
	}

}
