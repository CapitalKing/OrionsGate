using UnityEngine;
using System.Collections;
public class ShipPlayer : MonoBehaviour {
	public float playerSpeed = 1;
	public float x;
	public float z;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () { 
		float speed = playerSpeed;
		//transform.position += transform.forward * Time.deltaTime * speed;
		x = Input.GetAxis("Horizontal") * speed;
		z = Input.GetAxis("Vertical") * speed;
		transform.Translate(x, 0, z);

	}
}