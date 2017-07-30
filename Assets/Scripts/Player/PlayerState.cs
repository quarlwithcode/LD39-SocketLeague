using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour{

	protected PlayerManager player;

	protected virtual void Awake(){
		player = GetComponent<PlayerManager> ();
	}

	protected virtual void Start(){
		if(player == null)
			player = GetComponent<PlayerManager> ();
	}

	public virtual void Action (){}
	public virtual void HandleInput (){}
	public virtual void Update(){
		HandleInput ();
	}
}
