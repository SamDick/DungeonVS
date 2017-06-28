using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoloHUD : MonoBehaviour {

	public GameObject bossBar;
	public GameObject healthBar;
	public GameObject cooldownME;
	public GameObject cooldownRA;
	public GameObject cooldownMA;
	GameObject countdown;
	public RectTransform rtBHP;
	RectTransform rtHP;
	RectTransform rtME;
	RectTransform rtRA;
	RectTransform rtMA;
	DungeonBattleControl dbc;
	StatsManager sm;
	GameObject boss;

	void Awake () 
	{	
		
		boss = GetComponent<DungeonBattleControl> ().boss;
		sm = GameObject.Find ("SoloManager").GetComponent<StatsManager> ();
		dbc = GetComponent<DungeonBattleControl> ();
		bossBar = GameObject.Find ("BHP");
		healthBar = GameObject.Find("HP");
		cooldownME = GameObject.Find ("MeleeMeter");
		cooldownRA = GameObject.Find ("RangedMeter");
		cooldownMA = GameObject.Find ("MagicMeter");
		rtBHP = bossBar.GetComponent<RectTransform> ();
		rtHP = healthBar.GetComponent<RectTransform> ();
		rtME = cooldownME.GetComponent<RectTransform> ();
		rtRA = cooldownRA.GetComponent<RectTransform> ();
		rtMA = cooldownMA.GetComponent<RectTransform> ();
		countdown = GameObject.Find ("Countdown");
		rtBHP.localScale = Vector3.zero;

	}

	// Update is called once per frame
	void FixedUpdate () 
	{ boss = dbc.boss;
		if (SceneManager.GetActiveScene ().name == "DungeonSolo") {
			//if (countdown != null) {
				//countdown.GetComponent<Text> ().text = (GameObject.Find ("SoloManager").GetComponent<SoloSceneHandler> ().dungeonTimer.ToString ("F0"));
			//} else {
			//	countdown = GameObject.Find ("Countdown");
			//}
			rtHP.localScale = Vector3.Lerp (rtHP.localScale, new Vector3 (
				(sm.hp / sm.hpTotal)*2.06f,
				2.07f, 0),
				Time.deltaTime * 2);

			if (boss != null) {
				rtBHP.localScale = Vector3.Lerp (rtBHP.localScale, new Vector3 (
					(boss.GetComponent<BossShell> ().HP / boss.GetComponent<BossShell> ().hpTotal) * 2.06f,
					2.07f, 0),
					Time.deltaTime * 2);
			}
			if (dbc.maTimerTotal != 0) {

				rtMA.localScale = new  Vector3 (dbc.maTimer / dbc.maTimerTotal, dbc.maTimer / dbc.maTimerTotal, 1);
				if (rtMA.localScale.y <= 0) {
					rtMA.localScale = new Vector3 (0.333f, 0, 1);
				}
				rtME.localScale = new  Vector3 (dbc.meTimer / dbc.meTimerTotal, dbc.meTimer / dbc.meTimerTotal, 1);
				if (rtME.localScale.y <= 0) {
					rtME.localScale = new Vector3 (0.333f, 0, 1);
				}
				rtRA.localScale = new  Vector3 ( dbc.raTimer / dbc.raTimerTotal, dbc.raTimer / dbc.raTimerTotal, 1);
				if (rtRA.localScale.y <= 0) {
					rtRA.localScale = new Vector3 (0.333f, 0, 1);
				}
			}
		}
	}
}
