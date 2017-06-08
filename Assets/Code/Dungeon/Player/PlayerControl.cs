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
	float test;

	void Awake () {
		cam = GetComponentInChildren<Camera> ();

		if (transform.position == new Vector3 (0, 6, 0)) {
			playerNumber = 1;
			cam.rect = new Rect (0, 0.5f, 1, 0.5f);
		} else {
			playerNumber = 2;
			cam.rect = new Rect (0, 0, 1, 0.5f);

		}
	lookRight = new Vector3(0,90,0);
	}
	

	void Update () {
		if (sm == null) {
			sm = GameObject.Find ("Manager(Clone)").GetComponent<StatsManager> ();
		}

		if (sm.battle == false) {
			

			Vector3 fwd = transform.forward;
			Physics.Raycast (transform.position, fwd, out hit);


			if (Input.GetAxis ("Vertical" + playerNumber) == -1 && moveLock == false) {
				if (Physics.Raycast (transform.position, fwd, out hit) && hit.collider.gameObject.layer == 9 && moveLock == false) {

					nextSpot = hit.collider.transform.position;

				}
				moveLock = true;
				StartCoroutine (Mover ());

			}

			if (Input.GetAxis ("Vertical" + playerNumber) == 1 && moveLock == false) {
				nextRot += 180;

				moveLock = true;
				StartCoroutine (Turner ());
			}
			// joystick buttons instead of making axis'. Perhaps making axes is not the wisest. Make the keycode.
			if (Input.GetAxis ("Horizontal" + playerNumber) == 1 && moveLock == false) {
					
					nextRot += 90;
				
			moveLock = true;
			StartCoroutine (Turner ());
		}
			if (Input.GetAxis ("Horizontal" + playerNumber) == -1 && moveLock == false) {

				nextRot -= 90;

				moveLock = true;
				StartCoroutine (Turner ());
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
			
			transform.position = Vector3.Lerp (transform.position, nextSpot, Time.deltaTime * 25);
			yield return new WaitForEndOfFrame();

		}
		moveLock = false;
		yield return null;

	}
	IEnumerator Turner(){

		transform.rotation = Quaternion.LerpUnclamped (transform.rotation, Quaternion.Euler (0, nextRot, 0), Time.deltaTime * 15);
		yield return new WaitForSeconds (0.8f);

		
		moveLock = false;
		yield return null;

	}
		


}