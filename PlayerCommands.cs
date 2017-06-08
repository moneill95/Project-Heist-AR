using UnityEngine;
using System.Collections;

public class PlayerCommands : MonoBehaviour {

	public Transform mTarget;
	public float mTravelTime;
	public GameObject playerIcon;
	//public GameObject TrapAlert;
	//public GameObject TrapOK;

	Vector3 mStartPos;
	Vector3 mEndPos;

	float mTimer;

	private bool KeyHit = false;

	//public float lifetime;





	// Use this for initialization
	void Start () {
		mStartPos = transform.position;
		mEndPos = mTarget.position;
		mTimer = 0.0f;


	
	}
	
	// Update is called once per frame
	void Update () {



		if (Input.GetKeyDown (KeyCode.Space)) {
			print ("Key Down active");
			KeyHit = true;
		}

		if (KeyHit == true) {

			mTimer += Time.deltaTime;
			transform.position = Vector3.Lerp (mStartPos, mEndPos, mTimer / mTravelTime);
		}

	
		if (Input.GetKeyDown ("p")) {
			print ("disable camera");
			RobberStart.isCameraActive = 0;
		}

		if (Input.GetKeyDown ("o")) {
			print ("disable alarm");
			RobberStart.isAlarmActive = 0;
		}

		/*if (RobberStart.isCameraActive == 0 && RobberStart.isAlarmActive == 0) {
			print ("no traps");
			TrapOK.SetActive (true);
			Destroy (TrapAlert);
			lifetime -= Time.deltaTime;

			if (lifetime < 0)
			{
				Destroy(TrapOK); //destroys object thrown after a period of time 

			}


		}*/
	}

}
