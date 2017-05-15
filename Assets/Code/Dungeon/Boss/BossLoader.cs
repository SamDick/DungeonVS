using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossLoader : MonoBehaviour {

	public const string path = "bosses";

	public GameObject[] bossSpots;
	int i;
	int k;


	public List<BossScript> newList;




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
		

		bossSpots = GameObject.FindGameObjectsWithTag ("BossSpot");


		BossContainer bc = BossContainer.Load (path);
		newList = ShuffleList (bc.bosses);

		for (int i = 0; i < bossSpots.Length; i++) {


			BossShell bs = bossSpots[i].GetComponent<BossShell> ();
			bs.name = newList [i].name;
			bs.HP = newList [i].HP;
			bs.melee =newList[i].Melee;
			bs.ranged = newList[i].Ranged;
			bs.magic = newList[i].Magic;
			bs.armor = newList[i].Armor;
			bs.speed = newList[i].Speed;
			bs.resist = newList[i].Resist;
			bs.model = newList [i].Model;
			bs.meTimer = newList[i].meTimer;
			bs.raTimer = newList[i].raTimer;
			bs.maTimer = newList[i].maTimer;
			Object temp = Resources.Load ("Models/" + bs.model);
			Instantiate (temp, bossSpots [i].transform.position, transform.rotation, bossSpots[i].transform);

			//StartCoroutine (bs.Checker ());
		}
	}
}
