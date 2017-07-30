using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabbed : PlayerState {

	public override void Action(){
		player.movement.enabled = false;
	}

	public override void HandleInput(){
		player.movement.Move (.5F);

		if (player.input.HitJump()) {
			player.movement.Jump (.5F);
		}
	}

	void OnDisable(){
		player.movement.enabled = true;
	}
}
