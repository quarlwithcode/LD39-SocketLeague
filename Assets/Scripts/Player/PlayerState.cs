using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour{

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
			player.movement.Move (.25F);
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
}
