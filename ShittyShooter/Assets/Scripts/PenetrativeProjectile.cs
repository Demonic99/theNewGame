using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenetrativeProjectile : projectile {

	public virtual void OnTriggerEnter2D (Collider2D other){
		unit enemy = other.gameObject.GetComponent<unit> ();
		if (enemy != null && other.gameObject != gunslinger){
			enemy.OnHit(dmg);
		}
	}
}
