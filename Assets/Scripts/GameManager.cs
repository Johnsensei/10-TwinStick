using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	public bool recording = true;

	// Use this for initialization
	void Start () {
		PlayerPrefsManager.UnlockLevel (2);
		print (PlayerPrefsManager.IsLevelUnlocked (1));
		print (PlayerPrefsManager.IsLevelUnlocked (2));

	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton ("Fire1")) {
			recording = false;
		
		} else {
			recording = true;
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			PauseGame ();
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			ResumeGame ();
		}

	}

	void PauseGame (){
		Time.timeScale = 0;
		//Ben said to do the code below but it screws up the frame rate of my game.
		//My guess is because fixedDeltaTime is never returned to 1.
		//Time.fixedDeltaTime = 0;
	}

	void ResumeGame(){
		Time.timeScale = 1f;
		//Time.fixedDeltaTime = 1f;
		//Nope. This actually made it worse.
		//Ben went on to set a private float for initial delta time and then reset it.
		//I don't see the need to even mess with it. The pause worked perfectly. Don't fix what isn't broken.
	}
}
