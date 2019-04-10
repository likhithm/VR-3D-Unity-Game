using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class spin : MonoBehaviour {
	public float spinVal = 20;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			//if (Input.GetKey(KeyCode.Z)) {
			ToggleVR ();
		}
		transform.Rotate (Vector3.up * spinVal * Time.deltaTime);

	}

	void ToggleVR(){
		if(XRSettings.loadedDeviceName == "cardboard"){
			StartCoroutine(LoadDevice("None"));
		}
		else
			StartCoroutine(LoadDevice("cardboard"));
	}
	// Update is called once per frame

	IEnumerator LoadDevice(string newDevice){

		XRSettings.LoadDeviceByName (newDevice);					
		yield return null;
		XRSettings.enabled = true;
	}

	public void flip(){
		spinVal = -spinVal;
	}
}
