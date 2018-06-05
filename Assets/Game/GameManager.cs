using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	public bool isRecording = true;

	private bool isPaused = false;
	private float initialfixedDeltaTime;

	void Start() {
		PlayerPrefsManager.UnlockLevel (2);
		print (PlayerPrefsManager.IsLevelUnlocked(1));
		print (PlayerPrefsManager.IsLevelUnlocked(2));
		initialfixedDeltaTime = Time.fixedDeltaTime;
	}

	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton ("Fire1")) {
			isRecording = false;
		} else {
			isRecording = true;
		}

		if(Input.GetKeyDown(KeyCode.P)){
			isPaused = !isPaused;
		}

		if (isPaused) {
			PauseGame ();
		} else {
			ResumeGame ();
		}
	}

	void PauseGame(){
		Time.timeScale = 0f;
		Time.fixedDeltaTime = 0f;
	}

	void ResumeGame(){
		Time.timeScale = 1f;
		//Time.fixedDeltaTime = 0.02f; // taken from edit > project settings > time: fixed Timestep. . .it was originally 0.02 :)
		Time.fixedDeltaTime = initialfixedDeltaTime; // smarter way: store it in a variable when the game starts ;)
	}

	void OnApplicationPause(bool pauseStatus){
		isPaused = pauseStatus; // it won't call pausegame() / resumegame() . . .we should do it, ben left it to the reader.
	}
}
