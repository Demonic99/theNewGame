using UnityEngine;
using System.Collections;
using DarkRift;
using System.Collections.Generic;

public class Manager : MonoBehaviour {


	public static DarkRiftConnection Connection = new DarkRiftConnection();
	[SerializeField]
	int port = 4296;
	[SerializeField]
	string IP = "localhost";



	void OnApplicationQuit (){

		if (Connection.isConnected == true) {
			Connection.Disconnect ();
		}
	}


	public void Awake(){

		if (Connection.isConnected == true) {
			Destroy (gameObject);
			return;
		}
		DontDestroyOnLoad (gameObject);
		Connection.Connect (IP, port);
		Manager.Connection.onData += OnDataRecieved;

	}

	public IEnumerator Reconnect(){

		while (Connection.isConnected == false) {

			Connection.Connect (IP, port);
			yield return new WaitForSeconds (5);

		}

	}

	void Update(){

		Connection.Receive ();
		if (Connection.isConnected == false) {

			//connecting
			StartCoroutine ("Reconnect");


		}

	}

	public void OnDataRecieved(byte tag, ushort subject,object data){

		if (tag == (byte)TagsNSubjects.Tags.MATCHMAKING_TAG) {

			if (subject == (ushort)TagsNSubjects.MatchmakingSubjects.OPPONENTSLIST) {

				using (DarkRiftReader reader = data as DarkRiftReader) {
					int n;
					n = reader.ReadInt32 ();
					string[] nn = new string[n];
					nn = reader.ReadStrings ();
					Globalmanager.availableSlaves.Clear ();
					Globalmanager.availableSlaves.AddRange (nn);
					Debug.Log (nn.Length);
					Globalmanager.availableSlavesUpdated = true;
				}
			}
		}

		if (tag == (byte)TagsNSubjects.Tags.CARDTAG) {

			if (subject == (ushort)TagsNSubjects.CardSubjects.AVAILABLECARDS) {

				using (DarkRiftReader reader = data as DarkRiftReader) {
					int n;
					n = reader.ReadInt32 ();
					ushort[] nn = new ushort[n];
					nn = reader.ReadUInt16s ();
					Globalmanager.availableCards.Clear ();
					Globalmanager.availableCards.AddRange (nn);
					Debug.Log (nn.Length);
					Globalmanager.availableCardsUpdated = true;
				}
			}
		}
	}
}