using UnityEngine;
using System.Collections;

public class NetworkControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			byte evCode = 0;
			byte[] content = new byte[]{ 10 };
			bool reliable = true;
		PhotonNetwork.RaiseEvent (evCode, content, reliable, null);

	}
}
