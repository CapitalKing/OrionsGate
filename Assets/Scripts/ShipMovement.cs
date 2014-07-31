/*
 *-created on: 7-29-2014
 *-author: Caleb Gasser
 * This script will control the movement of the ship. Once moved MaxDistanceFromOrigin it will
 * move the ship back to the ShipOrigin along with all the other objects in scene in the same
 * direction at the same time.
 */

using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	object[] AllGameObjects;
	Vector3 ShipOrigin;
	int MaxDistanceFromOrigin = 100;

	/*The power of each thruster on the ship*/
	float rearThrusterPower = 25;
	float frontThrusterPower = 25;
	float rightThrusterPower = 25;
	float leftThrusterPower = 25;
	float topThrusterPower = 25;
	float bottomThrusterPower = 25;
	/*--------------------------------------*/


	/*Used to control the dampening (slow down) of the ship*/
	bool dampening = false;
	float dragAmount = 1;
	/*-----------------------------------------------------*/

	public ParticleSystem[] thrusterEmissionsRear = new ParticleSystem[2];

	/*Used for tracking the ships rotation.*/
	float x_rotation;
	float y_rotation;
	float z_rotation;
	/*-------------------------------------*/

	/*
	 * Moves the ship forwards in world space.
	 */
	void MoveShipForward(){
		gameObject.rigidbody.AddForce(gameObject.transform.forward * rearThrusterPower, ForceMode.Force);
		EmmitRear ();
	}

	/*
	 * Moves the ship backwards in world space.
	 */
	void MoveShipBackward(){
		gameObject.rigidbody.AddForce(-gameObject.transform.forward * frontThrusterPower, ForceMode.Force);
	}

	/*
	 * Moves the ship to the right in world space.
	 */
	void MoveShipRight(){
		gameObject.rigidbody.AddForce(gameObject.transform.right * leftThrusterPower, ForceMode.Force);
	}

	/*
	 * Moves the ship to the left in world space.
	 */
	void MoveShipLeft(){
		gameObject.rigidbody.AddForce(-gameObject.transform.right * rightThrusterPower, ForceMode.Force);
	}

	/*
	 * Moves the ship up in world space.
	 */
	void MoveShipUp(){
		gameObject.rigidbody.AddForce(gameObject.transform.up * bottomThrusterPower, ForceMode.Force);
	}

	/*
	 * Moves the ship down in world space.
	 */
	void MoveShipDown(){
		gameObject.rigidbody.AddForce(-gameObject.transform.up * topThrusterPower, ForceMode.Force);
	}

	/*
	 * Plays all the thruster emissions under thrusterEmissionsRear
	 */
	void EmmitRear(){
		foreach(ParticleSystem p in thrusterEmissionsRear){
			p.Play();
		}
	}

	/*
	 * Gets the player control input. 
	 */
	void GetInput(){
		if(Input.GetKey("w")){
			MoveShipForward();
		}

		if(Input.GetKey("s")){
			MoveShipBackward();
		}
		
		if(Input.GetKey("a")){
			MoveShipLeft();
		}

		if(Input.GetKey("d")){
			MoveShipRight();
		}

		if(Input.GetKey("r")){
			MoveShipUp();
		}

		if(Input.GetKey("c")){
			MoveShipDown();
		}

		if(Input.GetKey("q")){
			z_rotation += Time.deltaTime * 100;
		}

		if(Input.GetKey("e")){
			z_rotation -= Time.deltaTime * 100;

		}

		if(Input.GetKeyUp("x")){
			dampening = !dampening;
			if(dampening){
				gameObject.rigidbody.drag = dragAmount;
			} else {
				gameObject.rigidbody.drag = 0;
			}
		}
	}

	/*
	 * Once the ship updates back to it's origin this 
	 * function updates all other objects in the scene
	 * in the same direction the ship moved. 
	 */
	void UpdateObjects(Vector3 movementAmount){
		foreach(GameObject g in AllGameObjects){
			if(g.tag != "AttachedToShip"){
				g.transform.position += movementAmount;
			}
		}
	}

	void Start () {
		ShipOrigin = new Vector3(0,0,0);
		AllGameObjects = GameObject.FindObjectsOfType (typeof(GameObject));
		Screen.showCursor = false;
	}
	

	void FixedUpdate () {
		x_rotation += Input.GetAxis("Mouse X");
		y_rotation -= Input.GetAxis("Mouse Y");
	

		gameObject.transform.localEulerAngles = new Vector3 (y_rotation, x_rotation, z_rotation);

		if(Vector3.Distance(gameObject.transform.position, ShipOrigin) > MaxDistanceFromOrigin){
			UpdateObjects(ShipOrigin - gameObject.transform.position);
		}

		GetInput ();
	}
}
