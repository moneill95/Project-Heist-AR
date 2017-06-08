using UnityEngine;
using System.Collections;

public class SafePlayerCommand : MonoBehaviour {

	public Transform mTarget;
	public float mTravelTime;
	public GameObject playerIcon;

	Vector3 mStartPos;
	Vector3 mEndPos;

	float mTimer;

	private bool KeyHit = false;



	// Use this for initialization
	void Start () {
		mStartPos = transform.position;
		mEndPos = mTarget.position;
		mTimer = 0.0f;



	}

	// Update is called once per frame
	void Update () {



		if (Input.GetKeyDown ("s")){
			print ("Key Down active");
			KeyHit = true;
		}

		if (KeyHit == true) {

			mTimer += Time.deltaTime;
			transform.position = Vector3.Lerp (mStartPos, mEndPos, mTimer / mTravelTime);

		}


	}

}
