﻿using UnityEngine;
using System.Collections;

public class DestroyerTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (!other.CompareTag ("Player")) {
			Destroy (other.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
