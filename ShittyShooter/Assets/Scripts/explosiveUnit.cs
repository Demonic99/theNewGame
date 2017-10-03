using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiveUnit : unit {

	public int dmg;

	public void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			unit player = other.transform.parent.GetComponent <unit> ();
			player.OnHit (dmg);
			Destroy (gameObject);
		}
	}
}
