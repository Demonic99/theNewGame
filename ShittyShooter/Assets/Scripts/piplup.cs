using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piplup : MonoBehaviour {

	public  List <GameObject> projectiles = new List <GameObject> ();
	private int projectileIndex;
	public gravity feet;
	public SpriteRenderer sprite;
	private float reload;
	public float reloadtime;
	public float movement;
	private bool move;
	public float jumpForce;
	public float jumpduration;
	private float jump;
	public float jumpCooldown;
	public GameObject jbFace;
	public GameObject unicornGun;
	public GameObject instantiatedUnicornGun;
	private bool shootinRainbows;
	public int rainbowRotaion;
	public GameObject rainbowLaser;


	// Use this for initialization
	void Start () {
		move = true;
		projectileIndex = 0;
		reload = -reloadtime - 1;
		jump = -jumpCooldown - 1;
		rainbowRotaion = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Time.time - reload >= reloadtime){
			if (Input.GetKeyDown (KeyCode.RightShift)) {
				Shoot ();
			} else if (Input.GetKeyDown (KeyCode.LeftShift)) {
				Shoot ();
			}
		}
		if (move) {
			if (Input.GetKey (KeyCode.D)) {
				Move (true);
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				Move (true);
			}

			if (Input.GetKey (KeyCode.A)) {
				Move (false);
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				Move (false);
			}

			if (Time.time - jump >= jumpCooldown) {	
				if (Input.GetKey (KeyCode.W)) {
					Jump ();
				} else if (Input.GetKey (KeyCode.UpArrow)) {
					Jump ();
				}
			}
		}

		if (shootinRainbows) {
			if (rainbowLaser.transform.rotation.eulerAngles.z >= 90 && rainbowLaser.transform.rotation.eulerAngles.z <= 270) {
				rainbowLaser.GetComponent <SpriteRenderer> ().flipY = true;
				instantiatedUnicornGun.GetComponent <SpriteRenderer> ().flipY = true;
				gameObject.GetComponent <SpriteRenderer> ().flipX = true;
			} else {
				rainbowLaser.GetComponent <SpriteRenderer> ().flipY = false;
				instantiatedUnicornGun.GetComponent <SpriteRenderer> ().flipY = false;
				gameObject.GetComponent <SpriteRenderer> ().flipX = false;
			}
			if (Input.GetKeyUp (KeyCode.LeftShift) || Input.GetKeyUp (KeyCode.RightShift)) {
				Destroy (rainbowLaser);
				reload = Time.time;
				move = true;
				shootinRainbows = false;
				rainbowRotaion = 0;


			} else {
				rainbowLaser.transform.Rotate (new Vector3 (0, 0, rainbowRotaion*Time.deltaTime));
				instantiatedUnicornGun.transform.Rotate (new Vector3 (0, 0, rainbowRotaion*Time.deltaTime));
				if (Input.GetKeyUp (KeyCode.D)) {
					rainbowRotaion = 0;
				} else if (Input.GetKeyUp (KeyCode.RightArrow)) {
					rainbowRotaion = 0;
				} else if (Input.GetKeyUp (KeyCode.A)) {
					rainbowRotaion = 0;

				} else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
					rainbowRotaion = 0;
				}
				if (Input.GetKey (KeyCode.D) && rainbowRotaion <= 250 && rainbowRotaion >= -250) {
					rainbowRotaion -= 3;
				} else if (Input.GetKey (KeyCode.RightArrow) && rainbowRotaion <= 250 && rainbowRotaion >= -250) {
					rainbowRotaion -= 3;
				}

				if (Input.GetKey (KeyCode.A) && rainbowRotaion <= 250 && rainbowRotaion >= -250) {
					rainbowRotaion += 3;

				} else if (Input.GetKey (KeyCode.LeftArrow) && rainbowRotaion <= 250 && rainbowRotaion >= -250) {
					rainbowRotaion += 3;
				}
			}
		}
	}

	void Shoot (){
		if (projectileIndex == 2) {
			move = false;
			shootinRainbows = true;
			rainbowLaser = Instantiate (projectiles [projectileIndex], transform.position, Quaternion.identity);
			rainbowLaser.GetComponent <projectile> ().gunslinger = gameObject;



		}else{
			GameObject go = (GameObject)Instantiate (projectiles [projectileIndex]);
			go.transform.position = transform.position;
			if (!sprite.flipX) {
				go.transform.Translate (new Vector3 (1.4f, 0, 0));
				go.GetComponent<projectile> ().startRotation = transform.rotation;
			} else {
				go.transform.Translate (new Vector3 (-1.4f, 0, 0));
				transform.Rotate (new Vector3 (0, 180, 0));
				go.GetComponent<projectile> ().startRotation = transform.rotation;
				transform.Rotate (new Vector3 (0, -180, 0));
			}
			reload = Time.time;
			go.GetComponent <projectile> ().gunslinger = gameObject;
		}
	}

	void Move(bool right){

		if (right) {
			gameObject.transform.Translate (new Vector3 (movement*Time.deltaTime, 0, 0));
			sprite.flipX = false;

		}else{
			gameObject.transform.Translate (new Vector3 (-movement*Time.deltaTime, 0, 0));
			sprite.flipX = true;

		}
	}

	void Jump(){

		if(feet.groundtouched != 0 ){
			StartCoroutine (Jumproutine ());
			jump = Time.time;
		}
	}

	IEnumerator Jumproutine (){
		float airtime = 0;
		while (airtime < jumpduration) {
			gameObject.transform.Translate (new Vector3 (0, jumpForce*Time.deltaTime, 0));
			airtime += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
	
		}
	}

	public void getJb () {
		Instantiate (jbFace, transform);
		projectileIndex = 1;
	}

	public void getUnicorn () {
		instantiatedUnicornGun = (GameObject)Instantiate (unicornGun, transform);
		projectileIndex = 2;
	}

	IEnumerator Deathanimation(){
		//start animation
		yield return new WaitForSeconds (0.5f);
		Destroy (gameObject);

	}
}
