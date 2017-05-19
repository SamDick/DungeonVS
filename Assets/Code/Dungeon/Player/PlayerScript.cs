using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	GameObject manager;
	StatsManager sm;

	public bool battle;
	int playerNumber;

	public float hp;
	public float hpTotal;
	public float melee;
	public float ranged;
	public float magic;
	public float armor;
	public float speed;
	public float resist;

	public float meTimer;
	public float meTimerTotal;
	public float raTimer;
	public float raTimerTotal;
	public float maTimer;
	public float maTimerTotal;
	public GameObject boss;
	BossShell bs;
	Camera cam;


	bool attacking;
	void Awake(){

		DontDestroyOnLoad (gameObject);

	}

	void Start () {

		cam = GetComponentInChildren<Camera> ();

		if (transform.position == new Vector3 (0, 6, 0)) {
			playerNumber = 0;
			cam.rect = new Rect (0, 0.5f, 1, 0.5f);
		} else {
			playerNumber = 1;
			cam.rect = new Rect (0, 0, 1, 0.5f);

		}

	
		manager = GameObject.Find ("Manager(Clone)");
		sm = manager.GetComponent<StatsManager> ();



		meTimer = 0;
		meTimerTotal = 6 / speed + armor / 4;
		raTimer = 0;
		raTimerTotal = 6 / speed + armor / 2 - speed / 4;
		maTimer = 0;
		maTimerTotal = 6 / speed + armor / 2 - resist / 2;
		boss = null;

	}
	
	// Update is called once per frame
	void Update () 
	{

		hp = sm.hp;
		hpTotal = sm.hpTotal;
		melee = sm.melee;
		ranged = sm.ranged;
		magic = sm.magic;
		armor = sm.armor;
		speed = sm.speed;
		resist = sm.resist;

		meTimerTotal = 6 / speed + armor / 4;
		raTimerTotal = 6 / speed + armor / 2 - speed / 4;
		maTimerTotal = 6 / speed + armor / 2 - resist / 2;

		if (battle == true) {
			bs = boss.GetComponent<BossShell> ();
			meTimer -= Time.deltaTime;
			raTimer -= Time.deltaTime;
			maTimer -= Time.deltaTime;

			if (meTimer <= 0 || meTimer == 0) {

				if (Input.GetKeyDown (KeyCode.UpArrow) && attacking == false) {
					StartCoroutine (Melee ());
					attacking = true;
					meTimer = 6 / speed + armor / 4;
				}
			}
			if (raTimer <= 0 || raTimer == 0) {
				if (Input.GetKeyDown (KeyCode.LeftArrow) && attacking == false) {
					StartCoroutine (Ranged ());
					attacking = true;
					raTimer = 6 / speed + armor / 2 - speed / 4;
				}
			}
			if (maTimer <= 0 || maTimer == 0) {
				if (Input.GetKeyDown (KeyCode.RightArrow) && attacking == false) {
					StartCoroutine (Magic ());
					attacking = true;
					maTimer = 6 / speed + armor / 2 - resist / 2;
				}
			}
						
		}
		if (boss != null && boss.GetComponent<BossShell> ().fight == false) {
			battle = false;
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

		bs.HP -= melee - (bs.armor / 2f);
		//bs.Damage;
		//animation
		//wait til animation ends
		yield return new WaitForSeconds(1f);
		attacking = false;
		yield break;
	}

	IEnumerator Ranged(){

		bs.HP -= ranged - (bs.speed / 2f);
		//bs.Damage;
		//animation
		//wait til animation ends

		yield return new WaitForSeconds(1f);
		attacking = false;
		yield break;
	}

	IEnumerator Magic(){

		bs.HP -= magic - (bs.resist / 2f);
		//bs.Damage;
		//animation
		//wait til animation ends

		yield return new WaitForSeconds(1f);
		attacking = false;
		yield break;
	}
}
