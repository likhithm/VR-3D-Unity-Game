using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_cube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = new Vector3(Mathf.PingPong(Time.time, 3), transform.position.y, transform.position.z); // only x-axis
	}

}

