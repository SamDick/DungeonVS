using UnityEngine;
using System.Collections;

public class StatsManager : MonoBehaviour {


	GameObject player;
	public bool battle;

	public float hp;
	public float hpTotal;
	public float melee;
	public float ranged;
	public float magic;
	public float armor;
	public float speed;
	public float resist;
	public int d20; 
	public bool turn;

	public float speedIndex;
	void Awake(){
		DontDestroyOnLoad (gameObject);
	}

	void Start () {
		

		battle = false;

		hp = 25;
		hpTotal = 25;
		melee = 3;
		ranged = 3;
		magic = 3;
		armor = 3;
		speed = 3;
		resist = 3;
		d20 = Random.Range (1, 21);

			


	}
	
	// Update is called once per frame
	void Update () {



		melee = 3 + GetComponent<Inventory> ().melee;
		ranged = 3 + GetComponent<Inventory> ().ranged;
		magic = 3 + GetComponent<Inventory> ().magic;
		armor = 3 + GetComponent<Inventory> ().armor;
		speed = 3 + GetComponent<Inventory> ().speed;
		resist = 3 + GetComponent<Inventory> ().resist;
		speedIndex = speed / (armor / 2f);

	
	}
}
