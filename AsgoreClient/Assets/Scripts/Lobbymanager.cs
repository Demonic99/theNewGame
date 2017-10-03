using UnityEngine;
using System.Collections;
using DarkRift;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Lobbymanager : MonoBehaviour {
	

	public GameObject Content;
	public GameObject ListObject;
	public List <GameObject> gos = new List <GameObject>();
	public RectTransform Spaghettifix;


	public void Update(){
		
		if (Globalmanager.availableSlavesUpdated == true) {

			foreach (GameObject go in gos) {

				Destroy (go);
			}

			gos.Clear();

			foreach (string player in Globalmanager.availableSlaves) {

				GameObject go = Instantiate (ListObject);
				go.transform.SetParent (Content.transform,false);
				gos.Add (go);
				Spaghettifix.sizeDelta = new Vector2 (1,1);
				Text t = go.GetComponentInChildren<Text> ();
				t.text = player;
			}
			Globalmanager.availableSlavesUpdated = false;
		}

		if (Globalmanager.availableCardsUpdated == true) {

			foreach (GameObject go in gos) {

				Destroy (go);
			}

			gos.Clear();

			foreach (ushort card in Globalmanager.availableCards) {

				Card Character = Card.createCharacter (card);
				GameObject go = Instantiate (ListObject);
				go.transform.SetParent (Content.transform,false);
				gos.Add (go);
				Spaghettifix.sizeDelta = new Vector2 (1,1);
				Text t = go.GetComponentInChildren<Text> ();
				t.text = Character.name;
			}
			Globalmanager.availableCardsUpdated = false;
		}
	}
}