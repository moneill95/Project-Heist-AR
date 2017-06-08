using UnityEngine;
using System.Collections;

public class LoadDefenderReadyTraps : MonoBehaviour {

	//public GameObject Camera;
	public static int isCameraActive;


	// Use this for initialization
	void Start () {

		isCameraActive = PlayerPrefs.GetInt("pCamera");






	}

	// Update is called once per frame
	void Update () {

		if (isCameraActive == 1) {
			Debug.Log ("Camera Found");
		} else {
			Debug.Log ("Camera Not Found");
		}

	




	}
		

}

