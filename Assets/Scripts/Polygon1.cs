using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polygon1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {
		Transform par = other.gameObject.transform.parent;
		if (par != null && par.name == "house2") {
			Destroy (par.gameObject);
		}
	}
}
