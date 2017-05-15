using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// To Do
/// Add collision with the item object
/// make it a trigger
/// make the trigger talk to inventory
/// 
/// </summary>




public class ItemShell : MonoBehaviour {

	public string name;
	public float Melee;
	public float Ranged;
	public float Magic;
	public float Armor;
	public float Speed;
	public float Resist;
	public float Sprite;
	public float type;

	List<Item> newList;
	ItemShell its;
	int i;
	ItemLoader iL;
	public GameObject[] setItems;


	void Start () {
		iL = GameObject.Find ("Maze(Clone)").GetComponent<ItemLoader> ();
		its = GetComponent<ItemShell> ();
		newList = iL.newList;
		setItems = GameObject.FindGameObjectsWithTag ("Item");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public IEnumerator Checker(){

		foreach (GameObject setItem in setItems) {
			if (its.name == setItem.GetComponent<ItemShell> ().name) {
				its.name = newList [i].name;
				its.Melee = newList [i].Melee;
				its.Ranged = newList [i].Ranged;
				its.Magic = newList [i].Magic;
				its.Armor = newList [i].Armor;
				its.Speed = newList [i].Speed;
				its.Resist = newList [i].Resist;
				its.type = newList [i].type;
			}
		}
		yield break;
	}
}
