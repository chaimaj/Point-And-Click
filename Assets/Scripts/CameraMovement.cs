using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization
	float CamSpeed = 0.1f;
	float GUIsize = 200;
	
	void Update () {
		Rect recdown =  new Rect (0, 0, Screen.width, GUIsize);
		Rect recup = new Rect (0, Screen.height-GUIsize, Screen.width, GUIsize);
		Rect recleft = new Rect (0, 0, GUIsize, Screen.height);
		Rect recright = new Rect (Screen.width-GUIsize, 0, GUIsize, Screen.height);
		
		if (recdown.Contains(Input.mousePosition)){
			if (transform.position.y > -2.03f){
				transform.Translate(0,-CamSpeed,0, Space.World);
			}
		}
		if (recup.Contains(Input.mousePosition)){
			if (transform.position.y < 2.42f){
				transform.Translate(0,CamSpeed,0, Space.World);
			}
		}
		
		if (recleft.Contains(Input.mousePosition)){
			if (transform.position.x > -2.26f){
				transform.Translate(-CamSpeed, 0, 0, Space.World);
			}
		}
		
		if (recright.Contains(Input.mousePosition)){
			if (transform.position.x < 3.47f){
				transform.Translate(CamSpeed, 0, 0, Space.World);
			}
		}
	}
}
