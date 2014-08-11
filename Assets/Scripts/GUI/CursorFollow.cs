using UnityEngine;
using System.Collections;

public class CursorFollow : MonoBehaviour {

	public Camera nguiCamera;
	// Use this for initialization
	void Start () {
	
	}

	public static Vector3 GetScreenToGuiSpace(Vector3 pos, Transform localSpace, Camera cameraNGUI){
		
		// Since the screen can be of different than expected size, we want to convert
		// mouse coordinates to view space, then convert that to world position.
		pos.x = Mathf.Clamp01(pos.x / Screen.width);
		pos.y = Mathf.Clamp01(pos.y / Screen.height);
		
		//PROJECT INTO WORLD SPACE
		Vector3 posWorld = cameraNGUI.ViewportToWorldPoint(pos);//ABSOLUTE
		
		//CONVERT WORLD SPACE TO LOCAL SPACE
		return localSpace.InverseTransformPoint(posWorld);
		
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.localPosition = GetScreenToGuiSpace( Input.mousePosition, gameObject.transform.parent, nguiCamera);
	}
}
