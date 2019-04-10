using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour {

	// Use this for initialization
	public Text ResultText;
	public string str;



	public void start (){  // score test
		


	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("hi");
		str = PlayerPrefs.GetString ("scr");
		ResultText.text = "Your Score is :" + str;
		
	}
}


	