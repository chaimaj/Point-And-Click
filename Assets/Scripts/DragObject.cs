using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour {

	private Vector3 screenPoint;


	void OnMouseDown(){
		screenPoint=Camera.main.WorldToScreenPoint(gameObject.transform.position);
	}

	void OnMouseExit(){
		gameObject.tag="parts";
	}

	void OnMouseDrag(){// drag the gameobject with the mouse
	
		gameObject.tag="Player";// change gameobject's tag to avoid considering his position in checking close parts
		Vector3 currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 currentPos = Camera.main.ScreenToWorldPoint (currentScreenPoint);
		transform.position = currentPos;
		Debug.Log ("moviiiinnngg" +gameObject.name);
		PlaceObject sn = gameObject.GetComponent<PlaceObject>();//get the script PlaceObject
		Debug.Log ("heeyyy" +gameObject.name);
		sn.FixPlace(); // Call the function FixPlace
		Debug.Log ("FixPlace" +gameObject.name);
		

		/*if (children.Length==1){
			Debug.Log ("has no children**");

		foreach (GameObject part in parts){

			Vector3 diff = part.transform.position - transform.position;
			float curDistance = diff.sqrMagnitude;
			if ((curDistance < distance) &&(check)){
					check=false;
					GameScript sn = gameObject.GetComponent<PlaceObject>();
					sn.FixPlace();
				
				/*transform.position=part.transform.position;
				Debug.Log ("close to"+part.name);
				photo=new GameObject("CompletePhoto");
				photo.AddComponent("BoxCollider");
				photo.AddComponent ("DragObject");
				photo.gameObject.tag = "parts";
				transform.parent=photo.transform;
				part.transform.parent=photo.transform;
				transform.localPosition=Vector3.zero;
					Debug.Log("reset0 transform"+gameObject.name);
				part.transform.localPosition=Vector3.zero;
					Debug.Log("reset0 part"+part.name);
			}
		}
		}
		else{
			foreach (Transform child in children) {
				if (child.IsChildOf(transform)){
				Debug.Log ("has children*****"+children.Length);
				foreach (GameObject part in parts){
					
					Vector3 diff = part.transform.position - child.position;
					float curDistance = diff.sqrMagnitude;
					if ((curDistance < distance) &&(check)){
						check=false;
						GameScript sn = gameObject.GetComponent<PlaceObject>();
						sn.FixChildPlace();
						/*part.transform.position=child.position;
						Debug.Log ("close to"+part.name);
						photo=new GameObject("CompletePhoto");
						photo.AddComponent("BoxCollider");
						photo.AddComponent ("DragObject");
						photo.gameObject.tag = "parts";
						transform.parent=photo.transform;
						part.transform.parent=photo.transform;
						child.localPosition=Vector3.zero;
						part.transform.localPosition=Vector3.zero;
						
					}
				}

			}
			}
		}*/
	}
}
