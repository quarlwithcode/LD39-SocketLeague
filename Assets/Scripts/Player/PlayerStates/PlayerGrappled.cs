using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrappled : PlayerState {

	public override void Action(){
		player.movement.enabled = false;
	}

	public override void HandleInput(){
		player.movement.Move (.25F);

		if (player.input.HitGrab ()) {
			if (player.grabObj != null) {
				player.grabObj.GetComponent<GrappleController> ().returnToPlayer = true;
				player.setState (GetComponent<PlayerRunning>());
			}
		}

	}

	public override void LateUpdate(){
		
	}

	void OnDisable(){
		player.movement.enabled = true;
	}
}
