using UnityEngine;
using System.Collections;

public class CamBehaviour : MonoBehaviour {
	public GameObject cam;
	public GameObject parc1;
	public GameObject parc2;
	public GameObject scope;

	private bool isActive=false;
	private Vector3 initialPosition;
	// Use this for initialization
	void Start () {
		cam.GetComponent<CameraMovement>().enabled=isActive;
		initialPosition=cam.transform.position;
	}
	
	// Update is called once per frame
	void OnGUI(){
		if (GUI.Button(new Rect(10, 10, 150, 100), "Switch")){
			cam.transform.position=initialPosition;
			parc1.active =!parc1.active;
			parc2.active =!parc2.active;
			scope.active =!scope.active;
			cam.GetComponent<CameraMovement>().enabled=!isActive;
			isActive=!isActive;
		}
	}
}
