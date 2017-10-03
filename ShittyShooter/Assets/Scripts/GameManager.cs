using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public float startSpeedMilk;
	public float endSpeedMilk;
	public float startSpeedCapri;
	public float endSpeedCapri;
	private bool capriSpawned;
	public int milkTillMaxSpeed;
	public int capriTillMaxSpeed;
	public GameObject milk;
	public GameObject capri;
	public GUIText scoreText;
	private int scoreValue;
	private bool jbSpawned;
	public GameObject JB;
	private bool unicornSpawned;
	public GameObject Unicorn;

	// Use this for initialization
	void Start () {
		UpdateScore (0);
		jbSpawned = true;
		capriSpawned = true;
		unicornSpawned = true;
		StartCoroutine (MilkSpawning ());
		Items.powerUp = GameObject.Find ("player").GetComponent <piplup> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (scoreValue >= 1200) {
			if (jbSpawned) {
				SpawnJb ();
				jbSpawned = false;

			}
		}

		if (scoreValue >= 2500) {
			if (capriSpawned) {
				StartCoroutine (CapriSpawning ());
				capriSpawned = false;

			}
		}
		if (scoreValue >= 3500) {
			if (unicornSpawned) {
				SpawnUnicorn ();
				unicornSpawned = false;
			}
		}
	}

	IEnumerator MilkSpawning (){
		int i = 0;
		float speed = startSpeedMilk;
		while (true) {
			SpawnMilk ();
			speed = Mathf.Lerp (startSpeedMilk, endSpeedMilk, i / milkTillMaxSpeed);
			i++;
			yield return new WaitForSeconds (speed);

		}
	}

	void SpawnMilk (){
		GameObject go = (GameObject)Instantiate (milk); 
		if (Random.Range (0, 2) == 0) {
			go.transform.position = new Vector3 (9.65f, Random.Range (-3.26f, 1.25f), 0);
		} else {
			go.transform.position = new Vector3 (-9.65f, Random.Range (-3.26f, 1.25f), 0);
			go.transform.Rotate (new Vector3 (0, 180, 0));
		}
		go.GetComponent <unit> ().gameManager = gameObject;
	}

	IEnumerator CapriSpawning (){
		int i = 0;
		float speed = startSpeedCapri;
		while (true) {
			SpawnCapri ();
			speed = Mathf.Lerp (startSpeedCapri, endSpeedCapri, i / capriTillMaxSpeed);
			i++;
			yield return new WaitForSeconds (speed);

		}
	}

	void SpawnCapri (){
		GameObject go = (GameObject)Instantiate (capri);
		if (Random.Range (0, 2) == 0) {
			go.transform.position = new Vector3 (9.65f, Random.Range (-3.26f, 1.25f), 0);
		} else {
			go.transform.position = new Vector3 (-9.65f, Random.Range (-3.26f, 1.25f), 0);
			go.transform.Rotate (new Vector3 (0, 180, 0));
		}
		go.GetComponent <unit> ().gameManager = gameObject;
	}

	public void UpdateScore (int t){
		scoreValue += t;
		scoreText.text = "Score: " + scoreValue;
	}
	

	void SpawnJb () {
		GameObject go = (GameObject)Instantiate (JB);
		go.transform.position = new Vector3 (0.5f, 3.78f, 0);

	}

	void SpawnUnicorn () {
		GameObject go = (GameObject)Instantiate (Unicorn);
		go.transform.position = new Vector3 (0.5f, 3.78f, 0);
	}
}
