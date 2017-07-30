using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour {

	public float speed = 5;
	public float maxDist = 2;
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float movementSpeedX = speed * Input.GetAxis ("Player1AimX");
		float movementSpeedY = speed * Input.GetAxis ("Player1AimY");

		Vector2 testVector = new Vector2 (transform.position.x + movementSpeedX, transform.position.y + movementSpeedY);
		float testDist = Vector2.Distance (testVector, (Vector2)player.transform.position);

		if (testDist < maxDist) {
			transform.Translate (movementSpeedX, movementSpeedY, 0);
		} else {
			transform.position = Vector2.Lerp((Vector2)player.transform.position, testVector, maxDist/testDist);
			transform.position -= Vector3.forward;
		}
	}
}
