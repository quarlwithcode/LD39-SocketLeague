using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	[SerializeField]
	private PlayerState currentState;
	[HideInInspector]public Rigidbody2D rig2D;
	[HideInInspector]public PlayerMovement movement;

	void Awake(){
		currentState = GetComponent<PlayerAttack> ();
		rig2D = GetComponent<Rigidbody2D> ();
		movement = GetComponent<PlayerMovement> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setState(PlayerState state){
		currentState = state;
	}
}

