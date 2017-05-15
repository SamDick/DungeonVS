using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {



	public enum RotationAxes {MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensX = 7.5F;
	public float sensY = 7.5F;
	public float minX = -360f;
	public float maxX = 360F;
	public float minY = -60F;
	public float maxY = 60F;
	float rotationY = 0F;
	float sprint;

	float maxStamina;
	float stamina;
	float speed;
	Camera cam;

	Rigidbody rb;

	void Start () {
		maxStamina = 4;
		stamina = 1;
		rb = GetComponent<Rigidbody> ();
		cam = GetComponentInChildren<Camera> ();
		sprint = 1;
		speed = 20;
	}

	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space) && transform.position.y <= 3.1f ) {
			
			rb.AddForce (Vector3.up * 10000);

		}
		transform.position += transform.forward * (Input.GetAxis ("Vertical") * speed * Time.smoothDeltaTime * sprint);
		transform.position += transform.right * (Input.GetAxis ("Horizontal") * speed * Time.smoothDeltaTime);
		
		if (axes == RotationAxes.MouseXAndY) {
			float rotX = transform.eulerAngles.y + Input.GetAxis ("Mouse X") * sensX;
			rotationY += Input.GetAxis ("Mouse Y") * sensY;
			rotationY = Mathf.Clamp (rotationY, minY, maxY);
			transform.eulerAngles = new Vector3 (0, rotX, 0);
			cam.transform.eulerAngles = new Vector3 (-rotationY, rotX, 0);
		} 
		else if (axes == RotationAxes.MouseX) {
			cam.transform.Rotate (0, Input.GetAxis ("Mouse X") * sensX, 0);
		}
		else
		{
			rotationY += Input.GetAxis ("Mouse Y") * sensY;
			rotationY = Mathf.Clamp (rotationY, minY, maxY);
			transform.eulerAngles = new Vector3 (-rotationY, transform.localEulerAngles.y, 0);
		}
	}
}
