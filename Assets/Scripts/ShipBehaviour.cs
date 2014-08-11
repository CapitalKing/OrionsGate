using UnityEngine;
using System.Collections;

public class ShipBehaviour : MonoBehaviour {

	public UILabel hullStatus;
	
	float hullTotalIntegrity = 1000;
	float hullCurrentIntegrity = 1000;
	bool isAlive = true;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision collision) {
		float damage = Vector3.Dot (collision.rigidbody.velocity.normalized, collision.rigidbody.velocity) * collision.rigidbody.mass;
		hullCurrentIntegrity -= damage;
	}


	// Update is called once per frame
	void Update () {
		if (isAlive) {
			if(hullCurrentIntegrity <= 0){
				gameObject.GetComponent<ShipMovement>().enabled = false;
				gameObject.GetComponent<CameraSwitch>().SwitchCamera();
				gameObject.GetComponent<MeshRenderer>().enabled = false;
				gameObject.GetComponent<Collider>().enabled = false;
				Destroy(gameObject.GetComponent<Rigidbody>());
				GameObject exp = (GameObject)Instantiate(explosion,gameObject.transform.position,gameObject.transform.rotation);
				isAlive = false;
			}	
		}
		hullStatus.text = "Hull Integrity: " + ((hullCurrentIntegrity/hullTotalIntegrity) * 100).ToString("F0") + "%";
	}
}
