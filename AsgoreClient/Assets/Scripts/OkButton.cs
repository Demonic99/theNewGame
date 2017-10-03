using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkButton : MonoBehaviour {

	public GameObject PopUp;

	public void OnButtonPressed(){
		PopUp.SetActive(false);
	}
}