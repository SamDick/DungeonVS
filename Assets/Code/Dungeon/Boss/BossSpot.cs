using UnityEngine;
using System.Collections;


public class BossSpot : MonoBehaviour {

	StatsManager sm;
	Collider fightTrigger;
	GameObject player;

	void Start () {

		sm = GameObject.Find ("Manager(Clone)").GetComponent<StatsManager> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		fightTrigger = GetComponentInChildren<Collider> ();

	
	}
	
	// Update is called once per frame
	void Update () {



	
	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Player") {
			sm.battle = true;
			GetComponentInChildren<BossShell> ().fight = true;
			player.GetComponent<DungeonBattleControl> ().boss = gameObject;
		}

	}
}
