using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax;
	public float zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public float speed;           //speed of the ship
	public float tilt;            //rotation of the ship
	public Boundary boundary;    

	public GameObject shot;
	public Transform shotSpawn;
	//public GameObject shotSpawn; //shotSpawn.transform.position
	public float fireRate;
	private float nextFire;

	void Start(){
		 rb = GetComponent<Rigidbody> ();	
	}

	void Update(){

		//Debug.Log (Time.time + " Time.time");
		//Debug.Log (nextFire + " nextFire");

		if(Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement* speed;
		rb.position = new Vector3 
		(
				Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
				0.0f,
				Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);

		//tilt the ship when it moves, make the tilt negative so that it tilts in the right direction. 
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
		//rb.rotation = Quaternion.Euler (new Vector3 (0.0f, 0.0f, rb.velocity.x * -tilt));

	}
}
