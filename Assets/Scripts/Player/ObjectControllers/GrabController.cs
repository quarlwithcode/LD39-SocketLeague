using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour {

	public float grabForce;
	public float grabDistance;
	public Vector2 angle;
	public Transform player;

	public bool endReached = false;

	protected Rigidbody2D rig2D;
	protected Vector2 endPoint;

	public bool tethered = false;

	private GrappleController grapple;

	protected virtual void Awake(){
		rig2D = GetComponent<Rigidbody2D> ();
		grapple = GetComponent<GrappleController> ();
	}

	// Use this for initialization
	protected virtual void Start () {
		rig2D.AddForce (angle*grabForce, ForceMode2D.Impulse);
	}

	// Update is called once per frame
	protected virtual void FixedUpdate () {
		if (Vector2.Distance (this.transform.position, player.position) > grabDistance) {
			endReached = true;
			endPoint = (Vector2)transform.position;
		}

		if (endReached) {
			Vector3 diff = player.position - transform.position;
			diff.Normalize();

			rig2D.velocity = diff * grabForce * 1.5f;
		}
	}

	public void setPlayer(Transform p){
		player = p;
	}

	protected virtual void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Player") {
			if (other.gameObject.name == player.name) {
				Destroy (gameObject);
			} else {
				tethered = true;
			}
		}

		if (other.gameObject.tag == "Outlet") {
			transform.position = other.transform.position;
			rig2D.velocity = Vector2.zero;
			rig2D.isKinematic = true;
			transform.parent = other.transform;
			grapple.enabled = true;
			player.GetComponent<PlayerManager> ().grappled = true;
			grapple.setPlayer(player.GetComponent<PlayerManager> ());
			this.enabled = false;
		}
	}

	protected virtual void OnTriggerStay2D(Collider2D other){

		if (other.gameObject.tag == "Player") {
			if (other.gameObject.name != player.name && !endReached) {
				rig2D.velocity = Vector2.zero;
				rig2D.isKinematic = true;
				transform.parent = other.transform;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player" && tethered) {
			if (other.gameObject.name != player.name && !endReached) {
				rig2D.isKinematic = false;
				tethered = false;
				endReached = true;
			}
		}
	}
}
