using UnityEngine;
using System.Collections;


public class BossSpot : MonoBehaviour {

	StatsManager sm;
	Collider fightTrigger;
	GameObject player;

	void Start () {

		sm = GameObject.Find ("SoloManager").GetComponent<StatsManager> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		fightTrigger = GetComponentInChildren<Collider> ();

	
	}
	
	// Update is called once per frame
	void Update () {



	
	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Player") {
			if (transform.name == "SuperBoss") {
				if (sm.relicCount >= 2) {
					
					sm.battle = true;
					GetComponentInChildren<BossShell> ().fight = true;
					player.GetComponent<DungeonBattleControl> ().boss = gameObject;
					player.GetComponent<SoloHUD> ().rtBHP.localScale = new Vector3 (2.0775f, 2.0755f, 0);
				}
			} else {
				sm.battle = true;
				GetComponentInChildren<BossShell> ().fight = true;
				player.GetComponent<DungeonBattleControl> ().boss = gameObject;
				player.GetComponent<SoloHUD> ().rtBHP.localScale = new Vector3 (2.0775f, 2.0755f, 0);
			}
		}

	}
}
