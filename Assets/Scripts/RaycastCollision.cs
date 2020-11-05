using UnityEngine;
using System.Collections;

public class RaycastCollision : MonoBehaviour {

	public GameObject charachter;
	private RaycastHit hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 myTransform = charachter.transform.up;
		if (Input.GetKey(KeyCode.Mouse0)){
			if (Physics.Raycast(transform.position, myTransform, out hit,20)){

				if (hit.collider.CompareTag("parts")){
					Debug.DrawRay(transform.position,charachter.transform.up, Color.red);
					print("there is an object");
				
				}
			}
		}
	}
}
