using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;

	void SpawnWaves() {
		Vector3 spawnPosition = new Vector3 (Random.Range (-6, 6), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazard, spawnPosition, spawnRotation);
	}

	// Use this for initialization
	void Start () {
		SpawnWaves ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
