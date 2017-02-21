using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTornado : MonoBehaviour {
	public GameObject tornado;
	public bool selected = false;
	public float shark_speed = 50f;
	public float barn_speed = 50f;
	public float car_speed = 50f;
	public float car_dir = -1f;
	public float pos_scale = 1f;
	// Use this for initialization
	void Start () {
		transform.position = tornado.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = tornado.transform.position;
		selected = tornado.GetComponent<Tornado> ().selected;
		if (!selected) {
			transform.GetChild (0).transform.RotateAround (transform.position, Vector3.up, (-1)* shark_speed * Time.deltaTime);
			transform.GetChild (1).transform.RotateAround (transform.position, Vector3.up, (-1)* barn_speed * Time.deltaTime);
			transform.GetChild (2).transform.RotateAround (transform.position, Vector3.up, car_dir * car_speed * Time.deltaTime);
		}
	}
}
