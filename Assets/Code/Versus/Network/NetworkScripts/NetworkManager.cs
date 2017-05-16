using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviour {
	


	void Start () 
	{
		PhotonNetwork.ConnectUsingSettings("DEV");
	}

	void OnJoinedLobby()
	{
		RoomOptions roomOptions = new RoomOptions (){ isVisible = false, maxPlayers = 2 };
		PhotonNetwork.JoinOrCreateRoom ("Room", roomOptions, TypedLobby.Default);
	}

	void OnJoinedRoom()
	{
			Instantiate (Resources.Load("HUD2"), Vector3.zero, transform.rotation, null);
			Instantiate (Resources.Load ("Maze"), Vector3.zero, transform.rotation, null);
			Instantiate (Resources.Load("DungeonPlayer"), new Vector3(0,6,0), Quaternion.identity, null);
			GameObject PlayerAvatar = (GameObject)PhotonNetwork.Instantiate 
				("VersusPlayer",transform.position, Quaternion.identity, 0);
	}
}