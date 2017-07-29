using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchController : MonoBehaviour {

	public float punchForce;
	public float punchDistance;
	public Vector2 angle;
	public Transform player;

	bool endReached = false;

	private Rigidbody2D rig2D;
	private Vector2 endPoint;

	void Awake(){
		rig2D = GetComponent<Rigidbody2D> ();

	}

	// Use this for initialization
	void Start () {
		rig2D.AddForce (angle*punchForce, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == player.name) {
			Destroy (gameObject);
		}
	}

	public void setPlayer(Transform p){
		player = p;
	}


}
