using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public PlayerManager player;

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Fist") {
			
			PunchController punch = other.gameObject.GetComponent<PunchController> ();

			if (punch.player.name != gameObject.name) {
				print (gameObject.name + " Hit");
				Vector2 diff = punch.GetComponent<Rigidbody2D> ().velocity;
				//Vector3 diff = transform.position - other.transform.position;
				diff.Normalize ();
				print (diff);
				GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
				GetComponent<Rigidbody2D>().AddForce (diff*(punch.punchForce/3), ForceMode2D.Impulse);
			}
		}
	}
}
