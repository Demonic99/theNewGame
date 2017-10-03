using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

	public static piplup powerUp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	public virtual void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}
}
