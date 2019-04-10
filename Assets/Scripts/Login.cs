using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {
	public GameObject username;
	public GameObject password;
	public string Name;
	private string Password;
	public string[] lines;
	private string decryptedPass;
	public string check;
	public string score;

	string toastString;
	AndroidJavaObject currentActivity;


	public void start(){
	}
	/*public void LoginButton(){
		bool N = false;
		bool P = false;
		if (Name != ""){
			if (System.IO.File.Exists(@"E:\UnityTestFolder\"+Name+".txt")){
				lines = File.ReadAllLines(@"E:\UnityTestFolder\"+Name+".txt");
				N = true;
			} else {
				Debug.LogWarning("Username Field is Incorrect");
			}
		} else {
			Debug.LogWarning("Username Field is empty");
		}
		if (Password != ""){
			if (System.IO.File.Exists(@"E:\UnityTestFolder\"+Name+".txt")){
				int i = 1;
				foreach(char c in lines[2]){
					i++;
					char decrypted = (char)(c / i);
					decryptedPass += decrypted.ToString();
				}
				if (Password == decryptedPass){
					P = true;
				} else {
					Debug.LogWarning("Password Field is Incorrect");
					decryptedPass = "";
				}
			} else {
				Debug.LogWarning("Password Field is Incorrect");
				decryptedPass = "";
			}
		} else {
			Debug.LogWarning("Password Field is empty");
			decryptedPass = "";
		}
		if (N == true&& P == true){
			print("Login Successful");
			username.GetComponent<InputField>().text = "";
			password.GetComponent<InputField>().text = "";
			Application.LoadLevel("Start Menu");
			//SceneManager.LoadScene("Start Menu");
		}
	}
	*/

	void showToastOnUiThread(string toastString){
		AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

		currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
		this.toastString = toastString;

		currentActivity.Call ("runOnUiThread", new AndroidJavaRunnable (showToast));
	}

	void showToast(){
		Debug.Log ("Running on UI thread");
		AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
		AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
		AndroidJavaObject javaString=new AndroidJavaObject("java.lang.String",toastString);
		AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject> ("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
		toast.Call ("show");
	}
	IEnumerator LoginToDB(string uname, string pw){
		int key = 17;
		string pwd = Encipher (pw, key);
		string LoginURL = "http://unitygame.xyz/LoginVR.php";
		WWWForm form = new WWWForm ();
		form.AddField ("usernamePost",uname);
		form.AddField ("passwordPost",pwd);
		WWW www = new WWW (LoginURL, form);
		yield return www;
		Debug.Log (www.text);
		string[] text = www.text.Split ("!".ToCharArray());  //.ToCharArray()

		//string[] text = www.text.Split('!');
		check = text[0];
		score = text[1];
		//String hs = text[2];
		//Debug.Log (score);
		//Debug.Log (hs);


			//if (www.text == "Login Success") {
			//Login_Button ();
				 
			
		//}
	}

	public void Login_Button(){
		if (check == "Login Success") {	
			if (Application.platform == RuntimePlatform.Android) {
				showToastOnUiThread ("Login Successful");
			}
			PlayerPrefs.SetString ("score", score);
			SceneManager.LoadScene("Start Menu");
		}
		else {
			
			Debug.Log ("Login Failure");
			if (Application.platform == RuntimePlatform.Android) {
				showToastOnUiThread ("Inavalid Username/Password!! Please Try Again"+check);
			}
		}
				
	username.GetComponent<InputField> ().text = "";
	password.GetComponent<InputField> ().text = "";
	
	

			
	}
		
	public static char cipher(char ch, int key) {  

		if (!char.IsLetter(ch)) { 
			return ch;  
		  }  
		char d = char.IsUpper(ch) ? 'A' : 'a';  
		return (char)((((ch + key) - d) % 26) + d);  
	}  

	public static string Encipher(string input, int key) {  
		string output = string.Empty;  
		foreach(char ch in input)  
			output += cipher(ch, key);  
		return output;  
	}

	/*public static string Decipher(string input, int key)  {  
		return Encipher(input, 26 - key);  
	} */
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)){
			if (username.GetComponent<InputField>().isFocused){
				password.GetComponent<InputField>().Select();
			}
		}

			if (Password != ""&&Name != ""){
				StartCoroutine(LoginToDB(Name,Password));
				
			}
			
		Name = username.GetComponent<InputField>().text;
		Password = password.GetComponent<InputField>().text;
	}


}
