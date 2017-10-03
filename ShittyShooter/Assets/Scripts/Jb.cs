using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jb : Items {

	public override void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			powerUp.getJb ();
		}
		base.OnTriggerEnter2D (other);
	}
}
