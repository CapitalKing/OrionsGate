using UnityEngine;
using System.Collections;
// I will add a description im just way to tired right now.. it shoots lasers.
public class BasicLaser : MonoBehaviour {
	public Rigidbody projectile;
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetButtonDown("Fire1"))
		{
			Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;

			instantiatedProjectile.velocity = transform.TransformDirection( new Vector3(0, 0, speed));
			                                                                          
			//Physics.IgnoreCollision(instantiatedProjectile.Collider, transform.root.Collider);
			//Destroy(projectile.gameObject, 10);
		}
	}
}