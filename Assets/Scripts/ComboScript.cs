using UnityEngine;
using System.Collections;

public class ComboScript : MonoBehaviour {


	public static bool nb =true;
	public GameObject scoreText;
	public GameObject comboSound;
	public GameObject combo2;
	public GameObject combo3;
	public GameObject combo4;
	public GameObject combo5;

	private Vector3 comboPos;
	private float actualCombo;
	private GameObject combo;
	private GameObject [] combos;
	// Use this for initialization
	void Start () {
		combo = GameObject.FindGameObjectWithTag("combo"); // find the combo texture
		combo.active =false;
		comboPos = combo.transform.position; // position of the combos to show on screen (x2, x3, etc)

	}

	// Update is called once per frame
	void Update () {
		actualCombo=SelectScript.timerCombo/3*100;
		if (SelectScript.check){
			combo.active=true; // activate combo timer when an object is clicked
			SelectScript.timerCombo-=Time.deltaTime; // decrease timer combo
			if (nb){
				SelectScript.nbCombo+=1; // increase number of combos
				nb=false;
				if (SelectScript.nbCombo==3){//combo *2
					DisplayCombo(combo2);
				}
				if (SelectScript.nbCombo==4){//combo *3
					DisplayCombo(combo3);
				}
				if (SelectScript.nbCombo==5){//combo *4
					DisplayCombo(combo4);
				}
				if (SelectScript.nbCombo==6){//combo *5
					DisplayCombo(combo5);
				}

			}
			}
				if (SelectScript.timerCombo <=0)
			{

			combos = GameObject.FindGameObjectsWithTag("combos");
			foreach( GameObject obj in combos){
				Destroy (obj);
			}
				combo.active=false;
				SelectScript.nbCombo=1;
				SelectScript.timerCombo=0;
			}
		}

	// method that displays combos
	void DisplayCombo(GameObject combToDsiplay){
		comboSound.GetComponent<AudioSource>().Play ();
		Instantiate(combToDsiplay,combo.transform.position +new Vector3(0.7f,0,0),Quaternion.identity);
		combToDsiplay.transform.localScale = Vector3.Lerp (combToDsiplay.transform.localScale,new Vector3 (0.5f,0.5f,0.5f), 5 * Time.deltaTime);
	
	
	}

	
}
