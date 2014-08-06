using UnityEngine;
using System.Collections;

public class WeaponLazer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void FireLazer(){
		Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
				Plane p = new Plane (Vector3.up,r.origin);
				LineRenderer line = gameObject.GetComponent<LineRenderer> ();
				line.SetPosition (0, gameObject.transform.position);
				line.SetPosition (1, );
		}
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetMouseButton(0)){
			FireLazer ();
		}
	}
}
