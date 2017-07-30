using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	PlayerManager player;

	// Use this for initialization
	void Awake () {
		player = GetComponent<PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool HitPunch(){
		return Input.GetButtonDown (player.playerStr+"Punch");
	}

	public bool HitShield(){
		return Input.GetButtonDown (player.playerStr+"Shield");
	}

	public bool HitGrab(){
		return Input.GetButtonDown (player.playerStr+"Grab");
	}

	public bool HitJump(){
		return Input.GetButtonDown (player.playerStr+"Jump");
	}
}
