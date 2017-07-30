using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	[SerializeField]
	private PlayerState currentState;
	public GameObject target;
	[HideInInspector]public Rigidbody2D rig2D;
	[HideInInspector]public PlayerMovement movement;
	[HideInInspector]public PlayerInput input;


	void Awake(){
		currentState = GetComponent<PlayerRunning> ();
		rig2D = GetComponent<Rigidbody2D> ();
		movement = GetComponent<PlayerMovement> ();
		input = GetComponent<PlayerInput> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setState(PlayerState state){
		currentState.enabled = false;
		currentState = state;
		currentState.enabled = true;
		currentState.Action ();
	}
}

