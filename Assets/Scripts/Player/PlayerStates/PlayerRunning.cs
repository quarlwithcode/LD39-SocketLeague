using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : PlayerState {

	public override void HandleInput(){
		if(player.input.HitGrab()){
			player.setState (GetComponent<PlayerGrab>());
		}
		if (player.input.HitPunch ()) {
			player.setState (GetComponent<PlayerAttack>());
		}
		if (player.input.HitShield ()) {
			player.setState (GetComponent<PlayerShield> ());
		}
	}
}
