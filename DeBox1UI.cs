using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeBox1UI : MonoBehaviour {

	public static Text deBox1Text;


	// Use this for initialization
	void Start () {
		deBox1Text = GetComponent<Text> ();

	}

	// Update is called once per frame
	void Update () {
		deBox1Text.text = "Deposit Box 1 Chances " + GameManager.DepositBoxLife;

		if (GameManager.DepositBoxLife == 0) {
			deBox1Text.text = "Out of Chances";
		}
	}
}
