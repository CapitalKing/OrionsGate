using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {
	public Camera first;
	//public Camera firstPlanet;
	public Camera third;
	//public Camera thirdPlanet;
	// Use this for initialization
	void Start () {
		first.enabled = true;
		//firstPlanet.enabled = true;
		third.enabled = false;
		//thirdPlanet.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyUp (KeyCode.F)) {
			first.enabled = !first.enabled;
			//firstPlanet.enabled = !firstPlanet.enabled;
			third.enabled = !third.enabled;
			//thirdPlanet.enabled = !thirdPlanet.enabled;
		}
	}
}