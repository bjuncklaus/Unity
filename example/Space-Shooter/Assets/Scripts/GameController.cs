using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float secondsToWait;
	public float startWait;

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds (startWait );
		for (int i = 0; i < hazardCount; i++) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-6, 6), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (hazard, spawnPosition, spawnRotation);

			yield return new WaitForSeconds (secondsToWait);
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
