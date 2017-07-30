using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchController : MonoBehaviour {

	public float punchForce;
	public float punchDistance;
	public Vector2 angle;
	public Transform player;

	protected bool endReached = false;

	protected Rigidbody2D rig2D;
	protected Vector2 endPoint;

	protected virtual void Awake(){
		rig2D = GetComponent<Rigidbody2D> ();

	}

	// Use this for initialization
	protected virtual void Start () {
		rig2D.AddForce (angle*punchForce, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	protected virtual void FixedUpdate () {
		if (Vector2.Distance (this.transform.position, player.position) > punchDistance) {
			endReached = true;
			endPoint = (Vector2)transform.position;
		}

		if (endReached) {
			Vector3 diff = player.position - transform.position;
			diff.Normalize();

			rig2D.velocity = diff * punchForce * 1.5f;
		}
	}

	protected virtual void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Player") {
			if (other.gameObject.name == player.name) {
				Destroy (gameObject);
			}
		} else {
			endReached = true;
		}
	}

	public void setPlayer(Transform p){
		player = p;
	}


}
