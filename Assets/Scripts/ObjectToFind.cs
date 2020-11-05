using UnityEngine;
using System.Collections;

public class ObjectToFind : MonoBehaviour {

	public GameObject box;
	public GameObject text;
	public GameObject  dests;
	public int decalage;

	SelectScript select;
	GameObject boxPos;

	// Use this for initialization
	void Start () {
		BoxPosition(box,text,dests,decalage);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void BoxPosition (GameObject bx, GameObject txt, GameObject desti, int d){
		boxPos =(GameObject)Instantiate(bx, new Vector3( d+Screen.width / 415 * -1,Screen.height / 203* -1.2f, 0), Quaternion.identity);
		Vector3 screenPos = Camera.main.WorldToScreenPoint(boxPos.transform.position);
		txt.GetComponent<GUIText>().pixelOffset = new Vector2(screenPos.x- 28,screenPos.y+0.059f * Screen.height);
		GameObject des = (GameObject)Instantiate(desti, new Vector3( d+Screen.width / 415 * -1,Screen.height / 203* -1.2f, 0), Quaternion.identity);

		select =gameObject.GetComponent<SelectScript>();
		select.dest =des;

	}
}
