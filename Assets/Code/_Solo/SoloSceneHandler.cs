using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SoloSceneHandler: MonoBehaviour {
	public float dungeonTimer;
	GameObject soloPlayer;
	public static GameObject instance;
	Scene scene;

	void Awake(){




		if (instance) {
			Destroy (gameObject);
		} else {
			instance = gameObject;
			DontDestroyOnLoad (gameObject);
		}


	}
	void Start () {
		scene = SceneManager.GetActiveScene();
	}

	void Update ()
	{
		
		if (soloPlayer == null) {
			soloPlayer = GameObject.Find ("SoloPlayer(Clone)");
		}

		dungeonTimer += Time.deltaTime;


	}

	public IEnumerator ResetScene(){

		SceneManager.LoadScene ("RelicDungeon");
		yield break;

	}
}
