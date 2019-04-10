using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {



	private string sc;
	

	public void start (){  // score test

		sc = PlayerPrefs.GetString ("score");
		Debug.Log (sc);
	}

	public void update(){


		if (Input.GetKeyDown(KeyCode.Return)){
			PlayBut();
		}
		if (Input.GetKeyDown(KeyCode.Return)){
			ExitBut();
		}
		if (Input.GetKeyDown(KeyCode.Return)){
			OptionsBut();
		}

		if (Input.GetKeyDown(KeyCode.Return)){
			StartMenu();
		}





	}


	public void StartMenu(){
		SceneManager.LoadScene("Start Menu");
	}

	public void PlayBut(){
		SceneManager.LoadScene("Toggle_Scene");
	}

	public void ExitBut(){
		Application.Quit();
	}

	public void OptionsBut(){
		SceneManager.LoadScene("GoVR2");
	}







}
