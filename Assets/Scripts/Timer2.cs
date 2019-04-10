using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer2 : MonoBehaviour {

	//toast
	/*string toastString;
	AndroidJavaObject currentActivity;*/


	public Text TimeText;
	public Text ScoreText;
	private string s;
	static  float time;




	// Use this for initialization
	void Start () {
		time = 120.0f;


	}

	// Update is called once per frame
	void Update () {

		time -= Time.deltaTime; 
		TimeText.text = "Time: " + time.ToString ();
		ScoreText.text= "Score: "+zombie2script.score;

		if (time <= 0.0f)
			timeend ();

		if (Application.platform == RuntimePlatform.Android) {

			if (Input.GetKey (KeyCode.Escape)) {

				Scene scene = SceneManager.GetActiveScene ();

				if (scene.name == "3DLevel2") {  //fix here

					backFromLevel2();
				}

				if (scene.name == "area1") {

					exitFromarea1 ();
				}

			}

		}
	}



	/*void showToastOnUiThread(string toastString){
		AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

		currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
		this.toastString = toastString;

		currentActivity.Call ("runOnUiThread", new AndroidJavaRunnable (showToast));
	}

	void showToast(){
		AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
		AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
		AndroidJavaObject javaString=new AndroidJavaObject("java.lang.String",toastString);
		AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject> ("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
		toast.Call ("show");
	}*/

	void timeend(){

		Time.timeScale = 0.0f;
		TimeText.text = "Game Over";
		ScoreText.text= "Your Score: "+zombie2script.score;

		s = zombie2script.score.ToString() ;

		Time.timeScale = 1f;
		PlayerPrefs.SetString ("scr",s );

		/*if (Application.platform == RuntimePlatform.Android) {
			showToastOnUiThread ("Turn around If you can't see your score");
		}*/
		zombie2script.score = 0;
		SceneManager.LoadScene("Result");
		//zombiescript.GetComponent<AudioSource>().Stop;

		//Application.LoadLevel
	}

	public void backFromLevel2(){

		SceneManager.LoadScene("Start Menu");
	}

	public void exitFromarea1(){

		Application.Quit ();
	}
}
