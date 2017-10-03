using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : PenetrativeProjectile {
	public float dmgCooldown;
	private float lastDmgDealt;
	public Animator animator;

	public override void Update (){
		gameObject.transform.position = gunslinger.transform.position;
		
	}
		

	void OnTriggerStay2D (Collider2D other){
		if (Time.time - lastDmgDealt >= dmgCooldown) {
			unit enemy = other.gameObject.GetComponent<unit> ();
			if (enemy != null && other.gameObject != gunslinger) {
				enemy.OnHit (dmg);
				lastDmgDealt = Time.time;
			}
		}
	}
}
