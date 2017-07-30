using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleController : MonoBehaviour {

	DistanceJoint2D joint;
	public float returnSpeed;
	public PlayerManager player;
	public GrabController grab;
	public bool returnToPlayer;

	private Rigidbody2D rig2D;
	// Use this for initialization
	void Start () {
		grab = GetComponent<GrabController> ();
		rig2D = GetComponent<Rigidbody2D> ();
		joint = GetComponent<DistanceJoint2D> ();
		joint.enabled = true;

		joint.connectedBody = player.rig2D;
		returnToPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (returnToPlayer) {
			Destroy (gameObject);
		}
	}

	public void setPlayer(PlayerManager p){
		player = p;
	}
}
