using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerState {

	PlayerPunch punch;

	protected override void Awake(){
		punch = GetComponent<PlayerPunch> ();
	}
	public override void HandleInput (){}
	public override void Update(){
		base.Update ();
	}

	void Punch(){
		punch.enabled = true;
	}
}
