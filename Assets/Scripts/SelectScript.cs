using UnityEngine;
using System.Collections;

public class SelectScript : MonoBehaviour {

	public static bool checkcursor=false; // boolean to check if the cursor hovers an object to find
	public static bool check=false; // checks if an object is clicked
	public GameObject dest; // destination of the object to find (they're tagged button)

	public GameObject sound; // sound when we click the object
	public Sprite glow; // texture when we hover an object
	public Sprite bigGlow; // texture to show chen we click on an boject
	public Sprite endSprite; // final texture of the object to put on the box
	public static int score=0; // score of the player
	public static int nbCombo =1; //combo
	public static float timerCombo =3; // combo timer set to 3s

	private Sprite actual; //the actual texture of the object
	private Vector3 newScale; // scale when we hover
	private Vector3 placeScale; // scale when we place the object on the box

	private bool scale =false; // boolean to check if we change scale on hover
	private bool place =false; // boolean to check if we change scale when we place the object
	private bool desactivate =false; // variable to check the state clicked or not

	private float speed  = 5;


	private void Start(){
		actual= gameObject.GetComponent<SpriteRenderer>().sprite; // get the actual texture of the object
		placeScale = new Vector3 (0.14f,0.14f,0.14f); // set the place scale

	}


	void Update ()
		
	{
		if (scale){ // if scale then change the scale of the gameobject to newScale
		transform.localScale = Vector3.Lerp (transform.localScale, newScale, speed * Time.deltaTime);
		}
		if (place){ // if place then change the scale of the gameobject to placeScale
			transform.localScale = Vector3.Lerp (transform.localScale, placeScale, 60 * Time.deltaTime);
			float compare= Mathf.Abs(gameObject.transform.localScale.x-placeScale.x);
		
			if (compare<0.005f){// if we get the scale we want we disable the bow collider so we cannot click on the object again

				gameObject.GetComponent<BoxCollider2D>().enabled =false;
			}
		}
	}



	private void OnMouseDown(){ // when we click on the object
		Debug.Log("deest pos" +dest.transform.position.x);
			desactivate=true; // object clicked
			checkcursor=false; // cursor reset to normal
			sound.GetComponent<AudioSource>().Play(); // play sound
			gameObject.transform.position = new Vector3 (0,0,0); //change position
			gameObject.renderer.enabled=false; // disable rendering
			StartCoroutine(WaitAndGlow(0.5F)); // call couroutine after 0.5 s
			
			check=true;	
			ComboScript.nb=true; // increase combo
			timerCombo=3;
			score = score+(5*nbCombo); // score increased by 5* nbCombo
			//Destroy (this.gameObject,2);
			

	}

	IEnumerator WaitAndGlow(float waitTime) {

		yield return new WaitForSeconds(waitTime);
		gameObject.renderer.enabled=true; // enable rendering
		gameObject.GetComponent<SpriteRenderer>().sprite=bigGlow; // change texture
		StartCoroutine(WaitAndMove(0.5F)); // call couroutine after 0.5s
		print("WaitAndPrint " + Time.time);
	}

	IEnumerator WaitAndMove(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		gameObject.GetComponent<SpriteRenderer>().sprite=endSprite; //change texture
		Debug.Log ("change sprite");
		place=true; // activate scaling
		Debug.Log ("activate scale");
		iTween.MoveTo (gameObject, dest.transform.position + new Vector3 (0,-0.1f,0),2); // move to dest position
		Debug.Log ("move");
	
		Destroy (dest,2); // detroy the destination


	}



	private void OnMouseEnter () {
		if (!desactivate){ // if not clicked
		scale=true;
		checkcursor=true; // cursor set to catchcursor
		newScale = new Vector3 (1.2f, 1.2f, 1.2f);
		gameObject.GetComponent<SpriteRenderer>().sprite=glow; //change texture
		gameObject.GetComponent<SpriteRenderer>().sortingOrder=5; //put it on foreground
		}
	}
	private void OnMouseExit () {
		if (!desactivate){ //if not clicked
		newScale=new Vector3(1,1,1);
		checkcursor=false; // cursor reset to normal
		gameObject.GetComponent<SpriteRenderer>().sprite=actual;// reset the normal texture
		gameObject.GetComponent<SpriteRenderer>().sortingOrder=3;// put it back
		}

	}
}
