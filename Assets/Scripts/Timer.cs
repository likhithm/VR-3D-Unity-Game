using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour {




	public Text TimeText;
	public Text ScoreText;
	public string s;
	static  float time;

	/*public float d = 1.0f;
	public Light it;
	public Color  c1 = Color.red;
	public Color  c2 = Color.blue;*/


	// Use this for initialization
	void Start () {
		time = 100.0f;
		//it = GetComponent<Light> ();
	
		
	}
	
	// Update is called once per frame
	void Update () {

		time -= Time.deltaTime; 
		TimeText.text = "Time: " + time.ToString ();
		ScoreText.text= "Score: "+zombiescript.score;
		/*if (time <= 45.0f) {

			float t = Mathf.PingPong (Time.time, d)/d;
			it.color = Color.Lerp (c1, c2, t);


		}*/
		if (time <= 0.0f)
			timeend ();


		if (Application.platform == RuntimePlatform.Android) {

			if (Input.GetKey (KeyCode.Escape)) {

				Scene scene = SceneManager.GetActiveScene ();

				if ( scene.name == "3DLevel1") {

					BackFromLevel1 ();
				}

				if (scene.name == "VRGame") {
					exitFromVRGame ();
				}
			}

		}
		
		
	}




	void timeend(){

		Time.timeScale = 0.0f;
		TimeText.text = "Game Over";
		ScoreText.text= "Your Score: "+zombiescript.score;

		s = zombiescript.score.ToString() ;

		Time.timeScale = 1f;
		PlayerPrefs.SetString ("scr",s );

		/*if (Application.platform == RuntimePlatform.Android) {
			showToastOnUiThread ("Turn around If you can't see your score");
		}*/
		zombiescript.score = 0;
		SceneManager.LoadScene("Result");
		//zombiescript.GetComponent<AudioSource>().Stop;

		//Application.LoadLevel
	}

	public void BackFromLevel1(){

		SceneManager.LoadScene("Start Menu");

	}

	public void exitFromVRGame(){

		Application.Quit ();
	}
}
