using UnityEngine;
using System.Collections;
/*
* - created on: 7-30-2014
*  - author: Mitch
* Makes the planets orbit around the sun
*/

public class PlanetOrbit : MonoBehaviour {
	public Transform sun;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (sun.position, Vector3.up, 0.1f * Time.deltaTime); 
		}
}
		                             