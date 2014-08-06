using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

	// Use this for initialization
	Dictionary<string,AudioClip> guiSounds;
	public AudioClip thrusters;
	List<AudioClip> ambientSounds;
	float waitTime = 1.0f;
	public AudioClip ambient001;
	public AudioClip ambient002;

	void Start () {
		guiSounds = new Dictionary<string,AudioClip > ();
		guiSounds.Add ("thrusters",thrusters);

		ambientSounds = new List<AudioClip> ();
		ambientSounds.Add (ambient001);
		ambientSounds.Add (ambient002);

		Invoke("PlayRandomAbience",waitTime);

	}

	public void PlaySoundEffect(string sound, Vector3 position){
		if(guiSounds.ContainsKey(sound)){
			AudioSource.PlayClipAtPoint(guiSounds[sound], position);
		}


	}


	public void PlayRandomAbience(){
		int clip = Random.Range (0,ambientSounds.Count);
		if (clip < ambientSounds.Count) {
			gameObject.audio.clip = ambientSounds[clip];
			gameObject.audio.Play();
			Invoke("PlayRandomAbience",ambientSounds [clip].length);
		} else {
			waitTime = 10.0f;
			Invoke("PlayRandomAbience",waitTime);		
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
