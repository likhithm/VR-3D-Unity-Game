using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class zombie2script : MonoBehaviour {
	//declare the transform of our goal (where the navmesh agent will move towards) and our navmesh agent (in this case our zombie)
	private Transform goal;
	private UnityEngine.AI.NavMeshAgent agent;
	public static int score=0;


	// Use this for initialization

	/*void update(){
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		GetComponent<Animation>().Play("attack");
	}*/
	void Start () {

		//create references
		goal = Camera.main.transform;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		//set the navmesh agent's desination equal to the main camera's position (our first person character)
		agent.destination = goal.position;

		//start the walking animation
		GetComponent<Animation>().Play("walk");

		GetComponent<AudioSource>().Play ();



	}


	//for this to work both need colliders, one must have rigid body, and the zombie must have is trigger checked.
	void OnTriggerEnter (Collider col)
	{
		//first disable the zombie's collider so multiple collisions cannot occur
		GetComponent<CapsuleCollider>().enabled = false;
		//destroy the bullet
		Destroy(col.gameObject);
		//stop the zombie from moving forward by setting its destination to it's current position
		agent.destination = gameObject.transform.position;
		//stop the walking animation and play the falling back animation
		GetComponent<Animation>().Stop ();
		//GetComponent<Animation>().Play ("attack");
		GetComponent<Animation>().Play ("fallingback");
		//destroy this zombie in six seconds.
		Destroy (gameObject, 5);
		//instantiate a new zombie
		GameObject zombie = Instantiate(Resources.Load("zombie", typeof(GameObject))) as GameObject;

		//set the coordinates for a new vector 3
		float randomX = UnityEngine.Random.Range (70f,120f);
		float constantY = 0.1f; //0.1f
		float randomZ = UnityEngine.Random.Range (100f,130f);
		//set the zombies position equal to these new coordinates
		zombie.transform.position = new Vector3 (randomX, constantY, randomZ);
		score = score+10;
		//if the zombie gets positioned less than or equal to 3 scene units(1 here) away from the camera we won't be able to shoot it
		//so keep repositioning the zombie until it is greater than 3 scene units away. 
		while (Vector3.Distance (zombie.transform.position, Camera.main.transform.position) <= 10) {


			randomX = UnityEngine.Random.Range (85f,118f);
			randomZ = UnityEngine.Random.Range (100f,135f);

			zombie.transform.position = new Vector3 (randomX, constantY, randomZ);
		}

	}

}

