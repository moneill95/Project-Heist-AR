using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimerTIlPoliceArrive : MonoBehaviour {

	float slientAlarmCountDown;
	Text Alarmtext;
	public static float	countdownTimerTilPolice = 300.0f;
	//public GameObject SlientAlarmTimer;
	float showAlarmTimer = 30.0f;
	public GameObject PoliceTimer;
	public string Police;

	// Use this for initialization
	void Start () {

		Alarmtext = GetComponent<Text> ();
		Alarmtext.enabled = false;
		PoliceTimer.GetComponent<Image>().enabled = false;


		
	}
	
	// Update is called once per frame
	void Update () {

		if (BankAreaSlientAlarm.StartTimer == 2) {
			
			Debug.Log ("CountDownStarted");
			countdownTimerTilPolice -= Time.deltaTime;
			Alarmtext.text = " " + countdownTimerTilPolice.ToString("f0");
			//Alarmtext.enabled = true;
			showAlarmTimer -= Time.deltaTime;
			if (showAlarmTimer <= 0) {
				PoliceTimer.GetComponent<Image>().enabled = true;
				Debug.Log ("Show Timer");
				Alarmtext.enabled = true;
			
			}
		}

		if (TestcollideronCashDesk.StartTimer == 1) {
			
			Debug.Log ("CountDownStarted");
			countdownTimerTilPolice -= Time.deltaTime;
			Alarmtext.text = " " + countdownTimerTilPolice.ToString("f0");
		}

		if (TestcollideronCashDesk.LoseTime == 1) {

			Debug.Log ("LoseTime");
			countdownTimerTilPolice -= 30.0f;
			TestcollideronCashDesk.LoseTime = 0;
		}



		if (countdownTimerTilPolice < 0) {
			Debug.Log ("Po Po Arrived");
			SceneManager.LoadScene(Police);
		}
		
	}
}

