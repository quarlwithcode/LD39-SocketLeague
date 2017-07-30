using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerState {

	public GameObject punchObj;
	public float minDist = .5f;
	private GameObject punchClone;

	public override void HandleInput (){
		base.HandleInput ();
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
		if (player.aim.facingRight) {
			punchClone = Instantiate (punchObj, new Vector3 (transform.position.x + 1.05f, transform.position.y), Quaternion.identity) as GameObject;
		} else {
			punchClone = Instantiate (punchObj, new Vector3 (transform.position.x - 1.05f, transform.position.y), Quaternion.identity) as GameObject;
		}

		PunchController controller = punchClone.GetComponent<PunchController> ();

		if (Vector2.Distance (transform.position, player.target.transform.position) < minDist) {
			
			if (player.aim.facingRight) {
				controller.angle = Vector2.right;
			} else {
				controller.angle = Vector2.left;
			}
		} else {
			Vector3 diff = transform.position - player.target.transform.position;
			diff.Normalize ();
			controller.angle = -(Vector2)diff;
		}

		controller.setPlayer (player.transform);
	}
}
