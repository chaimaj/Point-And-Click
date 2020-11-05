using UnityEngine;
using System.Collections;

public class GoToGameScene : MonoBehaviour {

	private bool click=false;
	// Use this for initialization
	void OnMouseDown(){
		click = true;

	}
	void OnGUI(){
		if (click){
		if (GUI.Button (new Rect(Screen.width/2 -50,Screen.height/2 -30,100,20), "Go to Game")){
			Application.LoadLevel("Scene1");
		}
		if (GUI.Button (new Rect(Screen.width/2 -50,Screen.height/2,100,20), "Back")){
				click =false;
		}
		}
	}
}
