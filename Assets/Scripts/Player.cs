using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	bool isTouchingGround = false;
	bool wantsToJump = false;
	Rigidbody2D rb; 
	public float speed;
	public float jumpForce;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		wantsToJump = Input.GetButton("Jump");
	}

	void FixedUpdate () {
		if (isTouchingGround) {
			if (wantsToJump){
				rb.velocity = new Vector2(rb.velocity.x, jumpForce);
				wantsToJump = false;
			}
		}
		rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ground") {
			isTouchingGround = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Ground") {
			isTouchingGround = false;
		}
	}
}
