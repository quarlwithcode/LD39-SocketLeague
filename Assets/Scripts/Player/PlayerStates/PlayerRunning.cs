using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : PlayerState {

	public override void HandleInput(){
		base.HandleInput ();
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

	public override void Update ()
	{
		base.Update ();
	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Plug") {
			if(other.gameObject.GetComponent<GrabController>().player.name != gameObject.name)
				player.setState (GetComponent<PlayerGrabbed> ());
		}
	}
}
