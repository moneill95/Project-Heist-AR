using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class GameManager : MonoBehaviour
	{
		
		public GameObject BankArea;
		//public GameObject UpstairsOffices;
		public GameObject UndergroundSafe;
		public static int securityPadLife;
		public static int DepositBoxLife;
		public static int DepositBoxLife2;
		public static int SafeLife;
		public GameObject SafeButton;
		public GameObject UpstairsButton;


		void Start()
		{
		
			BankArea.SetActive (true);
			//UpstairsOffices.SetActive (false);
			UndergroundSafe.SetActive (false);
			securityPadLife = 3;
			DepositBoxLife = 3;
			DepositBoxLife2 = 3;
			SafeLife = 3;
		}



		public void UpstairOffices() 
		{
			//PlayerPrefs.SetInt("pAlarm", isAlarmOn);	
			//SceneManager.LoadScene(RobberStart);

			BankArea.SetActive (true);
			//UpstairsOffices.SetActive (true);
			UndergroundSafe.SetActive (false);
			SafeButton.SetActive (true);
			UpstairsButton.SetActive (false);
			
		}

		public void DownstairsSafe() 
		{
			//PlayerPrefs.SetInt("pAlarm", isAlarmOn);	
			//SceneManager.LoadScene(RobberStart);

			BankArea.SetActive (false);
			//UpstairsOffices.SetActive (false);
			UndergroundSafe.SetActive (true);
			SafeButton.SetActive (false);
			UpstairsButton.SetActive (true);
		}
		
		public static void SecurityLoseLife(int LosesLife){

		securityPadLife -= LosesLife;

		}

		public static void DepositBoxLoseLife(int LosesLife){

		DepositBoxLife -= LosesLife;

		}

		public static void DepositBoxLoseLife2(int LosesLife){

		DepositBoxLife2 -= LosesLife;

	}

		public static void SafeLoseLife(int LosesLife){

		SafeLife -= LosesLife;

		}

	}

