using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oblivion : MonoBehaviour {


	public void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag != "oblivion" && other.gameObject.tag != "rainbow"){	
			Destroy (other.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
