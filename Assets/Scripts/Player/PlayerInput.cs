using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool HitPunch(){
		return Input.GetButtonDown ("Punch");
	}

	public bool HitShield(){
		return Input.GetButtonDown ("Shield");
	}

	public bool HitGrab(){
		return Input.GetButtonDown ("Grab");
	}
}
