﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;
	public Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody>();
		rb.velocity = GetComponent<Transform> ().forward * speed ;
	}

	void FixedUpdate() {
		
	}
}
