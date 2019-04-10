using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// use VR class

public class toggle : MonoBehaviour {

	string toastString;
	AndroidJavaObject currentActivity;

	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Return)){
			playVRBut();

		//if (Input.GetKey(KeyCode.Z)) {
			//ToggleVR ();
		}

		if (Input.GetKeyDown(KeyCode.Return)){
			play3DBut();
	}
		if (Input.GetKeyDown(KeyCode.Return)){
			playGoBut();
		}

		if (Input.GetKeyDown(KeyCode.Return)){
			playGo2But();
		}

		//back

		if (Application.platform == RuntimePlatform.Android) {

			if (Input.GetKey (KeyCode.Escape)) {

				Scene scene = SceneManager.GetActiveScene ();

				if(scene.name == "Toggle_Scene" || scene.name=="GoVR2"){
					
					BackFromToggle_Scene ();
			    }

				if (scene.name == "GoVR"){

					BackFromGoVR ();
				}

				if (scene.name == "GoAgain2VR"){

					BackFromGoVR2 ();
				}

		}

	}

}

	// Update is called once per frame


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
	public void play3DBut(){
		if (Application.platform == RuntimePlatform.Android) {
			showToastOnUiThread ("Drag and Target your ray to Zombie, to destroy it"); //3D mode, not VR mode

		}
		SceneManager.LoadScene("3DLevel1");
	}
	public void playVRBut(){
		if (Application.platform == RuntimePlatform.Android) {
			
			showToastOnUiThread ("If you see black screen,tap on the middle line until you see the Game");
		}
		SceneManager.LoadScene("GoVR");

	}

	public void playGoBut(){

		if (Application.platform == RuntimePlatform.Android) {
			showToastOnUiThread ("attack");

		}
		SceneManager.LoadScene("VRGame");
	}
		

	public void play3D_L2(){
		if (Application.platform == RuntimePlatform.Android) {

			showToastOnUiThread ("Drag and Target your ray to Zombie, to destroy it");
		}
		SceneManager.LoadScene("3DLevel2");

	}



	public void playGo2But(){  //play in VR mode , level 2


		SceneManager.LoadScene("GoAgain2VR");
	}

	public void playGo2AgainVR(){  //play in VR mode , level 2

		if (Application.platform == RuntimePlatform.Android) {
			showToastOnUiThread ("If you see black screen, tap on the middle line until you see the Game ");

		}
		SceneManager.LoadScene("area1");
	}

		public void BackFromToggle_Scene (){

			SceneManager.LoadScene("Start Menu");

		}

		public void BackFromGoVR (){

			SceneManager.LoadScene("Toggle_Scene");
		}

		public void BackFromGoVR2 (){

			SceneManager.LoadScene("GoVR2");
		}



}