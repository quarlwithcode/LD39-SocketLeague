using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour {

	public GameObject testPunch;

	void Punch(){
		GameObject punchClone;
		punchClone = Instantiate (testPunch, new Vector3 (transform.position.x + GetComponent<Collider2D> ().bounds.extents.x, transform.position.y), Quaternion.identity) as GameObject;
		punchClone.GetComponent<PunchController> ().angle = Vector2.right;
	}
}
