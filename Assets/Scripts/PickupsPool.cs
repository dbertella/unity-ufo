using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsPool : MonoBehaviour {

	public int pickupPoolSize = 12;
	public GameObject pickup;
	public float min;
	public float max;

	private GameObject[] pickups;

	// Use this for initialization
	void Start () {
		pickups = new GameObject[pickupPoolSize];
		for (int i = 0; i < pickupPoolSize; i++) {
			float spawnYPosition = Random.Range (min, max);
			float spawnXPosition = Random.Range (min, max);
			Vector2 objectPoolPosition = new Vector2 (spawnYPosition, spawnXPosition);
			pickups [i] = (GameObject)Instantiate (pickup, objectPoolPosition, Quaternion.identity);
		}
	}

}
