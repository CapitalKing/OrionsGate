﻿/*
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
	int MaxDistanceFromOrigin = 1000;

	/*The power of each thruster on the ship*/
	public float rearThrusterPower = 25;
	public float frontThrusterPower = 25;
	public float rightThrusterPower = 25;
	public float leftThrusterPower = 25;
	public float topThrusterPower = 25;
	public float bottomThrusterPower = 25;
	public float warpSpeed = 100000;
	public float mouseLookThrusterPower = 1500;
	public float maxSpeed = 15000;
	/*--------------------------------------*/


	/*Used to control the dampening (slow down) of the ship*/
	bool dampening = false;
	float dragAmount = 1;
	/*-----------------------------------------------------*/

	public UILabel dampersStatus;
	public UILabel speedStatus;
	public UILabel distanceStatus;
	public UILabel creditAmount;

	public ParticleSystem[] thrusterEmissionsRear = new ParticleSystem[2];
	public ParticleSystem warpEffect;
	Vector3 distanceFromStart;
	public Vector3 totalDistance;


	/*Used for tracking the ships rotation according to mouse look.*/
	float x_rotation;
	float y_rotation;
	float z_rotation;
	public float rotationSpeed = 2;
	int lookBuffer = 25;
	bool mouseLookOn = true;
	/*-------------------------------------------------------------*/

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

	void WarpDrive (){
		if(gameObject.rigidbody.velocity.magnitude < maxSpeed){
			gameObject.rigidbody.AddForce(gameObject.transform.forward * warpSpeed * Time.deltaTime, ForceMode.Force);
		}
		EmmitRear ();
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
			gameObject.rigidbody.angularVelocity = new Vector3(0,0,1) * Time.deltaTime;
		}

		if(Input.GetKey("e")){
			gameObject.rigidbody.angularVelocity = new Vector3(0,0,-1) * Time.deltaTime;

		}
		if(Input.GetKey("t")){
			WarpDrive();
			warpEffect.Play();

		} else if(Input.GetKeyUp("t")){
			warpEffect.Stop();
		}

		if(Input.GetKeyUp("z")){
			mouseLookOn = !mouseLookOn;
		}
		if(Input.GetKeyUp("x")){
			Debug.Log("UP");
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
	 * in the same direction the ship moved except objects 
	 * with the tag 'AttachedToShip'
	 */
	void UpdateObjects(Vector3 movementAmount){
		foreach(GameObject g in AllGameObjects){
			if(g.transform.root == g.transform){
				g.transform.position += movementAmount;
			}
		}
	}

	/*
	 * Used to control how the ship looks towards the mouse.
	 */
	void ShipMouseLook(){
		float xDif = Input.mousePosition.x - Screen.width / 2;
		float yDif = Input.mousePosition.y - Screen.height / 2;
		if(Vector2.Distance(new Vector2(Input.mousePosition.x, Input.mousePosition.y), new Vector2(Screen.width/2, Screen.height/2)) > lookBuffer){
			if(xDif > lookBuffer){
				x_rotation += xDif/mouseLookThrusterPower;
			} else if(xDif < lookBuffer) {
				x_rotation += xDif/mouseLookThrusterPower;
			}
			
			
			if(yDif > -lookBuffer){
				y_rotation += -yDif/mouseLookThrusterPower;
			} else if(yDif < lookBuffer) {
				y_rotation += -yDif/mouseLookThrusterPower;
			}
		}
	}

	void Output(){
		if(dampening){
			dampersStatus.text = "Inertial Dampeners: On";
		}else{
			dampersStatus.text = "Inertial Dampeners: Off";
		}
		totalDistance.x = distanceFromStart.x + Vector3.Distance (gameObject.transform.position, ShipOrigin);
		totalDistance.y = distanceFromStart.y + Vector3.Distance (gameObject.transform.position, ShipOrigin);
		totalDistance.z = distanceFromStart.z + Vector3.Distance (gameObject.transform.position, ShipOrigin);
		distanceStatus.text = "X: " + totalDistance.x.ToString("F2") +
			" Y: " + totalDistance.y.ToString("F2") +
				" Z: " + totalDistance.z.ToString("F2");
		speedStatus.text = "Speed (m/s): " + gameObject.rigidbody.velocity.magnitude.ToString("F2");
		creditAmount.text = "Credits: " + Economy.Credits;
	}

	void Start () {
		ShipOrigin = new Vector3(0,0,0);
		AllGameObjects = GameObject.FindObjectsOfType (typeof(GameObject));
		Screen.showCursor = false;
	}
	
	void Update(){
		GetInput ();
		Output ();
	}

	void FixedUpdate () {
		if(mouseLookOn){
			ShipMouseLook ();
		}

		if(Vector3.Distance(gameObject.transform.position, ShipOrigin) > MaxDistanceFromOrigin){
			distanceFromStart += gameObject.transform.position;
			AllGameObjects = GameObject.FindObjectsOfType(typeof(GameObject));
			UpdateObjects(ShipOrigin - gameObject.transform.position);
		}
		gameObject.transform.localEulerAngles = new Vector3 (y_rotation, x_rotation, z_rotation);
	}
}
