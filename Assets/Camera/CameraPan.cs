using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	//for moving stuff - update. for rendering result of movement - use lateupdate :) it's smoother that way
	void LateUpdate () {
		transform.LookAt (player.transform);
	}

}
