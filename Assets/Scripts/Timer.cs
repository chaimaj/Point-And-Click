using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public static bool win=false; // boolean to check if the player wins
	public static bool loose=false; // boolean to check if the player looses
	public static float timer=20.0f; // timer set to 20 seconds
	public GameObject clock; // the gameObject holcing the clock audio source
	public GameObject endGame; // texture to show when the game ends
	private  GameObject[] gos; // array gameobjects to delete to check when we find all objects
	private AudioSource tictac; // clock audio source
	private bool isCreated=false; //boolean to check if endGame is created



	void Start(){

		tictac = clock.GetComponent<AudioSource>(); // get the clock audio source
	}

	void Update(){
		// get all objects with tag Button
		gos = GameObject.FindGameObjectsWithTag("Button"); 

		if (gos.Length>0){
			// while there are objects with tag button, the time decreases
			timer -=Time.deltaTime;
		
		}
		else{ // all objects with tag button are deleted (all objects are found in the scene)

			timer=timer; //timer stops
			if (tictac.isPlaying)
				tictac.Stop();// if clock is playing then it stops
			gameObject.GetComponent<Animator>().enabled=false; //clock animation stops
			if (!isCreated)
			{	
			
				Instantiate(endGame); // instantiate the texture
				isCreated=true;
				win=true; // win set to true

			}



		}

		if ((timer <=5)&& (timer >0)){ // when timer is less then 5 clock starts playing
		
			if (!tictac.isPlaying)
				tictac.Play ();
		}

		if (timer <=0)
		{ // timer equals to 0
			timer =0;
			gameObject.GetComponent<Animator>().enabled=false; // disable aniation
			tictac.Stop(); // stop the audio dource
			if (!isCreated)
			{
			Instantiate(endGame);
			isCreated=true;
			loose=true; // loose is set to true

			}
		
		}
	}

}

