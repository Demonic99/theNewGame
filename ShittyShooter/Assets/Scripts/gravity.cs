using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour {

	public float force;
	public GameObject parent;
	[HideInInspector] public int groundtouched;


	void OnTriggerEnter2D(Collider2D other){

		if(other.gameObject.tag == "ground" || other.gameObject.tag == "item") {
			groundtouched += 1;

		}

	}

	void OnTriggerExit2D(Collider2D other){

		if(other.gameObject.tag == "ground" || other.gameObject.tag == "item") {
			groundtouched -= 1;

		}

	}

	// Use this for initialization
	void Start () {

		groundtouched = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (groundtouched == 0) {
			parent.transform.Translate (new Vector3 (0, -force * Time.deltaTime, 0));

		}		
	}
}
