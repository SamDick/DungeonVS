using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class VersusControl : Photon.MonoBehaviour {

	public GameObject playerLocal;
	public GameObject playerOther;
	GameObject[] Players;
	GameObject manager;
	StatsManager stats;
	void Awake(){
		DontDestroyOnLoad (gameObject);
	}
	void Start () 
	{
		Players = GameObject.FindGameObjectsWithTag ("VersusPlayer");
		manager = GameObject.Find ("Manager(Clone)");
		stats = manager.GetComponent<StatsManager> ();
		if (playerLocal == null || playerOther == null) {
			if (photonView.isMine) {

				playerLocal = gameObject;
				foreach (GameObject player1 in Players) {
					player1.GetComponent<VersusBattleControl> ().playerLocal = gameObject;
				}
			} else {
				playerOther = gameObject;
				foreach (GameObject player in Players) {

					player.GetComponent<VersusBattleControl> ().playerOther = gameObject;
				}
				enabled = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
