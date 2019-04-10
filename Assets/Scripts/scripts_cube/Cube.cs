using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
	public float moveSpeed;
	// Use this for initialization
	void Start () {
		//moveSpeed = 1f;
		moveSpeed = 8f;
	}
	
	// Update is called once per frame
	void Update () {
		//print ();
		transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime,0f,moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
		//transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime,0f,Input.GetAxis("Vertical")*Time.deltaTime);
		//transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime, 0f, 0f);
		//transform.Translate(1f*Time.deltaTime,0f,0f); //It will run on every single frame


	}
}