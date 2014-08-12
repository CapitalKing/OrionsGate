using UnityEngine;
using System.Collections;

public class AstroidBehaviour : MonoBehaviour {

	// Use this for initialization
	float scale;
	public float health = 100;
	public int OreCredit;
	public GameObject explosion;

	public void Damage(float d){
		if (health > 0) {
			health -= d;
		} else {
			GameObject exp = (GameObject)Instantiate(explosion,gameObject.transform.position,gameObject.transform.rotation);
			Destroy (exp,2);
			Destroy(gameObject);
			Economy.Credits += OreCredit;
		}
	}

	public float GetHealth(){
		return health;
	}

	void RandomVelocity(){
		float velX = Random.Range (-50,50);
		float velY = Random.Range (-50,50);
		float velZ = Random.Range (-50,50);
		gameObject.rigidbody.velocity = new Vector3 (velX,velY,velZ);
	}

	void Start () {
		scale = Random.Range(1f, 50f);
		health *= scale;
		OreCredit = Random.Range (100, 1000);
		gameObject.transform.localScale *= scale;
		RandomVelocity ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(Vector3.zero,gameObject.transform.position) > 10000){
			Destroy(gameObject);
		}
	}
}
