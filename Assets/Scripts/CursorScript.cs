using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {

	public Texture2D myCursor;  // my cursor texture
	public Texture2D catchCursor;
	int cursorSizeX = 35;  // Your cursor size x
	int cursorSizeY = 35;  // Your cursor size y
	
	void Start()
	{
		Screen.showCursor = false;
	}
	
	void OnGUI()
	{if (SelectScript.checkcursor)
		{
		GUI.DrawTexture (new Rect(Event.current.mousePosition.x-cursorSizeX/2, Event.current.mousePosition.y-cursorSizeY/2, cursorSizeX, cursorSizeY), catchCursor);
	
		}
		else 
		{
			GUI.DrawTexture (new Rect(Event.current.mousePosition.x-cursorSizeX/2, Event.current.mousePosition.y-cursorSizeY/2, cursorSizeX, cursorSizeY), myCursor);
		}



}
}
