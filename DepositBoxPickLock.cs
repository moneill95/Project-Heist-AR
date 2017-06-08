using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositBoxPickLock : MonoBehaviour {

	public static float CardNo1;
	float DepositBoxNo;
	int LosesLife;
	private bool isLifeEqual;


	public static float CardNo2;
	float DepositBoxNo2;
	int LosesLife2;
	private bool isLifeEqual2;
	//public GameObject SecurityDoor;

	public GameObject JamesD;
	private Animator anim;


	public int cashinDepositBox1;
	public int cashinDepositBox2;

	public AudioClip KaChing;
	private AudioSource source;

	void Awake(){
		source = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {


		DepositBoxNo = Random.Range (1, 4);
		print ("DepositBox1No = " + DepositBoxNo);
		LosesLife = 1;

		DepositBoxNo2 = Random.Range (1, 4);
		print ("DepositBox2No = " + DepositBoxNo2);
		LosesLife2 = 1;


		anim = JamesD.GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {

		if (ARSecurityPadPick.isSecurityDoorOpen == 1 && TestcollideronCashDesk.stayDeBox1 == 1) {
			print ("Depsit1 ok");

			if (DepositBoxNo == CardNo1) {
				print ("open door");
				ScoreManager.AddCashtoTotal (cashinDepositBox1);
				anim.SetTrigger ("returnToSafeSpot");
				source.PlayOneShot (KaChing);
				//SecurityDoor.SetActive (false);
			}

			if (CardNo1 == 1 && DepositBoxNo != 1) {
				print ("Lose a Life");
				isLifeEqual = true;
				//GameManager.LoseLife (LosesLife);
				//print ("Life = " + GameManager.Life);
			}

			if (CardNo1 == 2 && DepositBoxNo != 2) {
				print ("Lose a Life");
				isLifeEqual = true;
			}

			if (CardNo1 == 3 && DepositBoxNo != 3) {
				print ("Lose a Life");
				isLifeEqual = true;
			}

			if (isLifeEqual == true) {
				GameManager.DepositBoxLoseLife (LosesLife);
				//print ("Life = " + GameManager.DepositBoxLoseLife);
				CardNo1 = 0;
				isLifeEqual = false;
				print ("DepositBOXLife " + GameManager.DepositBoxLife);
			}

			if (GameManager.DepositBoxLife == 0) {

				CountdownTimerTIlPoliceArrive.countdownTimerTilPolice -= 30;
			}

		}

		if (ARSecurityPadPick.isSecurityDoorOpen == 1 && TestcollideronCashDesk.stayDeBox1 == 1) {
			print ("Depsit2 ok");

			if (DepositBoxNo2 == CardNo2) {
				ScoreManager.AddCashtoTotal (cashinDepositBox2);
				anim.SetTrigger ("returnToSafeSpot");
				source.PlayOneShot (KaChing);
			}

			if (CardNo2 == 1 && DepositBoxNo2 != 1) {
				print ("Lose a Life");
				isLifeEqual = true;
				//GameManager.LoseLife (LosesLife);
				//print ("Life = " + GameManager.Life);
			}

			if (CardNo2 == 2 && DepositBoxNo2 != 2) {
				print ("Lose a Life");
				isLifeEqual = true;
			}

			if (CardNo2 == 3 && DepositBoxNo2 != 3) {
				print ("Lose a Life");
				isLifeEqual = true;
			}

			if (isLifeEqual == true) {
				GameManager.DepositBoxLoseLife2 (LosesLife2);
				//print ("Life = " + GameManager.DepositBoxLoseLife);
				CardNo2 = 0;
				isLifeEqual = false;
				print ("DepositBOX2Life " + GameManager.DepositBoxLife2);
			}

			if (GameManager.DepositBoxLife2 == 0) {

				CountdownTimerTIlPoliceArrive.countdownTimerTilPolice -= 30;
			}

		}
	}

	}



