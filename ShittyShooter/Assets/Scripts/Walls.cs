using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

	public float warpcooldown;
	private float lastWarp;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			if (Time.time - lastWarp >= warpcooldown) {
				var newValue = -other.transform.parent.position.x;
				if (other.transform.parent.position.x > 0)
					newValue = newValue + 0.5f;
				else
					newValue = newValue - 0.5f;
				other.transform.parent.position = (new Vector3 (newValue, other.transform.position.y, other.transform.position.z));
				lastWarp = Time.time;

			}
		}
	}

	// Use this for initialization
	void Start () {
		lastWarp = -warpcooldown - 1;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
