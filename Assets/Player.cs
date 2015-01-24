﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public GameObject rope; 
	public GameObject currentRope;
	public Player partner;
	public float jumpSpeed = 5;
	public float moveSpeed = 5;

	public KeyCode jump = KeyCode.UpArrow;
	public KeyCode left = KeyCode.LeftArrow;
	public KeyCode right = KeyCode.RightArrow;
	public KeyCode grab = KeyCode.RightShift;


	private float spawnPointTime;
	private Vector3 spawnPoint;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (jump) && IsGrounded ()) {
			rigidbody.
			rigidbody.AddForce(new Vector3(0,jumpSpeed,0));
		}
		if (Input.GetKeyDown (left)) {
			rigidbody.AddForce(new Vector3(-moveSpeed,0,0));
		}
		if (Input.GetKeyDown (right)) {
			rigidbody.AddForce(new Vector3(moveSpeed,0,0));
		}
		if (Input.GetKeyDown (grab)) {
			rigidbody.velocity.Set(0,0,0);
		}

		//rigidbody.AddForce (new Vector3 (Input.GetAxis("Horizontal")*10, 0));
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Death")) {
			Respawn();		
		} else if (other.CompareTag ("CheckPoint")) {
			spawnPoint = other.transform.position;
			spawnPointTime = Time.time;
		}
	}

	void Respawn() {
		Vector3 currentSpawnPoint;
		if (partner.spawnPointTime > spawnPointTime) {
			currentSpawnPoint = spawnPoint;
		} else {
			currentSpawnPoint = partner.spawnPoint;
		}

		Destroy (currentRope);

		//move player to last checkpoint
		transform.position = currentSpawnPoint + 2*Vector3.right;
		rigidbody.velocity = Vector3.zero;
		//move partner to last checkpoint
		partner.transform.position = currentSpawnPoint + 2*Vector3.left;
		partner.rigidbody.velocity = Vector3.zero;
		//move rope
		currentRope = Instantiate (rope, currentSpawnPoint, Quaternion.identity) as GameObject;
		partner.currentRope = currentRope;

		currentRope.
	}

	bool IsGrounded() {
		return Physics.CheckCapsule(collider.bounds.center,new Vector3(collider.bounds.center.x,collider.bounds.min.y-0.1f,collider.bounds.center.z),0.18f);
	}

}
