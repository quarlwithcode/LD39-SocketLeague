using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public enum PlayerStates
	{
		Running,Attacking,Shielding,Grabbing,Grabbed,Knocked
	}

	public bool isPlayer2 = false;

	[SerializeField]
	private PlayerState currentState;
	public GameObject target;
	public int playerNum;
	[HideInInspector]public string playerStr;
	[HideInInspector]public Rigidbody2D rig2D;
	[HideInInspector]public PlayerMovement movement;
	[HideInInspector]public PlayerInput input;
	[HideInInspector]public PlayerAim aim;
	[HideInInspector]public PlayerCollision collision;
	[HideInInspector]public GameObject grabObj;
	public bool grappled;

	void Awake(){
		currentState = GetComponent<PlayerRunning> ();
		rig2D = GetComponent<Rigidbody2D> ();
		movement = GetComponent<PlayerMovement> ();
		input = GetComponent<PlayerInput> ();
		aim = target.GetComponent<PlayerAim> ();
		collision = GetComponent<PlayerCollision> ();
		collision.player = this;

		playerStr = "Player" + playerNum;
		print (playerStr);
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

