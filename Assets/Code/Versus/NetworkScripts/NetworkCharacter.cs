using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {

	// this is the place where we'll deposit all the stats from the manager
	GameObject manager;
	NetworkManager netman;
	StatsManager stats;

	public bool ready;
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
	public bool turn;
	Vector3 pos;


	void Start () 
	{
		

		if (photonView.isMine) {
			
			manager = GameObject.Find ("Manager(Clone)");
			//ready = manager.GetComponent<AttackSelect> ().readyFight;
			stats = manager.GetComponent<StatsManager> ();
			netman = manager.GetComponent<NetworkManager> ();
			turn = stats.turn;
			hp = stats.hp;
			hpTotal = stats.hpTotal;
			melee = stats.melee;
			ranged = stats.ranged;
			magic = stats.magic;
			armor = stats.armor;
			resist = stats.resist;
			speedIndex = stats.speedIndex;
		} else {

		}
	}

	
	// Update is called once per frame
	void Update () {
		if (photonView.isMine) {

			stats = GameObject.Find ("Manager(Clone)").GetComponent<StatsManager> ();
			//ready = manager.GetComponent<AttackSelect> ().readyFight;
			turn = stats.turn;
			hp = stats.hp;
			hpTotal = stats.hpTotal;
			melee = stats.melee;
			ranged = stats.ranged;
			magic = stats.magic;
			armor = stats.armor;
			speed = stats.speed;
			speedIndex = stats.speedIndex;
			resist = stats.resist;
			d20 = stats.d20;
		} else {
		}


	}
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if(stream.isWriting){
			stream.SendNext (transform.position);
			stream.SendNext (hp);
			stream.SendNext (hpTotal);
			stream.SendNext (melee);
			stream.SendNext (ranged);
			stream.SendNext (magic);
			stream.SendNext (armor);
			stream.SendNext (resist);
			stream.SendNext (speed);
			stream.SendNext (speedIndex);
			stream.SendNext (d20);
			stream.SendNext (ready);
			stream.SendNext (turn);

		}else{
			pos = (Vector3)stream.ReceiveNext();
			hp = (float)stream.ReceiveNext();
			hpTotal = (float)stream.ReceiveNext();
			melee = (float)stream.ReceiveNext();
			ranged = (float)stream.ReceiveNext();
			magic = (float)stream.ReceiveNext();
			armor = (float)stream.ReceiveNext();
			resist = (float)stream.ReceiveNext();
			speed = (float)stream.ReceiveNext();
			speedIndex = (float)stream.ReceiveNext();
			d20 = (int)stream.ReceiveNext();
			ready = (bool)stream.ReceiveNext();
			turn = (bool)stream.ReceiveNext();
		}
}
}
