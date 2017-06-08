using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UpstairstoMain : MonoBehaviour {

	public string RobberStart;
	public static int isCameraActive;

	/*public GameObject Camera;

	public bool CameraOn;

	public int isCameraOn;

	public GameObject Alarm;
	public GameObject TripAlarm;

	public bool AlarmOn;
	public int isAlarmOn;

	public bool TrapInRoom;
	public int isTrapInRoom;

	int APDamageCamera = 3;
	int APDamageAlarm = 2;*/


	// Use this for initialization
	void Start () {

		isCameraActive = PlayerPrefs.GetInt("pCamera");


	}

	// Update is called once per frame
	void Update () {


		/*if (CameraOn == true) {
			isCameraOn = 1;
			Camera.SetActive (true);
		}
		if (CameraOn == false) {
			isCameraOn = 0;
			Camera.SetActive (false);
		}
		if (Input.GetKeyDown ("a")) {
			CameraOn = true;
			DefenderAPpoints.DecreaseAPpoints (APDamageCamera);
			print ("Camera Active");
		}

		if (AlarmOn == true) {
			isAlarmOn = 1;
			Alarm.SetActive (true);
			TripAlarm.SetActive (true);
		}
		if (AlarmOn == false) {
			isAlarmOn = 0;
			Alarm.SetActive (false);
			TripAlarm.SetActive (false);
		}
		if (Input.GetKeyDown ("d")) {
			AlarmOn = true;
			DefenderAPpoints.DecreaseAPpoints (APDamageAlarm);
			print ("Alarm Active");
		}

		if (isCameraOn == 1 || isAlarmOn == 1) {
			TrapInRoom = true;
			isTrapInRoom = 1;
		} else {
			TrapInRoom = false;
			isTrapInRoom = 0;
		}




		PlayerPrefs.GetInt ("pCamera", isCameraOn);
		PlayerPrefs.GetInt ("pAlarm", isAlarmOn);
		PlayerPrefs.GetInt ("pTrapAlert", isTrapInRoom);*/

	}

	public void DefenderReadyButton() 
	{
		//PlayerPrefs.SetInt("pCamera", isCameraOn);	
		//PlayerPrefs.SetInt("pAlarm", isAlarmOn);
		//PlayerPrefs.SetInt("pTrapAlert", isTrapInRoom);
		Debug.Log("egweewweg");
		PlayerPrefs.SetInt("pCamera", isCameraActive);	
		SceneManager.LoadScene(RobberStart);
	}
}
