using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	private Rigidbody rb;
	public float speed; //speed of the bolt

	void Awake(){
		rb = GetComponent<Rigidbody>();
	}

	void Start(){
		rb.velocity = transform.forward*speed;
		//rb.velocity = new Vector3(0,0,1);
	}
}
