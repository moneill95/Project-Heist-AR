using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;

public class DefenderAPpoints : MonoBehaviour {

	public static int dAPpoints;
	Text text;

	public string RobberStart;


	// Use this for initialization
	void Start () {

		text = GetComponent<Text> ();

		dAPpoints = 10;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (dAPpoints < 0) { // if score is a minus figure it equals 0
			dAPpoints = 0;
		}

			text.text = " " + dAPpoints;
		

		if (dAPpoints <= 0) {
			#if UNITY_EDITOR
			EditorUtility.DisplayDialog("All AP used","Robber Start", "OK");
			#endif
			SceneManager.LoadScene(RobberStart);

		}
	
	}

	public static void DecreaseAPpoints(int APpoints){
	
		dAPpoints -= APpoints;
	}
}
