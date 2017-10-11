using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DarkRift;
using UnityEngine.SceneManagement;

public class RegisterManager : MonoBehaviour {


	public Button registerButton;
	public InputField pwText1;
	public InputField pwText2;
	public InputField nameText;
	public InputField emailText;
	public GameObject usernameTakenPanel;
	public GameObject emailInUsePanel;

	public void Start(){
		Manager.Connection.onData += OnDataRecieved;
	}

	public void OnApplicationQuit(){
		Manager.Connection.onData -= OnDataRecieved;
	}

	public void Register(){

		if (pwText1.text == pwText2.text && pwText1.text.Length != 0) {
			//write to server
			using(DarkRiftWriter writer = new DarkRiftWriter()){
				writer.Write (nameText.text);
				writer.Write (pwText1.text);
				writer.Write (emailText.text);
				Manager.Connection.SendMessageToServer ((byte)TagsNSubjects.Tags.LOGINTAG, (ushort)TagsNSubjects.LoginSubjects.REGISTER, writer);
			}
		} else {
			Debug.Log ("fqn Idiot");
		}

	}
	public void OnDataRecieved(byte tag, ushort subject,object data){
		if (tag == (byte)TagsNSubjects.Tags.REGISTERTAG) {

			if (subject == (ushort)TagsNSubjects.RegisterSubjects.REGISTERSUCCESS) {
				SceneManager.LoadScene ("Login");
			}
			if (subject == (ushort)TagsNSubjects.RegisterSubjects.REGISTERFAILEDUSERNAME) {
				Debug.Log ("Username");
				usernameTakenPanel.SetActive (true);
			}
			if (subject == (ushort)TagsNSubjects.RegisterSubjects.REGISTERFAILEDEMAIL) {
				Debug.Log ("Email");
				emailInUsePanel.SetActive (true);
			}
		}
	}
}