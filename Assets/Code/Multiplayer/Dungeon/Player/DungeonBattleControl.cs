using UnityEngine;
using System.Collections;

public class DungeonBattleControl : MonoBehaviour {

	GameObject manager;
	StatsManager sm;


	public float meTimer;
	public float meTimerTotal;
	public float raTimer;
	public float raTimerTotal;
	public float maTimer;
	public float maTimerTotal;
	public GameObject boss;
	BossShell bs;

	bool attacking;

	void Awake () {





	}

	// Update is called once per frame
	void Update () 
	{
		if (sm == null) {
			sm = GameObject.Find ("Manager(Clone)").GetComponent<StatsManager> ();
			meTimer = 0;
			meTimerTotal = 6 / sm.speed + sm.armor / 4;
			raTimer = 0;
			raTimerTotal = 6 / sm.speed + sm.armor / 2 - sm.speed / 4;
			maTimer = 0;
			maTimerTotal = 6 / sm.speed + sm.armor / 2 - sm.resist / 2;
			boss = null;

			meTimerTotal = 6 / sm.speed + sm.armor / 4;
			raTimerTotal = 6 / sm.speed + sm.armor / 2 - sm.speed / 4;
			maTimerTotal = 6 / sm.speed + sm.armor / 2 - sm.resist / 2;
		}

		if (sm.battle == true && sm != null && boss != null) {
			bs = boss.GetComponent<BossShell> ();
			meTimer -= Time.deltaTime;
			raTimer -= Time.deltaTime;
			maTimer -= Time.deltaTime;

			if (meTimer <= 0 || meTimer == 0) {

				if (Input.GetKey (KeyCode.JoystickButton0) && attacking == false) {
					StartCoroutine (Melee ());
					attacking = true;
					meTimer = 6 / sm.speed + sm.armor / 4;
				}
			}
			if (raTimer <= 0 || raTimer == 0) {
				if (Input.GetKey (KeyCode.JoystickButton1) && attacking == false) {
					StartCoroutine (Ranged ());
					attacking = true;
					raTimer = 6 / sm.speed + sm.armor / 2 - sm.speed / 4;
				}
			}
			if (maTimer <= 0 || maTimer == 0) {
				if (Input.GetKey (KeyCode.JoystickButton2) && attacking == false) {
					StartCoroutine (Magic ());
					attacking = true;
					maTimer = 6 / sm.speed + sm.armor / 2 - sm.resist / 2;
				}
			}

		}
		if (boss != null && boss.GetComponent<BossShell> ().fight == false) {
			sm.battle = false;
			meTimer = 0;
			raTimer = 0;
			maTimer = 0;
		} else {
		}

	}

	public IEnumerator Damage (){


		return null;
	}

	IEnumerator Melee(){

		bs.HP -= sm.melee - (bs.armor / 2f);

		//animation
		//wait til animation ends
		yield return new WaitForSeconds(1f);
		attacking = false;
		yield break;
	}

	IEnumerator Ranged(){

		bs.HP -= sm.ranged - (bs.speed / 2f);

		//animation
		//wait til animation ends
		yield return new WaitForSeconds(1f);
		attacking = false;
		yield break;
	}

	IEnumerator Magic(){

		bs.HP -= sm.magic - (bs.resist / 2f);

		//animation
		//wait til animation ends
		yield return new WaitForSeconds(1f);
		attacking = false;
		yield break;
	}
}
