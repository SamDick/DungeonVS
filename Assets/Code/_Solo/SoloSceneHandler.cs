using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SoloSceneHandler: MonoBehaviour {
	public float dungeonTimer = 6;
	public bool versus;
	public bool roundOver;
	GameObject soloPlayer;
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
		
		if (soloPlayer == null) {
			soloPlayer = GameObject.Find ("SoloPlayer(Clone)");
		}

		if (versus == false) {


				dungeonTimer -= Time.deltaTime;

			}
			

		if (versus == true) {
			if (roundOver == true) {

				SceneManager.LoadScene ("SoloDungeon");
				if (SceneManager.GetActiveScene().name == "SoloDungeon") {
					StartCoroutine (LoadMaze ());
					soloPlayer.transform.position = new Vector3 (0, 5.96f, 0);

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
