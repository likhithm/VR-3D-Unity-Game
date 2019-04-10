using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ser_Login : MonoBehaviour {

	public string inputUserName;
	public string inputPassword;

	string LoginURL = "http://unitygame.xyz/Login.php";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.L)) StartCoroutine(LoginToDB(inputUserName,inputPassword));
		
		
	}

	IEnumerator LoginToDB(string uname, string pw){

		WWWForm form = new WWWForm ();
		form.AddField ("usernamePost",uname);
		form.AddField ("passwordPost",pw);
		WWW www = new WWW (LoginURL, form);
		yield return www;
		Debug.Log (www.text);
	}

}
