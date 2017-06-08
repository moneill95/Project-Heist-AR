using UnityEngine;
using System.Collections;

public class RobberStart : MonoBehaviour {

	public GameObject Camera;
	public static int isCameraActive;

	public GameObject Alarm;
	//public GameObject TripAlarm;
	public static int isAlarmActive;

	public GameObject SlientAlarm;
	public static int isSlientAlarmActive;

	//public GameObject TrapAlert;
	public static int isTrapAlert;

	public GameObject SafeAreaCamera;
	public static int isSafeAreaCameraActive;

	public GameObject SecurityPad;
	public static int isSecurityPadActive;

	public GameObject DepositBoxStrongLocks;
	public static int isDepBoxStrongLocksActive;

	public GameObject StrongSafeLocks;
	public static int isStrongSafeLocksActive;




	//public GameObject	TrapOK;

	public float lifetime;

	// Use this for initialization
	void Start () {

		isCameraActive = PlayerPrefs.GetInt("pCamera");
		isAlarmActive = PlayerPrefs.GetInt("pAlarm");
		isSlientAlarmActive = PlayerPrefs.GetInt ("pBankAreaSlientAlarm");

		isSafeAreaCameraActive = PlayerPrefs.GetInt("pSafeCamera");
		isSecurityPadActive = PlayerPrefs.GetInt("pSecurityPad");
		isDepBoxStrongLocksActive = PlayerPrefs.GetInt("pSecurityStrongLock");
		isStrongSafeLocksActive = PlayerPrefs.GetInt("pStrongSafeLock");




	
	}
	
	// Update is called once per frame
	void Update () {

		if (isCameraActive == 1) {
			Camera.SetActive (true);
			Debug.Log ("Camera Active");
		} else {
			Camera.SetActive (false);
		}

		if (isAlarmActive == 1) {
			Alarm.SetActive (true);
			Debug.Log ("Alarm Active");
			//TripAlarm.SetActive (true);
		} else {
			Alarm.SetActive (false);
			//TripAlarm.SetActive (false);

		}

		if (isSlientAlarmActive == 1) {
			SlientAlarm.SetActive (true);
			Debug.Log ("Slient Alarm Active");
			//TripAlarm.SetActive (true);
		} else {
			SlientAlarm.SetActive (false);
			//TripAlarm.SetActive (false);

		}

		if (isSafeAreaCameraActive == 1) {
			//SlientAlarm.SetActive (true);
			Debug.Log ("Safe Camera Active");
			//TripAlarm.SetActive (true);
		} else {
			//SlientAlarm.SetActive (false);
			//TripAlarm.SetActive (false);
			Debug.Log ("Safe Camera deActive");

		}

		if (isSecurityPadActive == 1) {
			//SlientAlarm.SetActive (true);
			Debug.Log ("Security Pad Active");
			//TripAlarm.SetActive (true);
		} else {
			//SlientAlarm.SetActive (false);
			//TripAlarm.SetActive (false);
			Debug.Log ("Security Pad deActive");

		}

		if (isDepBoxStrongLocksActive == 1) {
			//SlientAlarm.SetActive (true);
			Debug.Log ("DepBox Strong Locks Active");
			//TripAlarm.SetActive (true);
		} else {
			//SlientAlarm.SetActive (false);
			//TripAlarm.SetActive (false);
			Debug.Log ("DepBox Strong Locks deActive");

		}

		if (isStrongSafeLocksActive == 1) {
			//SlientAlarm.SetActive (true);
			Debug.Log ("Strong Safe Locks Active");
			//TripAlarm.SetActive (true);
		} else {
			//SlientAlarm.SetActive (false);
			//TripAlarm.SetActive (false);
			Debug.Log ("Strong Safe Locks deActive");

		}
		//if (isCameraActive == 1 || isAlarmActive == 1) {
		//	TrapAlert.SetActive (true);
		//} else {
		//	TrapAlert.SetActive (false);
		//}

	//	if (RobberStart.isCameraActive == 0 && RobberStart.isAlarmActive == 0) {
			//noTraps();

	//	}


	
	}

	/*public void noTraps(){
		print ("no traps");
		//TrapOK.SetActive (true);
		lifetime -= Time.deltaTime;

		if (lifetime < 0)
		{
		//	TrapOK.SetActive(false); //destroys object thrown after a period of time 

		}*/

	}

