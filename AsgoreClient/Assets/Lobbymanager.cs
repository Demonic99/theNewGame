using UnityEngine;
using System.Collections;
using DarkRift;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Lobbymanager : MonoBehaviour {
	
	//Tags!! :-3
	public const byte MATCHMAKING_TAG = 1;

	//matchmaking subjects
	public const byte OPPONENTSLIST = 0;
	public const byte FRIENDSLIST = 1;


	public GameObject Content;
	public GameObject ListObject;
	public List <GameObject> gos = new List <GameObject>();


	public void Update(){
		
		if (Globalmanager.availableSlavesUpdated == true) {

			foreach (GameObject go in gos) {

				Destroy (go);
			}

			gos.Clear();

			foreach (string player in Globalmanager.availableSlaves) {

				GameObject go = Instantiate (ListObject);
				go.transform.SetParent (Content.transform);
				gos.Add (go);
			}
			Globalmanager.availableSlavesUpdated = false;
		}
	}
}