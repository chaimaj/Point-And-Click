using UnityEngine;
using System.Collections;

public class FieldBehaviour : MonoBehaviour {
	public static bool onOff=false;
	public Sprite selected;
	public GameObject column;

	private Sprite actual;
	private GameObject glowing;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (onOff){
			glowing = GameObject.FindGameObjectWithTag("Player");
		}
	
	}

	void OnMouseDown (){
		if (!onOff){
			actual=gameObject.GetComponent<SpriteRenderer>().sprite;
			column.active=true;
			gameObject.GetComponent<SpriteRenderer>().sprite=selected;
			gameObject.tag="Player";
			onOff=true;
		}



	}
}
