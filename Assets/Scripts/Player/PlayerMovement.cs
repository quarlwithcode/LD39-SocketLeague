using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float maxSpeed = 5;
	public float jumpForce = 10;

	public LayerMask groundLayer;

	PlayerManager player;
	private float distToGround;

	void Awake(){
		player = GetComponent<PlayerManager> ();
		distToGround = GetComponent<Collider2D> ().bounds.extents.y;

	}

	void Update(){
		if (Input.GetButtonDown("Jump")) {
			if (isGrounded ()) {
				Jump ();
			}
		}
	}

	void FixedUpdate(){
		Move ();
	}

	public void Move(){
		player.rig2D.AddForce(Vector2.right*speed*Input.GetAxis("Horizontal"));

		CheckMaxSpeed ();
	}

	void Jump(){
		
		player.rig2D.AddForce (Vector2.up*jumpForce, ForceMode2D.Impulse);
	}

	void CheckMaxSpeed(){
		if (player.rig2D.velocity.x >= maxSpeed) {
			player.rig2D.velocity = new Vector2 (maxSpeed, player.rig2D.velocity.y);
		}
		if (player.rig2D.velocity.x <= -maxSpeed) {
			player.rig2D.velocity = new Vector2 (-maxSpeed, player.rig2D.velocity.y);
		}
		if (player.rig2D.velocity.y >= maxSpeed) {
			player.rig2D.velocity = new Vector2 (player.rig2D.velocity.x, maxSpeed);
		}
		if (player.rig2D.velocity.y <= -maxSpeed) {
			player.rig2D.velocity = new Vector2 (player.rig2D.velocity.x, -maxSpeed);
		}
	}

	bool isGrounded(){
		return Physics2D.Raycast (transform.position, -Vector3.up, 0.6f, groundLayer.value, 0f);
	}
}
