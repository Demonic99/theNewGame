using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DarkRift;
using UnityEngine.SceneManagement;

public class RegisterWarder : MonoBehaviour {

	//Tags!! :-3
	public const byte LOGINTAG = 0;


	//login Subject!! :3
	public const byte LOGINSUBJECT = 0;
	public const byte LOGINSUCCESS = 1;
	public const byte LOGINFAILED  = 2;
	public const byte REGISTER     = 3;

	public Button registerButton;
	public InputField pwText1;
	public InputField pwText2;
	public InputField nameText;
	public InputField emailText;

	public void Register(){

		if (pwText1.text == pwText2.text && pwText1.text.Length != 0) {
			//write to server
			using(DarkRiftWriter writer = new DarkRiftWriter()){
				writer.Write (nameText.text);
				writer.Write (pwText1.text);
				writer.Write (emailText.text);
				Warder.Connection.SendMessageToServer (LOGINTAG, REGISTER, writer);
			}
			SceneManager.LoadScene ("Slavery");

		} else {
			Debug.Log ("fqn Idiot");
		}

	}


}
