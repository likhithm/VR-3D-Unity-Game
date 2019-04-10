using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;  // use VR class

public class VRToggle : MonoBehaviour {

	private int i = 0;

	void Update () {
		if(Input.GetMouseButtonDown(0)){
			if (i == 0) {
				//if (Input.GetKey(KeyCode.Z)) {
				StartCoroutine (LoadDevice ("cardboard"));
				change ();
			}
		}
	}
	public void change(){
		i = 1;
	
	}

	// Update is called once per frame

	IEnumerator LoadDevice(string newDevice){
		
		XRSettings.LoadDeviceByName (newDevice);					
		yield return null;
		XRSettings.enabled = true;
		}
}
