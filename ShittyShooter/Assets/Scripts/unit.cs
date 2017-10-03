using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unit : MonoBehaviour {

	public float hp;
	[HideInInspector] public float maxHp;
	public Image healthbar;
	public Color startColor;
	public Color endColor;
	public Color middleColor;
	[HideInInspector] public float duration = 0.3f;
	public int value;
	public GameObject gameManager;

	// Use this for initialization
	void Start () {
		maxHp = hp;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void OnHit (float dmg){

		hp -= dmg;
		if (healthbar != null) {
			StopAllCoroutines ();
			StartCoroutine (SmoothHealthbarAnimation (hp + dmg, hp));


	
		}
		if (hp <= 0) {
			StartCoroutine (Deathanimation ());
			
		}
	}

	public virtual IEnumerator SmoothHealthbarAnimation(float start, float end){
		float passedTime = 0;
		while (passedTime < duration) {
			float t = (start - (start - end) * (passedTime / duration)) / maxHp;
			healthbar.fillAmount = t;
			if(t >= 0.5){
				healthbar.color = Color.Lerp (startColor, middleColor, 2 - t * 2);
			}else{
				healthbar.color = Color.Lerp (middleColor, endColor, -2 * t + 1);
			}
			passedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}
	}

	public IEnumerator Deathanimation(){
		//start animation
		yield return new WaitForSeconds (duration+0.1f);
		gameManager.GetComponent <GameManager> ().UpdateScore (value);
		Destroy (gameObject);


	}
}
