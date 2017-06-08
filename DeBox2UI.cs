using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeBox2UI : MonoBehaviour {

	public static Text deBox2Text;


	// Use this for initialization
	void Start () {
		deBox2Text = GetComponent<Text> ();

	}

	// Update is called once per frame
	void Update () {
		deBox2Text.text = "Deposit Box 2 Chances " + GameManager.DepositBoxLife2;

		if (GameManager.DepositBoxLife2 == 0) {
			deBox2Text.text = "Out of Chances";
		}
	}
}
