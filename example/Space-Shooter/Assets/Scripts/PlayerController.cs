using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public int minX, maxX, minZ, maxZ;

	public Boundary(int minX, int maxX, int minZ, int maxZ) {
		this.minX = minX;
		this.maxX = maxX;
		this.minZ = minZ;
		this.maxZ = maxZ;
	}
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Rigidbody rb;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	void Start() {
		speed = 15;
		tilt = 3;
		rb = GetComponent<Rigidbody>();
		boundary = new Boundary (-6, 6, -2, 8);
	}

	void Update() {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
//			GameObject clone = 
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
//			as GameObject;
		}
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);

		rb.AddForce (movement * speed);
		rb.position = new Vector3(
			Mathf.Clamp(rb.position.x, boundary.minX, boundary.maxX),
			0f,
			Mathf.Clamp(rb.position.z, boundary.minZ, boundary.maxZ)
		);
		rb.rotation = Quaternion.Euler (0f, 0f, rb.velocity.x * -tilt);
	}
}
