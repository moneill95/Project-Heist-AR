using UnityEngine;
using System.Collections;

public class PickSafe : MonoBehaviour {

	public GameObject Safe;
	public int CashInSafe;


	// Use this for initialization
	void Start () {



	}

	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter2D(Collider2D other)
	{		
		if (other.tag == "Safe") { //when thrown object hits enemy, gives damage to enemy in the enemyhealth manager script
			print ("Safe Open");
			ScoreManager.AddCashtoTotal(CashInSafe);
			Destroy (Safe);
			//mTimer += Time.deltaTime;
			//transform.position = Vector3.Lerp (returnPos, endPos, mTimer / mTravelTime);
		}



	}


}
