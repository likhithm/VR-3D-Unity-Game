using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goback : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Application.platform == RuntimePlatform.Android) {

			if (Input.GetKey (KeyCode.Escape)) {

				Scene scene = SceneManager.GetActiveScene ();

				if (scene.name == "Start Menu") {

					back();
				}

			}

		}

		if (Application.platform == RuntimePlatform.Android) {

			if (Input.GetKey (KeyCode.Escape)) {

				Scene scene = SceneManager.GetActiveScene ();

				if (scene.name == "Loginpage_Amigos") {

					Application.Quit();
					return;


				}

			}

		}
		
	}

	public void back(){

		SceneManager.LoadScene("Loginpage_Amigos");
	}
}
