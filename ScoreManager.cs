using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int Total;
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();

		Total = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Total < 0) // if score is a minus figure it equals 0
			Total = 0;

		text.text = " £ " + Total;
	
	}

	public static void AddCashtoTotal(int CashOnTable){

		Total += CashOnTable;
	}
}
