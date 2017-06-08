using UnityEngine;
using System.Collections;

public class DefenderStart : MonoBehaviour {

	public bool defenderStart;

	public GameObject defenderStartCanvas;

	public bool defenderFinished;

	//public GameObject defenderFinishedCanvas;

	public bool robberStart;

	//public GameObject robberStartCanvas;

	public GameObject defenderFinishedButton;

	public GameObject robberStartButton;

	public GameObject defenderStartButton;

	public GameObject playerIcon;

	void Start(){
		defenderFinishedButton.SetActive(false);
		robberStartButton.SetActive (false);
		//playerIcon.SetActive (false);
	}

	// Update is called once per frame
	void Update ()  // if player presses escape key it pauses the game 
	{
		if (defenderStart) {
			defenderStartButton.SetActive (false);
			Time.timeScale = 0f;
		}  else {
			defenderStartButton.SetActive (true);
			Time.timeScale = 1f;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			defenderStart = !defenderStart;
		}

		if (defenderFinished == true) {
			defenderFinishedButton.SetActive (true);
		} else {
			defenderFinishedButton.SetActive (false);
		}
		if (robberStart == true) {
			robberStartButton.SetActive (true);
		} else {
			robberStartButton.SetActive (false);
		}
			

			

	}

	public void Resume() // resumes game
	{
		defenderStart = true;
		defenderFinished = true;

	}

	public void defenderReady()
	{
		robberStart = true;
		defenderFinished = false;

	}

	public void robberReady()
	{
		robberStart = false;
		defenderStartCanvas.SetActive (false);
		//playerIcon.SetActive (true);

	
	}
		

	//public void LevelSelect() 
	//{
	//	Application.LoadLevel (levelSelect);
	//}

	//public void Quit() // quits game to main menu
	//{
	//	Application.LoadLevel (mainMenu);
	//}
}


