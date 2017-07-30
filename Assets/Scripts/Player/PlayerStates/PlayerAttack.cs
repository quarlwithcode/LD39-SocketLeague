using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerState {

	public GameObject punchObj;

	private GameObject punchClone;

	public override void HandleInput (){
		if(player.input.HitGrab()){
			player.setState (GetComponent<PlayerGrab>());
		}
		if (player.input.HitShield ()) {
			player.setState (GetComponent<PlayerShield> ());
		}
	}
	public override void Update(){
		base.Update ();

		if (punchClone == null) {
			player.setState (GetComponent<PlayerRunning> ());
		}
	}

	public override void Action(){
		punchClone = Instantiate (punchObj, new Vector3 (transform.position.x - 1.05f, transform.position.y), Quaternion.identity) as GameObject;
		PunchController controller = punchClone.GetComponent<PunchController> ();
		Vector3 diff = transform.position - player.target.transform.position;
		diff.Normalize ();
		controller.angle = -(Vector2)diff;
		controller.setPlayer (player.transform);
	}
}
