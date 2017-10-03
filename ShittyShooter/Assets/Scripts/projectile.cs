using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

	public float speed;
	public float dmg;
	public Collider2D hitbox;
	public Quaternion startRotation;
	public GameObject gunslinger;


	void Start () {
		transform.rotation = startRotation;
	}
	

	public virtual void Update () {
		transform.Translate (new Vector3 (speed*Time.deltaTime, 0, 0));
		
	}
}
