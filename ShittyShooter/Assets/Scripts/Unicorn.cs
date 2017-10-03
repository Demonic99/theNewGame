using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unicorn : Items {

	public override void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Destroy (GameObject.Find ("JbMask(Clone)"));
			powerUp.getUnicorn ();
		}
		base.OnTriggerEnter2D (other);
	}
}