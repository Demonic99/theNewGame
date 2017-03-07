using UnityEngine;
using System.Collections;
using DarkRift;
using System.Collections.Generic;

public class Warder : MonoBehaviour {

	//Tags!! :-3
	public const byte MATCHMAKING_TAG = 1;

	//matchmaking subjects
	public const byte OPPONENTSLIST = 0;
	public const byte FRIENDSLIST = 1;


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
		Warder.Connection.onData += OnDataRecieved;

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

		if (tag == MATCHMAKING_TAG) {
			
			if (subject == OPPONENTSLIST) {

				using (DarkRiftReader reader = data as DarkRiftReader) {
					int n;
					n = reader.ReadInt32 ();
					string[] nn = new string[n];
					nn = reader.ReadStrings ();
					Globalmanager.availableSlaves.Clear ();
					Globalmanager.availableSlaves.AddRange (nn);
					Globalmanager.availableSlavesUpdated = true;
				}
			}
		}
	}
}