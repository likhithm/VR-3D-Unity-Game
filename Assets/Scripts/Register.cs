using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour {
	public GameObject username;
	public GameObject email;
	public GameObject password;
	public GameObject passwordConformation;
	public string Name;
	private string Email;
	private string Password;
	private string PasswordConformation;
	private string Form;


	string toastString;
	AndroidJavaObject currentActivity;


	public GameObject PlayButton;

	public void QuickPlayButton(){
		SceneManager.LoadScene("Start Menu");
	}

	public void update(){




	}

	//private bool EmailValid = false;
	void Start(){
		

		/*username.transform.GetChild(2).GetComponent<CanvasRenderer>().SetAlpha(0f);
		email.transform.GetChild(2).GetComponent<CanvasRenderer>().SetAlpha(0f);
		password.transform.GetChild(2).GetComponent<CanvasRenderer>().SetAlpha(0f);
        */

	}




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

	public void RegisterButton(){
		//print ("registeration successfull");
		bool N = false;
		bool E = false;
		bool P = false;
		bool PC = false;
		bool EmailValid = false;
		if (Name != ""){
			//if (!System.IO.File.Exists(@"E:\UnityTestFolder\"+Name+".txt")){
				N = true;
				//username.transform.GetChild(3).GetComponent<CanvasRenderer>().SetColor(Color.green);
				//username.transform.GetChild(3).GetComponent<CanvasRenderer>().SetAlpha(0.7f);
			//} else {
				//username.transform.GetChild(3).GetComponent<CanvasRenderer>().SetColor(Color.red);
				//username.transform.GetChild(3).GetComponent<CanvasRenderer>().SetAlpha(0.7f);
				//Debug.LogWarning("Username Has Been Taken");
			}
		 else {
			//username.transform.GetChild(3).GetComponent<CanvasRenderer>().SetColor(Color.red);
			//username.transform.GetChild(3).GetComponent<CanvasRenderer>().SetAlpha(0.7f);
			if (Application.platform == RuntimePlatform.Android) {
				showToastOnUiThread ("Username Field is empty");
			}
			Debug.LogWarning("Username Field is empty");
		}
		if (Email != ""){
			EmailValid = Regex.IsMatch(Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
			if (EmailValid == true){
				if(Email.Contains("@") == true){
					if(Email.Contains(".") == true){
						E = true;
						//email.transform.GetChild(3).GetComponent<CanvasRenderer>().SetAlpha(0.7f);
						//email.transform.GetChild(3).GetComponent<CanvasRenderer>().SetColor(Color.green);
					} else {
						//email.transform.GetChild(3).GetComponent<CanvasRenderer>().SetColor(Color.red);
						//email.transform.GetChild(3).GetComponent<CanvasRenderer>().SetAlpha(0.7f);
						Debug.LogWarning("Email Field is Incorrect");
						if (Application.platform == RuntimePlatform.Android) {
							showToastOnUiThread ("Email Field is Incorrect");
						}
					}
				} else {
					//email.transform.GetChild(3).GetComponent<CanvasRenderer>().SetColor(Color.red);
					//email.transform.GetChild(3).GetComponent<CanvasRenderer>().SetAlpha(0.7f);
					Debug.LogWarning("Email Field is Incorrect");
					if (Application.platform == RuntimePlatform.Android) {
						showToastOnUiThread ("Email Field is Incorrect");
					}
				}
			} else {
				//email.transform.GetChild(3).GetComponent<CanvasRenderer>().SetColor(Color.red);
				//email.transform.GetChild(3).GetComponent<CanvasRenderer>().SetAlpha(0.7f);
				Debug.LogWarning("Email Field is Incorrect");
				if (Application.platform == RuntimePlatform.Android) {
					showToastOnUiThread ("Email Field is Incorrect");
				}
			}
		} else {
			//email.transform.GetChild(3).GetComponent<CanvasRenderer>().SetColor(Color.red);
			//email.transform.GetChild(3).GetComponent<CanvasRenderer>().SetAlpha(0.7f);
			Debug.LogWarning("Email Field is empty or Incorrect");
			if (Application.platform == RuntimePlatform.Android) {
				showToastOnUiThread ("Email Field is Empty/Incorrect");
			}
		}
		if (Password != ""){
			if (Password.Length > 5){
				P = true;
			} else {
				//password.transform.GetChild(3).GetComponent<CanvasRenderer>().SetColor(Color.red);
				//password.transform.GetChild(3).GetComponent<CanvasRenderer>().SetAlpha(0.7f);
				Debug.LogWarning("Password Must at least be 6 characters long");
				if (Application.platform == RuntimePlatform.Android) {
					showToastOnUiThread ("Password Must at least be 6 characters long");
				}

			}
		} else {
			//password.transform.GetChild(3).GetComponent<CanvasRenderer>().SetColor(Color.red);
			//password.transform.GetChild(3).GetComponent<CanvasRenderer>().SetAlpha(0.7f);
			Debug.LogWarning("Password Field is empty");
			if (Application.platform == RuntimePlatform.Android) {
				showToastOnUiThread ("Password Field is Empty");
			}

		}
		if (Password == PasswordConformation){
			PC = true;
			if (P == true){
				//password.transform.GetChild(3).GetComponent<CanvasRenderer>().SetColor(Color.green);
				//password.transform.GetChild(3).GetComponent<CanvasRenderer>().SetAlpha(0.7f);
			}
		} else {
			//password.transform.GetChild(3).GetComponent<CanvasRenderer>().SetColor(Color.red);
			//password.transform.GetChild(3).GetComponent<CanvasRenderer>().SetAlpha(0.7f);
			Debug.LogWarning("Passwords Doesn't Match");
			if (Application.platform == RuntimePlatform.Android) {
				showToastOnUiThread ("Passwords Don't Match");
			}
		}
		if (N == true && E == true && P == true && PC == true){

			int key = 17;
			string pw = Encipher(Password, key);
			CreateUser(Name,pw,Email);

			username.GetComponent<InputField>().text = "";
			email.GetComponent<InputField>().text = "";
			password.GetComponent<InputField>().text = "";
			passwordConformation.GetComponent<InputField>().text = "";
			/*username.transform.GetChild(3).GetComponent<CanvasRenderer>().SetAlpha(0f);
			email.transform.GetChild(3).GetComponent<CanvasRenderer>().SetAlpha(0f);
			password.transform.GetChild(3).GetComponent<CanvasRenderer>().SetAlpha(0f);
			*/
			print ("Registration Successfull");
			if (Application.platform == RuntimePlatform.Android) {
				showToastOnUiThread ("Registration Successfull");
			}
		}

	}

	public static char cipher(char ch, int key) {  

		     if (!char.IsLetter(ch)) { 
			    return ch;  
			   }  
			
		      char d = char.IsUpper(ch) ? 'A' : 'a';  
		      return (char)((((ch + key) - d) % 26) + d);  
   }  

	public static string Encipher(string input, int key)  

	{  
      string output = string.Empty;  
	  foreach(char ch in input)  
        output += cipher(ch, key);  
      return output;  
	}



	public void CreateUser(string username, string password, string email){
		string CreateUserURL = "http://unitygame.xyz/Register.php";
		WWWForm form = new WWWForm();
		form.AddField("emailPost", email);
		form.AddField("usernamePost", username);
		form.AddField("passwordPost", password);


		WWW www = new WWW(CreateUserURL, form);
	}
	
	void Update () {

		if (Input.GetKeyDown(KeyCode.Return)){
			QuickPlayButton();
		}


		if (Input.GetKeyDown(KeyCode.Tab)){
			if (username.GetComponent<InputField>().isFocused){
				email.GetComponent<InputField>().Select();
			}
			if (email.GetComponent<InputField>().isFocused){
				password.GetComponent<InputField>().Select();
			}
			if (password.GetComponent<InputField>().isFocused){
				passwordConformation.GetComponent<InputField>().Select();
			}
		}
		if (Input.GetKeyDown(KeyCode.Return)){
			if (PasswordConformation != ""&&Password != ""&&Email != ""&&Name != ""){
				RegisterButton();
			}
		}

		Name = username.GetComponent<InputField>().text;
		Email = email.GetComponent<InputField>().text;
		Password = password.GetComponent<InputField>().text;
		PasswordConformation = passwordConformation.GetComponent<InputField>().text;
		//print ("name = " + Name+ "password");
		
	}
}