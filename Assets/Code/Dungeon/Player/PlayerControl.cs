using UnityEngine;
using System.Collections;

public class PlayerControl: MonoBehaviour {
	int playerNumber;
	StatsManager sm;
	public float nextRot;
	public Vector3 nextSpot;
	public bool moveLock;
	RaycastHit rhit;
	RaycastHit hit;
	Vector3 lookRight;
	Camera cam;

	void Awake () {
		cam = GetComponentInChildren<Camera> ();

		if (transform.position == new Vector3 (0, 6, 0)) {
			playerNumber = 0;
			cam.rect = new Rect (0, 0.5f, 1, 0.5f);
		} else {
			playerNumber = 1;
			cam.rect = new Rect (0, 0, 1, 0.5f);

		}
	lookRight = new Vector3(0,90,0);
	}
	

	void Update () {
		if (sm == null) {
			sm = GameObject.Find ("Manager(Clone)").GetComponent<StatsManager> ();
		}

		if (sm.battle == false){

		Vector3 fwd = transform.forward;
		Physics.Raycast (transform.position, fwd, out hit);


		if (
				//Input.GetKeyDown (KeyCode.W) && moveLock != true & playerNumber == 0 ||
				Input.GetAxis("Horizontal" + playerNumber) >= 0) {
			if (Physics.Raycast(transform.position, fwd, out hit) && hit.collider.gameObject.layer == 9 && moveLock == false){

				nextSpot = hit.collider.transform.position;

			}

			StartCoroutine (Mover ());

		


		} 
		if (Input.GetKeyDown (KeyCode.Space)) {

		}


			// joystick buttons instead of making axis'. Perhaps making axes is not the wisest. Make the keycode.
			if (Input.GetAxis()) {
			
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