﻿using System.Collections; using System.Collections.Generic; using UnityEngine; using UnityEngine.SceneManagement;  public class NewGame : MonoBehaviour {  	public string MainMenu;  	public void Exit() // exits to maim menu 	{ 		Debug.Log ("Exit Pressed"); 		SceneManager.LoadScene (MainMenu);   	} 		 }  