using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;             //refer to asteroid explosion prefab    
	public GameObject playerExplosion;       //refer to ship explosion prefab

	public int scoreValue;
	private GameController gameController;

	void Start()
	{
		GameObject gameConllerObject = GameObject.FindWithTag ("GameController");
		if (gameConllerObject != null) {
			gameController = gameConllerObject.GetComponent<GameController>();
		}
		if(gameController == null){
			Debug.Log("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other){

		//Debug.Log (other.name);

		//Condition to not destroy the boundary
		/*
		if (other.tag == "Boundary" || other.tag == "Enemy") {
			return;
		}
		*/

		//Debug.Log (other.GetComponent);


		Debug.Log(gameObject);

		if(other.CompareTag("Boundary")){
			//Debug.Log("I was here");
//			Debug.Log(other.GetComponent);
			return;
		}


		if(other.tag == "Enemy"){
			Debug.Log("Find an enemy ");
		//	Debug.Log(gameObject);
			return;

		}

		//Debug.Log ("I'd better not be here");

		//instantiate explosion effects for the ship and asteriods before destroying them.\

		Debug.Log ("It was about to explode");

		if (explosion != null) {
			Instantiate (explosion, transform.position, transform.rotation);    
			Debug.Log (explosion + " was down");
		}
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}

		gameController.AddScore (scoreValue);

		//destroy all objects related to the collision
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
