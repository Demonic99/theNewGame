using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DarkRift;
using UnityEngine.SceneManagement;

public class LoginWarder : MonoBehaviour {

	//Tags!! :-3
	public const byte LOGINTAG = 0;

	public void Start(){
		Warder.Connection.onData += OnDataRecieved;
	}


	//login Subject!! :3
	public const byte LOGINSUBJECT = 0;
	public const byte LOGINSUCCESS = 1;
	public const byte LOGINFAILED  = 2;
	public const byte REGISTER     = 3;
	public InputField nameField;
	public InputField pwField;

	public void Login(){
		using(DarkRiftWriter writer = new DarkRiftWriter()){
			writer.Write (nameField.text);
			writer.Write (pwField.text);
			Warder.Connection.SendMessageToServer (LOGINTAG, LOGINSUBJECT, writer);
		}
	}

	public void OnDataRecieved(byte tag, ushort subject,object data){
		if (tag == LOGINTAG) {
		
			if (subject == LOGINSUCCESS) {
				using (DarkRiftReader reader = data as DarkRiftReader) {
					Globalmanager.id = reader.ReadInt32 ();
				}

			}
			SceneManager.LoadScene ("Lobby");
			if (subject == LOGINFAILED) {
				Debug.Log ("login failed");
			}
		}
	}
}
