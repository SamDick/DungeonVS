using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public GameObject Weapon;
	public GameObject Armor;
	public GameObject Trinket;

	public float hp;
	public float hpTotal;
	public float melee;
	public float ranged;
	public float magic;
	public float armor;
	public float speed;
	public float resist;
	public string type;

	List<GameObject> Inv = new List<GameObject>();
	public GameObject newItemGO;
	ItemShell newItem;



	void Start () {

		Inv.Add (Weapon);
		Inv.Add (Armor);
		Inv.Add (Trinket);


	
	}
	
	// Update is called once per frame
	void Update () {
		
		foreach (GameObject gear in Inv) {
			if (gear != null) {
				melee = gear.GetComponent<ItemShell> ().Melee;
				ranged = gear.GetComponent<ItemShell> ().Ranged;
				magic = gear.GetComponent<ItemShell> ().Magic;
				armor = gear.GetComponent<ItemShell> ().Armor;
				speed = gear.GetComponent<ItemShell> ().Speed;
				resist = gear.GetComponent<ItemShell> ().Resist;
			}
		}

		
		if (newItemGO != null) {
			newItem = newItemGO.GetComponent<ItemShell> ();

			if (Input.GetKeyDown (KeyCode.JoystickButton3)) {

				Pickup ();

			}

		}

	
	}

	void Pickup(){

		if (newItem.type == 0) {
			if (Weapon != null) {
				Weapon.transform.parent = null;
				Weapon.GetComponent<SpriteRenderer> ().enabled = true;
			}
				Inv.RemoveAt (0);
				Weapon = newItemGO;
				Inv.Insert (0, Weapon);
		}

		newItemGO.GetComponent<SpriteRenderer> ().enabled = false;
		newItemGO.transform.parent = GameObject.Find ("SoloPlayer(Clone)").transform;



	}
}
