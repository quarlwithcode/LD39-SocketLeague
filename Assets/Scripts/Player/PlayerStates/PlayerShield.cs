using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : PlayerState {

	public GameObject shieldObj;
	private GameObject shieldClone;

	public override void HandleInput (){
		base.HandleInput ();
		if(player.input.HitGrab()){
			player.setState (GetComponent<PlayerGrab>());
		}
		if (player.input.HitPunch ()) {
			player.setState (GetComponent<PlayerAttack>());
		}
	}
	public override void Update(){
		base.Update ();

		if (shieldClone == null) {
			player.setState (GetComponent<PlayerRunning> ());
		}
	}

	public override void Action(){
		
		shieldClone = Instantiate (shieldObj, transform.position, Quaternion.identity) as GameObject;
		shieldClone.transform.SetParent (this.transform);
	}
}
