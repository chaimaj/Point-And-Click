using UnityEngine;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;

public class ReadImage : MonoBehaviour {


	void OnGUI(){
		//place this in the OnGui() method 
		if(GUI.Button(new Rect(Screen.width/3, Screen.height/5, Screen.width/3,Screen.height/10),"print"))
		{
			PrintDocument pd = new PrintDocument();
			pd.PrintPage += PrintPage;
			pd.Print();      
		}
	}
		// place this in the same class
	private void PrintPage(object o, PrintPageEventArgs e)
		{
		System.Drawing.Image img = System.Drawing.Image.FromFile("C:\\Users\\COMPAQ\\Documents\\Scene\\Assets\\screenshots\\screen_300x300_2014-03-11_15-08-00");
			Point loc = new Point(100, 100);
			e.Graphics.DrawImage(img, loc);     
		}
}
