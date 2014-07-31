using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {
	public Camera first;
	public Camera third;
	// Use this for initialization
	void Start () {
		first.enabled = true;
		third.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyUp (KeyCode.F)) {
			first.enabled = !first.enabled;
			third.enabled = !third.enabled;
		}
	}
}