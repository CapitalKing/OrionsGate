using UnityEngine;
using System.Collections;
/*

* - created on: 7-29-14

* - author: Mitch

* Pulls this asteriod to the player depending on the ships gravity amount.

*/

public class GravityPull : MonoBehaviour {
	public int maxDist = 1;
	public Transform Ship;
	void Start () {
	Ship = GameObject.FindWithTag("Ship").transform;
	}

	void Update () {
			if(Vector3.Distance(transform.position, Ship.transform.position)<= maxDist){
			transform.position += Ship.transform.position * MassBased.gravity * Time.deltaTime;
		}
	}
}