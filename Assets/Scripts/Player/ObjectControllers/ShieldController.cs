using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {

	public float maxLifetime = 1f;
	private float lifeTime;


	// Use this for initialization
	void Start () {
		lifeTime = maxLifetime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		lifeTime -= Time.deltaTime;

		if (lifeTime <= 0) {
			Destroy (gameObject);
		}
	}
}
