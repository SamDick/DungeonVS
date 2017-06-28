using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ItemLoader : MonoBehaviour
{
	public const string path = "items";
	public GameObject itemPrefab;
	public GameObject[] bossSpots;
	public GameObject[] items;
	public List<Item> newList;
	ItemShell its;
	int i;

	public List<Item> ShuffleList<Item>(List<Item> inputList)
	{
		List<Item> randomList = new List<Item> ();

		System.Random r = new System.Random ();
		int randomIndex = 0;
		while (inputList.Count > 0) {
			randomIndex = r.Next (0, inputList.Count);
			randomList.Add (inputList [randomIndex]);
			inputList.RemoveAt (randomIndex);

		}
		return randomList;

	}




	void Start ()
	{
		its = itemPrefab.GetComponent<ItemShell> ();

		bossSpots = GameObject.FindGameObjectsWithTag ("BossSpot");
		items = GameObject.FindGameObjectsWithTag ("Item");

		ItemContainer ic = ItemContainer.Load (path);
		newList = ShuffleList (ic.items);
		for (i = 0; i < bossSpots.Length; i++) {
			if (bossSpots [i].name == "Boss") {
				Instantiate (itemPrefab, bossSpots [i].transform.position + new Vector3 (0, 6, 0), transform.rotation, bossSpots [i].transform);

				its.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Weapons/Sprite" + newList [i].Sprite.ToString ());
				its.name = newList [i].name;
				its.Melee = newList [i].Melee;
				its.Ranged = newList [i].Ranged;
				its.Magic = newList [i].Magic;
				its.Armor = newList [i].Armor;
				its.Speed = newList [i].Speed;
				its.Resist = newList [i].Resist;
				StartCoroutine (its.Checker ());
			}
		}

		}
	void Update(){


	}
}