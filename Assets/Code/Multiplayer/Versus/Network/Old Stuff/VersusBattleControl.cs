using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class VersusBattleControl : Photon.MonoBehaviour {


	/// <summary>
	/// </summary>

	public GameObject moveMarker;

	public bool lastRound;
	public float hp;
	public float hpTotal;
	public float melee;
	public float ranged;
	public float magic;
	public float armor;
	public float speed;
	public float resist;
	public float speedIndex;
	public int d20;


	public GameObject playerLocal;
	public GameObject playerOther;
	StatsManager stats;
	AttackSelect aSelect;
	GameObject manager;
	GameObject other;
	public bool ready;
	public bool fighting;
	bool hit;
	GameObject[] Players;
	bool lastTurn;


	public bool rolled;
	void Awake(){
		DontDestroyOnLoad (gameObject);
	}
	void Start () 
	{
		Players = GameObject.FindGameObjectsWithTag ("VersusPlayer");
		manager = GameObject.Find ("Manager(Clone)");
		stats = manager.GetComponent<StatsManager> ();
		aSelect = manager.GetComponent<AttackSelect> ();
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

	void Update () {



		if (rolled == false && playerOther != null && photonView.isMine) {
			
			if (stats.speedIndex >= playerOther.GetComponent<NetworkCharacter> ().speedIndex) {
				stats.turn = true;
			}
			if (stats.speedIndex <= playerOther.GetComponent<NetworkCharacter> ().speedIndex) {
				stats.turn = false;
			}
			if (stats.speedIndex == playerOther.GetComponent<NetworkCharacter> ().speedIndex) {

				if (stats.d20 >= playerOther.GetComponent<NetworkCharacter> ().d20) {
					stats.turn = true;
					rolled = true;

				}
				if (stats.d20 <= playerOther.GetComponent<NetworkCharacter> ().d20) {
					stats.turn = false;
					rolled = true;

				}
				if (stats.d20 == playerOther.GetComponent<NetworkCharacter> ().d20) {
					stats.d20 = Random.Range (1, 21);
				}
			}
		}

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
		hp = stats.hp;
		hpTotal = stats.hpTotal;
		melee = stats.melee;
		ranged = stats.ranged;
		magic = stats.magic;
		armor = stats.armor;
		speed = stats.speed;
		speedIndex = stats.speedIndex;
		resist = stats.resist;
		ready = aSelect.readyFight;
		if (manager.GetComponent<AttackSelect> ().readyFight == true && moveMarker == null) {

			moveMarker = GameObject.Find ("move1");
		}

		if (fighting == false && stats.turn == true && ready == true && playerOther.GetComponent<NetworkCharacter> ().ready == true) {
			if (manager.GetComponent<AttackSelect> ().AttackOrder.Count != 0) {
				fighting = true;
				StartCoroutine	(Attack ());
			} else {
				
				stats.turn = false;
				aSelect.readyFight = false;
				fighting = false;
				rolled = false;
				photonView.RPC ("NextRound", PhotonTargets.All);
				if (lastTurn == false) {
					lastTurn = true;
				} else {
					SceneManager.LoadScene ("Dungeon");
				}
				}	


		}
}


	IEnumerator Attack()
	{
		if (manager.GetComponent<AttackSelect> ().AttackOrder [0] == 0) {
			stats.turn = false;
			fighting = false;
			photonView.RPC ("MeleeHit", PhotonTargets.Others);
			manager.GetComponent<AttackSelect> ().AttackOrder.Remove (0);

			yield break;
		}
	}


	[PunRPC]
	void NextRound()
	{
		if (lastRound == false) {
			
			stats.turn = false;
			fighting = false;
			aSelect.readyFight = false;
			rolled = false;
			lastRound = true;
		} else {
			GameObject.Find ("NetworkController").GetComponent<SceneHandler> ().roundOver = true;
			stats.turn = false;
			fighting = false;
			aSelect.readyFight = false;
			rolled = false;
			lastRound = false;
		}
	}
	[PunRPC]
	void MeleeHit()
	{
		stats.turn = true;
		stats.hp -= playerOther.GetComponent<NetworkCharacter>().melee - (stats.armor / 2);
		}
	[PunRPC]
	void RangedHit()
	{
		stats.turn = true;
		stats.hp -= playerOther.GetComponent<NetworkCharacter>().ranged - (stats.speed / 2);
	}
	[PunRPC]
	void MagicHit()
	{
		stats.turn = true;
		stats.hp -= playerOther.GetComponent<NetworkCharacter>().magic - (stats.resist / 2);
	}


}