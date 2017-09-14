using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") {
			return;
		}

		Instantiate (explosion, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
		if (other.tag == "PlayerTag") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
