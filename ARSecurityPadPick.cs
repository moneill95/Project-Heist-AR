using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSecurityPadPick : MonoBehaviour {

	public static float CardNo1;
	float SecurityPadNo;
	int LosesLife;
	private bool isLifeEqual;
	public GameObject SecurityDoor;
	public static int isSecurityDoorOpen;

	// Use this for initialization
	void Start () {


		SecurityPadNo = Random.Range (1, 4);
		print ("SecurityPadNo = " + SecurityPadNo);
		LosesLife = 1;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (SecurityPadNo == CardNo1) {
			print ("open door");
			SecurityDoor.SetActive (false);
			isSecurityDoorOpen = 1;
		}

		if (CardNo1 == 1 && SecurityPadNo != 1){
			print ("Lose a Life");
			isLifeEqual = true;
			//GameManager.LoseLife (LosesLife);
			//print ("Life = " + GameManager.Life);
		}

		if (CardNo1 == 2 && SecurityPadNo != 2){
			print ("Lose a Life");
			isLifeEqual = true;
		}

		if (CardNo1 == 3 && SecurityPadNo != 3){
			print ("Lose a Life");
			isLifeEqual = true;
		}

		if (isLifeEqual == true) {
			GameManager.SecurityLoseLife (LosesLife);
			print ("Life = " + GameManager.securityPadLife);
			CardNo1 = 0;
			isLifeEqual = false;
			print ("DepositBOXLife " + GameManager.DepositBoxLife);
		}
			


		if (GameManager.securityPadLife == 0) {
			print ("Lose 30 secs");
			CountdownTimerTIlPoliceArrive.countdownTimerTilPolice -= 30;
		}
			
	}
		

}
