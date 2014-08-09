using UnityEngine;
using System.Collections;

public class DustManager : MonoBehaviour {
	
	float maxDistance = 2500;
	float minDistance = -2500;
	
	int maxAmount = 5;
	
	GameObject[] clouds;
	public GameObject dust;
	
	void SpawnDust(){
		float locX = Random.Range (minDistance,maxDistance);
		float locY = Random.Range (minDistance,maxDistance);
		float locZ = Random.Range (minDistance,maxDistance);
		Instantiate (dust, new Vector3(locX,locY,locZ), Random.rotation );
	}
	// Use this for initialization
	void Start () {
		clouds = new GameObject[maxAmount];
	}
	
	// Update is called once per frame
	void Update () {
		clouds = GameObject.FindGameObjectsWithTag ("Dust");
		if(clouds.Length < maxAmount){
			SpawnDust();
		}
	}
}
