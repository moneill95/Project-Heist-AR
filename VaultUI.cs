using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VaultUI : MonoBehaviour {

	public static Text VaultText;


	// Use this for initialization
	void Start () {
		VaultText = GetComponent<Text> ();

	}

	// Update is called once per frame
	void Update () {
		VaultText.text = "Vault Chances " + GameManager.SafeLife;

		if (GameManager.SafeLife == 0) {
			VaultText.text = "Out of Chances";
		}
	}
}
