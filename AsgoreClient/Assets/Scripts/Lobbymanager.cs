using UnityEngine;
using System.Collections;
using DarkRift;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Lobbymanager : MonoBehaviour {
	

	public GameObject PlayerContent;
	public GameObject AvailableCardContent;
	public GameObject ListObject;
	public List <GameObject> AvailablePlayers = new List <GameObject>();
	public List <GameObject> AvailableCards = new List <GameObject>();
	public List <ushort> Deck = new List <ushort> ();
	public RectTransform Spaghettifix;


	public void Update(){
		
		if (Globalmanager.availablePlayersUpdated == true) {

			foreach (GameObject go in AvailablePlayers) {

				Destroy (go);
			}

			AvailablePlayers.Clear();

			foreach (string player in Globalmanager.availablePlayers) {

				GameObject go = Instantiate (ListObject);
				go.transform.SetParent (PlayerContent.transform, false);
				AvailablePlayers.Add (go);
				Spaghettifix.sizeDelta = new Vector2 (1,1);
				Text t = go.GetComponentInChildren<Text> ();
				t.text = player;
			}
			Globalmanager.availablePlayersUpdated = false;
		}

		if (Globalmanager.availableCardsUpdated == true) {

			foreach (GameObject go in AvailableCards) {

				Destroy (go);
			}

			AvailableCards.Clear();

			foreach (ushort card in Globalmanager.availableCards) {

				Card Character = Card.createCharacter (card);
				GameObject go = Instantiate (ListObject);
				go.transform.SetParent (AvailableCardContent.transform, false);
				AvailableCards.Add (go);
				Spaghettifix.sizeDelta = new Vector2 (1,1);
				Text t = go.GetComponentInChildren<Text> ();
				t.text = Character.Name;

			}
			Globalmanager.availableCardsUpdated = false;
		}
	}

	public void OnButtonPressed(){

		foreach (GameObject go in AvailableCards){
		}
	}
}