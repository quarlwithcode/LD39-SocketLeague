using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchController : MonoBehaviour {

	public float punchForce;
	public Vector2 angle;

	bool endReached = false;

	private Rigidbody2D rig2D;


	void Awake(){
		rig2D = GetComponent<Rigidbody2D> ();

	}

	// Use this for initialization
	void Start () {
		rig2D.AddForce (angle*punchForce, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
}
