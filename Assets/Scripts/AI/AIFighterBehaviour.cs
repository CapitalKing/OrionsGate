using UnityEngine;
using System.Collections;

public class AIFighterBehaviour : MonoBehaviour {

	GameObject player;
	float rotationSpeed = 0.99f;
	float closestProximity = 10.0f;
	float nearProximit = 20.0f;
	float maxSpeed = 500.0f;
	float baseSpeed = 15.0f;
	float alertDistance = 10000;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	float DistanceToTarget(GameObject t){
		return Vector3.Distance (gameObject.transform.position, t.transform.position);
	}

	bool CheckTarget(GameObject t){
		RaycastHit hit = new RaycastHit ();
		Ray ray =  new Ray(transform.position, transform.forward);
		if (Physics.Raycast (ray, out hit, alertDistance)) {
			if(hit.collider.tag == t.tag){
				return true;
			}
		}
		return false;
	}

	void FaceTarget(GameObject t){
		Quaternion targetRotation = Quaternion.LookRotation (t.transform.position - gameObject.transform.position);
		float rotationStrength = Mathf.Min (Time.deltaTime * rotationSpeed, 1);
		transform.rotation = Quaternion.Lerp (gameObject.transform.rotation, targetRotation, rotationStrength);
	}

	void ApproachTarget(GameObject t){
		if(DistanceToTarget(t) > nearProximit){
			if(CheckTarget(player)){
				if(gameObject.rigidbody.velocity.magnitude < maxSpeed){
					gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, t.transform.position, baseSpeed * Time.deltaTime);
				}
			}
		} else if(DistanceToTarget(t) < closestProximity) {

		}
	}

	// Update is called once per frame
	void Update () {
		if(DistanceToTarget(player) < alertDistance){
			FaceTarget (player);
			ApproachTarget(player);
		}
	}
}
