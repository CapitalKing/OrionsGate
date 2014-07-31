using UnityEngine;
using System.Collections;
/*
 *  - created on: 7-29-2014

* - author: Mitch

* Used to give more 
 */
public class MassBased : MonoBehaviour {
	public float totalmass;
	public static float gravity;
	void Start () {
	
	}

	void Update () {
	
	}
	void FixedUpdate() {
		gravity = totalmass * 1.2f;

	}

}