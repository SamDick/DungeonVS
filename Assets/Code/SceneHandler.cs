using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {
	public float dungeonTimer = 6;
	public bool versus;
	public bool roundOver;
	GameObject dungeonPlayer;
	GameObject player;
	public static GameObject instance;

	void Awake(){
		

		if (GameObject.Find ("Manager(Clone)") == null) {
			Instantiate (Resources.Load ("Manager"), transform.position, transform.rotation, null);
		}

		DontDestroyOnLoad (gameObject);
		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
		}


	}
	void Start () {
		versus = false;

	

	}


	void Update () {
		

		if (player == null) {
			player = GameObject.Find ("VersusPlayer(Clone)");
		}
		if (dungeonPlayer == null) {
			dungeonPlayer = GameObject.Find ("DungeonPlayer(Clone)");
		}

		if (versus == false) {
			
			if (player != null && player.GetComponent<VersusControl> ().playerOther != null) {

				dungeonTimer -= Time.deltaTime;

			}
		}
		
		if (dungeonTimer <= 0) 
		{
			versus = true;
			dungeonTimer = 6;
			SceneManager.LoadScene ("Versus");
			player.GetComponent<VersusBattleControl> ().rolled = false;
		}

		if (versus == true) {
			if (roundOver == true) {
				
				SceneManager.LoadScene ("Dungeon");
				if (SceneManager.GetActiveScene().name == "Dungeon") {
					StartCoroutine (LoadMaze ());
					dungeonPlayer.transform.position = new Vector3 (0, 5.96f, 0);

					roundOver = false;
					versus = false;
				}
			}
		}
	}
	IEnumerator LoadMaze(){
		yield return new WaitForSeconds (1f);
		Instantiate (Resources.Load ("Maze"), Vector3.zero, transform.rotation);

		yield break;
	}
}
