using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : unit {
	public SpriteRenderer piplup;

	public override IEnumerator SmoothHealthbarAnimation (float start, float end) {
		float passedTime = 0;
		while (passedTime < duration) {
			float t = (start - (start - end) * (passedTime / duration)) / maxHp;
			piplup.color = Color.Lerp (startColor, endColor, 1 - t);
			passedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}

	}
	public override void OnHit (float dmg){
		hp -= dmg;
		StopAllCoroutines ();
		StartCoroutine (SmoothHealthbarAnimation (hp + dmg, hp));
		if (hp <= 0) {
			StartCoroutine (Deathanimation ());

		}
	}
}
