using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BossShell : MonoBehaviour {

	StatsManager sm;

	public string name;
	public float HP;
	public float melee;
	public float ranged;
	public float magic;
	public float armor;
	public float speed;
	public float resist;
	public string model;
	public float hpTotal;
	Sprite placeholder;

	public bool fight;

	public float meTimer;
	public float raTimer;
	public float maTimer;
	DungeonBattleControl ps;
	BossLoader bL;
	List<BossScript> newList;
	GameObject player;
	GameObject[] setBosses;
	BossShell bs;
	int i;

	void Start () {
		
		sm = GameObject.Find ("Manager(Clone)").GetComponent<StatsManager> ();

		setBosses = GameObject.FindGameObjectsWithTag ("BossSpot");
		bL = GameObject.Find ("DungeonV2(Clone)").GetComponent<BossLoader> ();
		newList = bL.newList;
		bs = GetComponent<BossShell> ();
	
		player = GameObject.FindGameObjectWithTag ("Player");
		ps = player.GetComponent<DungeonBattleControl> ();
		hpTotal = HP;
			
	}
	
	// Update is called once per frame
	void Update () 
	{

		//always attack using best attack first
		//cycle through others, always using the best one
		if (fight == true) 
		{
			meTimer -= Time.deltaTime;
			raTimer -= Time.deltaTime;
			maTimer -= Time.deltaTime;

			if (meTimer <= 0) 
			{
				StartCoroutine (Melee ());
				meTimer = 10/speed + armor/4;
			}
			if (raTimer <= 0) 
			{
				StartCoroutine (Ranged ());
				raTimer = 10/speed + armor/2 - speed/4;
			}
			if (maTimer <= 0) {
				StartCoroutine (Magic ());
				maTimer = 10 / speed + armor / 2 - resist / 2;
			}
		}
		if (HP <= 0) {
			fight = false;
			StartCoroutine (Death ());
		}
	}
	IEnumerator Melee(){

		sm.hp -= melee - (sm.armor / 2f);
		//ps.Damage;
		//animation
		//wait til animation ends
			yield break;
	}

	IEnumerator Ranged(){

		sm.hp -= ranged - (sm.speed / 2f);
		//ps.Damage;
		//animation
		//wait til animation ends
		yield break;
	}

	IEnumerator Magic(){

		sm.hp -= magic - (sm.resist / 2f);
		//ps.Damage;
		//animation
		//wait til animation ends
		yield break;
	}
	IEnumerator Death(){

		//run riht animation. All of the bosses will have an animation called death and it will
		//be called here
		//wait till it's done
		//show the child item
		yield break;
	}
	//public IEnumerator Checker(){
	//	foreach (GameObject setBoss in setBosses) {
	//		if (bs.name == setBoss.GetComponent<BossShell> ().name) {
	//			bs.name = newList [i].name;
	//			bs.melee = newList [i].Melee;
	//			bs.ranged = newList [i].Ranged;
	//			bs.magic = newList [i].Magic;
	//			bs.armor = newList [i].Armor;
	//			bs.speed = newList [i].Speed;
	//			bs.resist = newList [i].Resist;
	//		}
	//	}
	//	yield break;
	//}
}
