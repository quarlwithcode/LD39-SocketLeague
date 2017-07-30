using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour{

	public float maxSpeed = 20;
	protected PlayerManager player;

	protected virtual void Awake(){
		player = GetComponent<PlayerManager> ();
	}

	protected virtual void Start(){
		if(player == null)
			player = GetComponent<PlayerManager> ();
	}

	public virtual void Action (){}
	public virtual void HandleInput (){
		if (player.movement.isGrounded ()) {
			player.movement.Move ();
		} else {
			if(Mathf.Abs(player.rig2D.velocity.x) < maxSpeed)
				player.movement.Move (.015F);
		}


		if (player.input.HitJump()) {
			player.movement.Jump ();
		}
	}
	public virtual void Update(){
		HandleInput ();
	}
	public virtual void LateUpdate(){
		if(player.movement.isGrounded())
			player.movement.ResetVelocity ();
	}

	public virtual void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ground") {
			player.movement.ResetJumps ();
		}
	}
}
