using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float jumpForce = 10;

	public LayerMask groundLayer;
	public int jumps = 1;

	PlayerManager player;
	private float distToGround;


	void Awake(){
		player = GetComponent<PlayerManager> ();
		distToGround = GetComponent<Collider2D> ().bounds.extents.y;

	}

	void Update(){
		
	}

	void FixedUpdate(){
		
	}

	void LateUpdate(){
		
	}

	public void Move(){
		player.rig2D.AddForce(Vector2.right*speed*Input.GetAxis(player.playerStr+"Horizontal"));
	}

	public void Move(float speedMult){
		player.rig2D.AddForce(Vector2.right*speed*speedMult*Input.GetAxis(player.playerStr+"Horizontal"));
	}

	public void ResetVelocity(){
		player.rig2D.velocity = new Vector2(0, player.rig2D.velocity.y);
	}

	public void Jump(){
		
		if (jumps > 0) {
			player.rig2D.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	public void Jump(float jumpMult){

		if (jumps > 0) {
			if (player.rig2D.velocity.y < 0) {
				player.rig2D.velocity = new Vector2 (player.rig2D.velocity.x, 0);
				player.rig2D.AddForce (Vector2.up * jumpForce * jumpMult, ForceMode2D.Impulse);
			} else {
				player.rig2D.AddForce (Vector2.up * jumpForce * jumpMult, ForceMode2D.Impulse);
			}

		}
	}

	public void ResetJumps(){
		jumps = 1;
	}

	public bool isGrounded(){
		return Physics2D.Raycast (transform.position, -Vector3.up, 0.6f, groundLayer.value, 0f);
	}
}
