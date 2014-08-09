using UnityEngine;
using System.Collections;

public class DustBehaviour : MonoBehaviour {

	float vanishDistance = 10000;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(gameObject.transform.position, Camera.main.transform.position) > vanishDistance){
			Destroy(gameObject);
		}
	}
}
