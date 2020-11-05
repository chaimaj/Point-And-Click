using UnityEngine;
using System.Collections;

public class PlaceObject : MonoBehaviour {
	public static bool check=true;
	private GameObject[] parts;

	private GameObject photo;
	private float distance =0.1f;
	private float curDistance;



	public void FixPlace(){
		parts = GameObject.FindGameObjectsWithTag("parts"); // put every gameObject with tag "parts" in an array
		Debug.Log ("parts" +gameObject.name);
		
		foreach (GameObject part in parts){ 
			Debug.Log (" search parts" +gameObject.name);
				Vector3 diff = part.transform.position - transform.position; 
				curDistance = diff.sqrMagnitude; // compute distance between gameobject and part
			
			if (curDistance < distance){ // if distance is lower than cerian distance 
					Debug.Log("close toooo "+part.name);
				DragObject drag = gameObject.GetComponent<DragObject>();
					Destroy(drag); //Detroy the drag script on current GO 
				DragObject drag2 = part.GetComponent<DragObject>();
				Destroy(drag2); //Detroy the drag script on part "the closest GO
				Debug.Log ("drag disabled on "+gameObject.name);
				transform.position=part.transform.position; // GO's position is set to part's position
				Debug.Log ("close to"+part.name);
				photo=new GameObject("CompletePhoto"); //create new gameobject that will contain the two parts
				photo.AddComponent("BoxCollider"); //add a bow collider and scripts for movements
				photo.AddComponent ("DragObject"); 
				photo.AddComponent("PlaceObject");
				photo.gameObject.tag = "parts"; // add tag parts to track it when looking for parts
				transform.parent=photo.transform; //set photo as parent of GO and part
				part.transform.parent=photo.transform;
				transform.localPosition=Vector3.zero; //reset their local position to 0
					Debug.Log("reset0 transform"+gameObject.name);
				part.transform.localPosition=Vector3.zero;
					Debug.Log("reset0 part"+part.name);
				}
		}
	
	}
}
