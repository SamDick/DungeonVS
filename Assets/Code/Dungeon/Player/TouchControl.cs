using UnityEngine;
using System.Collections;

public class TouchControl : MonoBehaviour {

	StatsManager sm;
	public float nextRot;
	public Vector3 nextSpot;
	public bool moveLock;
	RaycastHit rhit;
	RaycastHit hit;
	Vector3 lookRight;

	void Awake () {
	lookRight = new Vector3(0,90,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (sm == null) {
			sm = GameObject.Find ("Manager(Clone)").GetComponent<StatsManager> ();
		}

		if (sm.battle == false){

		Vector3 fwd = transform.forward;
		Physics.Raycast (transform.position, fwd, out hit);

		if (Input.GetKeyDown (KeyCode.W) && moveLock != true ) {
			if (Physics.Raycast(transform.position, fwd, out hit) && hit.collider.gameObject.layer == 9 && moveLock == false){

				nextSpot = hit.collider.transform.position;

			}

			StartCoroutine (Mover ());

		


		} 
		if (Input.GetKeyDown (KeyCode.Space)) {

		}



		if (Input.GetKeyDown (KeyCode.D)) {
			
			nextRot += 90;
		}
		if (transform.rotation.y != nextRot) {
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0, nextRot, 0), Time.deltaTime * 4);


		}
		if (Input.GetKeyDown (KeyCode.A)) {

			nextRot -= 90;
		}
		if (transform.rotation.y != nextRot) {
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0, nextRot, 0), Time.deltaTime * 5);


		}

		if (Input.GetKeyDown (KeyCode.A)) {

		} 
	
	}
	}
	IEnumerator Mover (){

		while (transform.position != nextSpot) {
			
			transform.position = Vector3.Lerp (transform.position, nextSpot, Time.deltaTime * 10);
			yield return new WaitForEndOfFrame();
		}
		yield return null;

	}


}