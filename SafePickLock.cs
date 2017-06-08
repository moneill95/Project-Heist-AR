using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePickLock : MonoBehaviour {

	public static float CardNo1;
	float SafeNo;
	int LosesLife;
	private bool isLifeEqual;
	//public GameObject SecurityDoor;

	public GameObject JamesD;
	private Animator anim;

	public int cashinVault;

	public AudioClip KaChing;
	private AudioSource source;

	void Awake(){
		source = GetComponent<AudioSource> ();
	}


	// Use this for initialization
	void Start () {


		SafeNo = Random.Range (1, 4); //random number pick to enter for safe
		print ("SafeNo = " + SafeNo);
		LosesLife = 1; // number of life lost after failed attempt


		anim = JamesD.GetComponent<Animator> (); // animator

	}

	// Update is called once per frame
	void Update () {

		if (ARSecurityPadPick.isSecurityDoorOpen == 1 && TestcollideronCashDesk.stayVault == 1) { // security door has to be open and inside vault collider to work
			print ("Depsit1 ok");

			if (SafeNo == CardNo1) { // if card no. equals safe no. cash total is added to total animation is played and soound is played 
				print ("open door");
				ScoreManager.AddCashtoTotal (cashinVault);
				anim.SetTrigger ("returnToSafeSpot");
				source.PlayOneShot (KaChing);
				//SecurityDoor.SetActive (false);
			}

			if (CardNo1 == 1 && SafeNo != 1) { // if card no and safe no not equal isLifeEqual is called 
				print ("Lose a Life");
				isLifeEqual = true;
				//GameManager.LoseLife (LosesLife);
				//print ("Life = " + GameManager.Life);
			}

			if (CardNo1 == 2 && SafeNo != 2) {
				print ("Lose a Life");
				isLifeEqual = true;
			}

			if (CardNo1 == 3 && SafeNo != 3) {
				print ("Lose a Life");
				isLifeEqual = true;
			}



			if (isLifeEqual == true) {// players loses a life 
				GameManager.SafeLoseLife (LosesLife);
//			print ("Life = " + GameManager.SafeLoseLife);
				CardNo1 = 0;
				isLifeEqual = false;
				print ("DepositBOXLife " + GameManager.DepositBoxLife);
			}
			

			if (GameManager.SafeLife == 0) { // if life = zero player loses 30 seconds
				print ("Lose 30 secs");
				CountdownTimerTIlPoliceArrive.countdownTimerTilPolice -= 30;
			}
		}


	}


}
