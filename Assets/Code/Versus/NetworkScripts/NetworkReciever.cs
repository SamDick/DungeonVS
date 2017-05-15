using UnityEngine;
using System.Collections;

public class NetworkReciever : MonoBehaviour {

	void Awake(){
		PhotonNetwork.OnEventCall += this.OnEvent;
	}
	private void OnEvent(byte eventcode, object content, int senderid){
		if (eventcode == 0){
			Debug.Log (content);
		}
		if (eventcode == 2){
			Debug.Log (content);
		}
	}
}
