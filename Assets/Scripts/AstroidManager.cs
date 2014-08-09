using UnityEngine;
using System.Collections;

public class AstroidManager : MonoBehaviour {

	float maxDistance = 2500;
	float minDistance = -2500;

	int maxAmount = 200;

	GameObject[] astroids;
	public GameObject astroid;

	void SpawnAstroid(){
		float locX = Random.Range (minDistance,maxDistance);
		float locY = Random.Range (minDistance,maxDistance);
		float locZ = Random.Range (minDistance,maxDistance);
		Instantiate (astroid, new Vector3(locX,locY,locZ), Random.rotation );
	}
	// Use this for initialization
	void Start () {
		astroids = new GameObject[maxAmount];
	}
	
	// Update is called once per frame
	void Update () {
		astroids = GameObject.FindGameObjectsWithTag ("Asteroid");
		if(astroids.Length < maxAmount){
			SpawnAstroid();
		}
	}
}
