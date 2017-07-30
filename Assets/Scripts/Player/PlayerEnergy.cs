using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour {

	public float maxEnergy = 100;
	public float currEnergy;

	public float lossTime = 3;
	public float lossAmount = 5;

	private float lossCooldown;

	// Use this for initialization
	void Start () {
		currEnergy = maxEnergy;
		lossCooldown = lossTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (currEnergy <= 0) {
			Die ();
		}
	}

	void FixedUpdate(){
		lossCooldown -= Time.deltaTime;

		if (lossCooldown <= 0) {
			currEnergy -= lossAmount;
			lossCooldown = lossTime;
		}
	}

	void Die(){
		Destroy (gameObject);
	}
}
