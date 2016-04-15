﻿using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour {

	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate(){
		transform.LookAt(player.transform);
	}
}
