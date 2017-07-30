using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : PlayerState {

	public GameObject grabObj;
	private GameObject grabClone;
	public float minDist = .5f;

	public override void HandleInput (){
		base.HandleInput ();
		if (player.input.HitShield ()) {
			player.setState (GetComponent<PlayerShield> ());
		}

		if (player.input.HitGrab () && grabClone != null) {
			grabClone.GetComponent<GrabController> ().endReached = true;
		}
	}
	public override void Update(){
		base.Update ();

		if (grabClone == null) {
			player.setState (GetComponent<PlayerRunning> ());
		}

		if (player.grappled) {
			player.setState (GetComponent<PlayerGrappled>());
		}
	}

	public override void Action(){
		if (player.aim.facingRight) {
			grabClone = Instantiate (grabObj, new Vector3 (transform.position.x + 1.15f, transform.position.y), Quaternion.identity) as GameObject;
		} else {
			grabClone = Instantiate (grabObj, new Vector3 (transform.position.x - 1.15f, transform.position.y), Quaternion.identity) as GameObject;
		}
		player.grabObj = grabClone;
		GrabController controller = grabClone.GetComponent<GrabController> ();


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
