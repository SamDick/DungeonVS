using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AttackSelect : MonoBehaviour {

	GameObject player;

	public bool readyFight = false;
	public List<int> AttackOrder = new List<int> ();
	GameObject me;
	GameObject ra;
	GameObject ma;
	GameObject first;
	GameObject second;
	GameObject third;

	void Awake(){
		
		me = GameObject.Find ("MeleeCD");
		ra = GameObject.Find ("RangedCD");
		ma = GameObject.Find ("MagicCD");
		first = GameObject.Find ("firstmove");
		second = GameObject.Find ("secondmove");
		third = GameObject.Find ("thirdmove");


	}

	void Update(){
		me = GameObject.Find ("MeleeCD");
		ra = GameObject.Find ("RangedCD");
		ma = GameObject.Find ("MagicCD");
		first = GameObject.Find ("firstmove");
		second = GameObject.Find ("secondmove");
		third = GameObject.Find ("thirdmove");

		if (SceneManager.GetActiveScene ().name == "Versus") {

			if (Input.GetKeyDown (KeyCode.UpArrow)) {
			
				if (readyFight == false) {
					
					if (AttackOrder.Count == 0) {
						GameObject move1 = GameObject.Instantiate (me, first.transform.position, transform.rotation, first.transform) as GameObject; 
						move1.name = "move1";
					}				
					if (AttackOrder.Count == 1) {
						GameObject move2 = GameObject.Instantiate (me, second.transform.position, transform.rotation, second.transform)as GameObject; 
						move2.name = "move2";
					}
					if (AttackOrder.Count == 2) {
						GameObject move3 = GameObject.Instantiate (me, third.transform.position, transform.rotation, third.transform)as GameObject;
						move3.name = "move3";
					}
					AttackOrder.Add (0);
				}
			}
			
		

		if (GameObject.Find ("NetworkController").GetComponent<SceneHandler> ().versus == true) {
			if (AttackOrder.Count >= 3) {
				readyFight = true;

			}
		}
	}
	}

	public void MeleeAttack()
	{
		if (readyFight == false){
			AttackOrder.Add (0);
	}

	}public void RangedAttack()
	{
		if (readyFight == false){
			AttackOrder.Add (1);
		}
	}
	public void MagicAttack()
	{
		if (readyFight == false){
			AttackOrder.Add (2);
		}
	}
}
