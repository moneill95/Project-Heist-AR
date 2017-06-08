using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestcollideronCashDesk : MonoBehaviour {

	public int CashOnTable;
	public GameObject cash;
	public int takeaway;
	public GameObject PersoninCrowd;
	public int CashonPerson;

	public int cashinDepositBox1;
	public int cashinDepositBox2;
	public int cashinVault;
	public int cashinSafeArea;

	public GameObject Teller;
	private Animator animTeller;

	public GameObject BankArea;
	//public GameObject UpstairsOffices;
	public GameObject UndergroundSafe;

	public GameObject PoliceTimer;
	public GameObject Timer;

	public static int stayDeBox1;
	public static int stayDeBox2;
	public static int stayVault;
	public static int StartTimer;
	public static int LoseTime;

	public AudioClip KaChing;
	private AudioSource source;


	void Awake(){
		source = GetComponent<AudioSource> ();

	}

	// Use this for initialization
	void Start () {

		animTeller = Teller.GetComponent<Animator> ();
		SecurityPadUI.securitypadText.enabled = false;
		DeBox1UI.deBox1Text.enabled = false;
		DeBox2UI.deBox2Text.enabled = false;
		VaultUI.VaultText.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("g")) {
			Debug.Log ("g pressed");
			animTeller.SetTrigger ("subdueTellerWalk");

		}
	
	}

	void OnTriggerEnter(Collider other)
	{


		if (other.tag == "Cash") { //when thrown object hits enemy, gives damage to enemy in the enemyhealth manager script
			print ("Steal Cash");
			ScoreManager.AddCashtoTotal (CashOnTable);
			source.PlayOneShot (KaChing);
			Destroy (cash);
			//mTimer += Time.deltaTime;
			//transform.position = Vector3.Lerp (returnPos, endPos, mTimer / mTravelTime);
		}

		if (other.tag == "Crowd") {
			print ("Stole money from Crowd");
			ScoreManager.AddCashtoTotal (CashonPerson);


		}

		if (other.tag == "Teller") {
			print ("Subdued Teller");
			animTeller.SetTrigger ("subdueTellerWalk");
			BankAreaSlientAlarm.StartTimer = 3;

		}

		if(other.tag == "GoToSafe"){
			print ("GoToSafe");
			BankArea.SetActive (false);
			UndergroundSafe.SetActive (true);

		}

		if (other.tag == "Camera") {
			print ("Camera Spot");
			if (CountdownTimerTIlPoliceArrive.countdownTimerTilPolice == 300.0f) {
				//CountdownTimerTIlPoliceArrive.countdownTimerTilPolice -= Time.deltaTime;
				PoliceTimer.GetComponent<Image> ().enabled = true;
				Timer.GetComponent<Text> ().enabled = true;
				StartTimer = 1;
			} else if (CountdownTimerTIlPoliceArrive.countdownTimerTilPolice < 300.0f) {
				print ("Lose 30 secs");
				LoseTime = 1;

			}
		}

	}


	  void OnTriggerStay(Collider other){
	  
	  if (other.tag == "DepositBox1") {
			print ("Stay DepositBox1");
			stayDeBox1 = 1;
			print ("staybox = " + stayDeBox1);
			DeBox1UI.deBox1Text.enabled = true;

		}

		if (other.tag == "DepositBox2") {
			print ("Stay DepositBox2");
			stayDeBox2 = 1;
			print ("staybox2 = " + stayDeBox2);
			DeBox2UI.deBox2Text.enabled = true;

		}

		if (other.tag == "Vault") {
			print ("Stay Vault");
			stayVault = 1;
			print ("stayVault = " + stayVault);
			VaultUI.VaultText.enabled = true;

		}

		if (other.tag == "CashSafeArea") {
			print ("Steal Cash Safe Area");
			ScoreManager.AddCashtoTotal (cashinSafeArea);

		}



		if (other.tag == "SecurityPad") {
			print ("SecurityPadLock");
			SecurityPadUI.securitypadText.enabled = true;
		}
			

	}

	void OnTriggerExit(Collider other){

		if (other.tag == "DepositBox1") {
			print ("Exit DepositBox1");
			stayDeBox1 = 0;
			DeBox1UI.deBox1Text.enabled = false;


		}

		if (other.tag == "DepositBox2") {
			print ("Exit DepositBox2");
			stayDeBox2 = 0;
			DeBox2UI.deBox2Text.enabled = false;

		}

		if (other.tag == "Vault") {
			print ("Exit Vault");
			VaultUI.VaultText.enabled = false;
			stayVault = 0;

		}

		if (other.tag == "SecurityPad") {
			SecurityPadUI.securitypadText.enabled = false;
		}

	}







		//if (other.tag == "TripAlarm") { //when thrown object hits enemy, gives damage to enemy in the enemyhealth manager script
		//	print ("Alarm Activated");
		//	ScoreManager.AddCashtoTotal(takeaway);
			//ScoreManager.AddCashtoTotal(CashOnTable);
			//Destroy (cash);
			//mTimer += Time.deltaTime;
			//transform.position = Vector3.Lerp (returnPos, endPos, mTimer / mTravelTime);



	}
