using UnityEngine;
using System.Collections;
/*

* - created on: 8-2-2014

* - author: Mitch

* A pretty basic menu system.

*/
public class PlaceHolderMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,100,90), "Orion's Gate");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,80,20), "Play!")) {
			Application.LoadLevel("Main");
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(20,70,80,20), "Quit")) {
			Application.Quit();
		}
	}
}
