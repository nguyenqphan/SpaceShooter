using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;             //refer to asteroid explosion prefab    
	public GameObject playerExplosion;       //refer to ship explosion prefab

	void OnTriggerEnter(Collider other){

		//Debug.Log (other.name);

		//Condition to not destroy the boundary
		if (other.tag == "Boundary") {
			return;
		}

		//instantiate explosion effects for the ship and asteriods before destroying them.
		Instantiate (explosion, transform.position, transform.rotation);    

		if(other.tag == "Player")
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);

		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
