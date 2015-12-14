using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other){
		Destroy (other.gameObject);
		//Me: Debug
		//Debug.Log(other.gameObject + " Just Left The Box");
	}
}
