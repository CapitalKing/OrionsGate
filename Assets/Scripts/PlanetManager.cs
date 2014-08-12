using UnityEngine;
using System.Collections;

public class PlanetManager : MonoBehaviour {

	public GameObject planet1;
	public GameObject playerShip;
	public ShipMovement ship;
	// Use this for initialization
	void Start () {
		ship = playerShip.GetComponent<ShipMovement> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(ship.totalDistance.x > 0){

		}
	}
}
