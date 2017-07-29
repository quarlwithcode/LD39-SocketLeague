using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerState {

	public GameObject testPunch;

	public override void HandleInput (){
		if (Input.GetButtonDown ("Punch")) {
			Punch ();
		}
	}
	public override void Update(){
		base.Update ();
	}

	void Punch(){
		GameObject punchClone;
		punchClone = Instantiate (testPunch, new Vector3 (transform.position.x - 1.05f, transform.position.y), Quaternion.identity) as GameObject;
		PunchController controller = punchClone.GetComponent<PunchController> ();
		controller.angle = Vector2.left;
		controller.setPlayer (player.transform);
		Debug.Log (controller.player.name);
	}
}
