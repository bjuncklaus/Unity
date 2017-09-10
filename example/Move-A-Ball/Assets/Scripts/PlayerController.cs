using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public float speed;

	public Text countText;
	public Text winText;

	private int count;

	private Rigidbody rb;

	void Start() {
		speed = 15;
		count = 0;
		UpdateCountText ();
		winText.text = "";
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
//		Destroy (other.gameObject);
		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			count++;
			UpdateCountText ();
		}
	}

	void UpdateCountText() {
		countText.text = "Score: " + count.ToString ();
		if (count >= 14) {
			winText.text = "You Win";
		}
	}
}
