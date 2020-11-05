using UnityEngine;
using System.Collections;

public class OnScreen : MonoBehaviour {

	public GameObject box; // boxes where we put the objects to find
	public GameObject GameManager; // game objetcs that manages the timer
	public string levelToLoad; 
	public GUIStyle style;
	public GameObject scoreText; 
	public Texture2D myCursor;  // my cursor texture
	public Texture2D catchCursor; // catch cursor texture
	public GameObject scoreBox;

	GameObject [] objects;

	int cursorSizeX = 35;  // Your cursor size x
	int cursorSizeY = 35;  // Your cursor size y
	bool begin = true;


	// Use this for initialization
	void Start () {

		Screen.showCursor = false;
		Debug.Log (""+Screen.width);
		Debug.Log (""+Screen.height);

		GameManager.SetActive(false);
		objects = GameObject.FindGameObjectsWithTag("objects"); // search all objects to find
		foreach (GameObject obj in objects){
		obj.GetComponent<BoxCollider2D>().enabled=false; // disable their box colliders so the player can't click on them until the game begins
	
		}

	}


	

	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (begin){
			// what to show when the game begins
			GUI.Label (new Rect(Screen.width/2 -100,Screen.height/2 - 60,100,10), "To win you have to ",style);
			GUI.Label (new Rect(Screen.width/2 -100,Screen.height/2 - 30,100,10), "find all hidden objects",style);
			if (GUI.Button (new Rect(Screen.width/2,Screen.height/2,100,20), "Play")){
				foreach (GameObject obj in objects){
					obj.GetComponent<BoxCollider2D>().enabled=true;
				}
				begin = false;
				Destroy (GameObject.FindGameObjectWithTag("Respawn"));
				GameManager.SetActive(true);
			}
		}
			//scoooree
		scoreText.guiText.text=""+SelectScript.score;
		Vector3 screenPos = Camera.main.WorldToScreenPoint(scoreBox.transform.position);
		scoreText.guiText.pixelOffset = new Vector2(screenPos.x+Screen.width/32f,screenPos.y+Screen.height/35);
		// cursooor
		if (SelectScript.checkcursor)
		{
			GUI.DrawTexture (new Rect(Event.current.mousePosition.x-cursorSizeX/2, Event.current.mousePosition.y-cursorSizeY/2, cursorSizeX, cursorSizeY), catchCursor);
			
		}
		else 
		{
			GUI.DrawTexture (new Rect(Event.current.mousePosition.x-cursorSizeX/2, Event.current.mousePosition.y-cursorSizeY/2, cursorSizeX, cursorSizeY), myCursor);
		}

		if (Timer.win){
			// what to show when win==true
			GUI.Label (new Rect(Screen.width/2 -100,Screen.height/2 - 60,100,10), "You Win!",style);
			GUI.Label (new Rect(Screen.width/2 -100,Screen.height/2 -30,100,10), "Score : "+SelectScript.score+" Time left : "+ (int)Timer.timer,style);
			int finalScore = SelectScript.score + (int) Timer.timer*5;
			GUI.Label (new Rect(Screen.width/2 - 100,Screen.height/2,100,10), "Score final :"+ finalScore, style);
			if (GUI.Button (new Rect(Screen.width/2,Screen.height/2 +30,100,20), "Play Again")){
				Timer.win=false;
				SelectScript.score=0;
				Timer.timer=20;
				Application.LoadLevel(levelToLoad);
				
			}
		}

		if (Timer.loose){
			// what to show when loose==false
			GUI.Label (new Rect(Screen.width/2,Screen.height/2 -60,100,10), "You lost!", style);
			if (GUI.Button (new Rect(Screen.width/2,Screen.height/2 -30,100,20), "Play again")){
				Timer.loose=false;
				SelectScript.score=0;
				Timer.timer=20;
				Application.LoadLevel(levelToLoad);

			}

			if (GUI.Button (new Rect(Screen.width/2,Screen.height/2,100,20), "Exit")){
				Application.Quit();
			}
		
		}
	
			


		
		}


}
