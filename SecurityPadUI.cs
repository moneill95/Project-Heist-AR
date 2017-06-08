using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecurityPadUI : MonoBehaviour {

	public static Text securitypadText;


	// Use this for initialization
	void Start () {
		securitypadText = GetComponent<Text> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		securitypadText.text = "Security Pad Chances " + GameManager.securityPadLife;

		if (GameManager.securityPadLife == 0) {
			securitypadText.text = "Out of Chances";
		}
	}
}
