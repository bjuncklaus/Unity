using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;
	public Rigidbody rb;

	void Start() {
		speed = 15;
		rb = GetComponent<Rigidbody>();
		rb.velocity = GetComponent<Transform> ().forward * speed ;
	}

	void FixedUpdate () {
		if (rb.position.z >= 45) {
			// Destroy the bolt
		}
	}
}
