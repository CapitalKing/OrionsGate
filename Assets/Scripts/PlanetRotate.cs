using UnityEngine;
using System.Collections;
/*
* - created on: 7-30-2014
*  - author: Mitchell Morehead
* Place a short description of what the main function behind the script is.
*/

public class PlanetRotate : MonoBehaviour {
	public float speed = -0.01f;
	void Start () {
	
	}

	void Update () {
		transform.Rotate (0, speed, 0);
	}
}
