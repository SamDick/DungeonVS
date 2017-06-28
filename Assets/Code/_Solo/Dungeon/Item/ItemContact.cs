using UnityEngine;
using System.Collections;

public class ItemContact : MonoBehaviour {

	Vector3 invPos;
	Inventory inv;
	void Start () {
		inv = GameObject.Find ("SoloManager").GetComponent<Inventory> ();
		GetComponent<BoxCollider> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.parent != null){
			if (transform.parent.GetComponent<BossShell> () != null) {
				if (transform.parent.GetComponent<BossShell> ().HP <= 0) {
					GetComponent<BoxCollider> ().enabled = true;
					GetComponent<SpriteRenderer> ().enabled = true;
					if (transform.rotation != GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ().rotation) {
						transform.rotation = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ().rotation;
					}
				}

			}
		}


	
	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Player") {
			inv.newItemGO = gameObject;

		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			invPos = transform.position;
			inv.newItemGO = null;

		}
	}
}
