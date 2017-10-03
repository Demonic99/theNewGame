using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkRift;

public class SaveDeck1 : MonoBehaviour {

	public GameObject BuildingDecks;

	public void OnButtonPressed(){
		TogglePanel (BuildingDecks);

	}

	//Fenster (Pop-Up) für den Deckbau schliessen
	public void TogglePanel (GameObject panel) {
		panel.SetActive (false);
		using (DarkRiftWriter writer = new DarkRiftWriter ()) {
			Manager.Connection.SendMessageToServer ((byte)TagsNSubjects.Tags.CARDTAG, (ushort)TagsNSubjects.CardSubjects.Deck1Built, writer);
		}
	}
}
