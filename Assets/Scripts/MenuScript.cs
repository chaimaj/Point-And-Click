using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	public bool game;
	public bool load;
	public bool scene;

	void OnMouseDown(){
		if (game){
			Debug.Log("new game");
			Application.LoadLevel("DiaologScene1");
		}
		else if (load)
		{
			Debug.Log("load game");
		}
		else{
			Debug.Log("Scenes");
		}
	}
}
