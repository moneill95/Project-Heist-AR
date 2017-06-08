using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankAreaSlientAlarm : MonoBehaviour {

	public static float CountdownTimerToAlarm = 30.0f;
	public static Text text;
	public static int Timer;
	public static int StartTimer;

	// Use this for initialization
	void Start () {

		text = GetComponent<Text> ();

		if(RobberStart.isSlientAlarmActive == 1){
			StartTimer = 1;
		}
			

		
	}
	
	// Update is called once per frame
	void Update () {
		if (StartTimer == 1) {
			Debug.Log ("Countdown Started");

			CountdownTimerToAlarm -= Time.deltaTime;
			text.text = " " + CountdownTimerToAlarm.ToString("f0");

		}

		if (CountdownTimerToAlarm <= 0) {
			StartTimer = 2;
			CountdownTimerToAlarm = 0;
			Debug.Log ("Alarm Active");
	}
}
}
