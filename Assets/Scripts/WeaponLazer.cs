using UnityEngine;
using System.Collections;

public class WeaponLazer : MonoBehaviour {

	// Use this for initialization
	LineRenderer lazer;
	public GameObject lazerHit;
	public UILabel targetStatus;
	void Start () {
		lazer = gameObject.GetComponent<LineRenderer> ();
	}

	void FireLazer(){
		if(!lazer.enabled){
			lazer.enabled = true;
		}

		Vector3 position = Input.mousePosition;
		position.z += 1000;
		Vector3  mouse = Camera.main.ScreenToWorldPoint(position);

		RaycastHit hit = new RaycastHit ();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (gameObject.transform.position, mouse, out hit, 1000)) {
			lazer.SetPosition (0, gameObject.transform.position);
			lazer.SetPosition (1, hit.point);
			GameObject laz = (GameObject)Instantiate(lazerHit,hit.point,gameObject.transform.rotation);
			Destroy(laz,0.5f);

			if(hit.collider.tag == "Asteroid"){
				hit.collider.GetComponent<AstroidBehaviour>().Damage(10f);
			}

		} else if(Physics.Raycast (ray, out hit, 1000)){
			lazer.SetPosition (0, gameObject.transform.position);
			lazer.SetPosition (1, hit.point);
			GameObject laz = (GameObject)Instantiate(lazerHit,hit.point,gameObject.transform.rotation);
			Destroy(laz,0.5f);

			if(hit.collider.tag == "Asteroid"){
				hit.collider.GetComponent<AstroidBehaviour>().Damage(20f);
			}
		} else{
			lazer.SetPosition (0, gameObject.transform.position);
			lazer.SetPosition (1, mouse);	
		}
	}

	void DisplayTarget(){
		RaycastHit hit = new RaycastHit ();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast (ray, out hit, 100000)){
			if(hit.collider.tag == "Asteroid"){
				targetStatus.text = "Target Integrity: " + hit.collider.GetComponent<AstroidBehaviour>().GetHealth().ToString("F0");
			} else {
				targetStatus.text = "Target Integrity: None";
			}
		}
	}

	void ShutOffLazer(){
		lazer.enabled = false;
	}
	// Update is called once per frame
	void Update () {
		DisplayTarget ();
		if(Input.GetMouseButton(0)){
			FireLazer ();
		} else if(Input.GetMouseButtonUp(0)){
			ShutOffLazer();
		}
	}
}
