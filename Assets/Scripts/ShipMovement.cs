/*
 *-created on: 7-29-2014
 *-author: Caleb Gasser
 * This script will control the movement of all objects in the scene. It wont actually move the ship, 
 * but all other objects around it instead.
 */

using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	object[] AllGameObjects;

	/*Varibles used for tracking the ships rotation.*/
	float x_rotation;
	float y_rotation;
	float z_rotation;
	/*----------------------------------------------*/

	/*
	 * Moves all gameobjects in scene opposite
	 * of the ship's forward to give the illusion
	 * the ship is moving forward.
	 */
	void MoveShipForward(){
		foreach(GameObject g in AllGameObjects){
			if(g != gameObject && g.tag != "MainCamera"){
				g.transform.Translate(-gameObject.transform.forward);
			}
		}
	}

	/*
	 * Moves all gameobjects in scene opposite
	 * of the ship's backwards to give the illusion
	 * the ship is moving backwards.
	 */
	void MoveShipBackward(){
		foreach(GameObject g in AllGameObjects){
			if(g != gameObject && g.tag != "MainCamera"){
				g.transform.Translate(gameObject.transform.forward);
			}
		}
	}

	/*
	 * Moves all gameobjects in scene opposite
	 * of the ship's right to give the illusion
	 * the ship is moving right.
	 */
	void MoveShipRight(){
		foreach(GameObject g in AllGameObjects){
			if(g != gameObject && g.tag != "MainCamera"){
				g.transform.Translate(-gameObject.transform.right);
			}
		}
	}

	/*
	 * Moves all gameobjects in scene opposite
	 * of the ship's left to give the illusion
	 * the ship is moving left.
	 */
	void MoveShipLeft(){
		foreach(GameObject g in AllGameObjects){
			if(g != gameObject && g.tag != "MainCamera"){
				g.transform.Translate(gameObject.transform.right);
			}
		}
	}

	/*
	 * Moves all gameobjects in scene opposite
	 * of the ship's us to give the illusion
	 * the ship is moving up.
	 */
	void MoveShipUp(){
		foreach(GameObject g in AllGameObjects){
			if(g != gameObject && g.tag != "MainCamera"){
				g.transform.Translate(-gameObject.transform.up);
			}
		}
	}

	/*
	 * Moves all gameobjects in scene opposite
	 * of the ship's down to give the illusion
	 * the ship is moving down.
	 */
	void MoveShipDown(){
		foreach(GameObject g in AllGameObjects){
			if(g != gameObject && g.tag != "MainCamera"){
				g.transform.Translate(gameObject.transform.up);
			}
		}
	}

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
	}

	void Start () {
		AllGameObjects = GameObject.FindObjectsOfType (typeof(GameObject));
		foreach(GameObject g in AllGameObjects){
			if(g != gameObject && g.GetType() != typeof(Camera)){
				Debug.Log(g.name);
			}
		}
	}
	

	void FixedUpdate () {
		x_rotation += Input.GetAxis("Mouse X");
		y_rotation -= Input.GetAxis("Mouse Y");

		gameObject.transform.localEulerAngles = new Vector3 (y_rotation, x_rotation, z_rotation);
		Debug.Log ("X rotation: " + x_rotation + "\n" + "Y rotation: " + y_rotation);
		GetInput ();
	}
}
