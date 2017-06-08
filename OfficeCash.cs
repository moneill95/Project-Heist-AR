using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class OfficeCash : MonoBehaviour {

	public GameObject cash;
	public int CashOnTable;
	//public Transform mTarget;
	//public float mTravelTime;

	//public GameObject playerIcon;
	//float mTimer;

	//Vector3 returnPos;
	//Vector3 endPos;

	// Use this for initialization
	void Start () {

	//	returnPos = transform.position;
	//	endPos = mTarget.position;
	//	mTimer = 0.0f;



	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		

	void OnTriggerEnter(Collider other)
	{
		

		if (other.GetComponent<RobberStart>()) { //when thrown object hits enemy, gives damage to enemy in the enemyhealth manager script
			print ("Steal Cash");
			ScoreManager.AddCashtoTotal(CashOnTable);
			Destroy (cash);
			//mTimer += Time.deltaTime;
			//transform.position = Vector3.Lerp (returnPos, endPos, mTimer / mTravelTime);
		}
			


	}

	void OnTriggerExit2D(Collider2D other){

		if (other.tag == "TripAlarm" )  //when thrown object hits enemy, gives damage to enemy in the enemyhealth manager script
			#if UNITY_EDITOR
			EditorUtility.DisplayDialog("Caught","Game Over", "OK");

			print ("Tripped Alarm");
			UnityEditor.EditorApplication.isPlaying = false;
			#endif
			Application.Quit();

	}




}
