using UnityEngine;
using System.Collections;

public class CollisionRaycast : MonoBehaviour {

	public Transform sightStart, sightEnd;

	// Use this for initialization
	void Start () {
		Raycast1 ();
		Raycast2();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Raycast1 (){
		Debug.DrawLine(sightStart.position,sightEnd.position,Color.green);
	}

	void Raycast2(){
	}
}
