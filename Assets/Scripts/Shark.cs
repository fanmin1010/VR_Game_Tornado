using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shark : MonoBehaviour {
	public float y_value;
	// Use this for initialization
	private Color selcolor = new Color (0, 0, 0);
	private Color nativecol;
	public bool selected = false;
	public bool colorChange = false;

	public float v_speed = 5f;
	public float range = 1f;
	public GameObject sharkpan;

	void Start () {
		y_value = transform.position.y;
		sharkpan.SetActive (selected);
		Transform temp = transform.GetChild (2);
		nativecol = temp.gameObject.GetComponent<Renderer>().material.GetColor("_Color");

	}
	
	// Update is called once per frame
	void Update () {
		float x_value = transform.position.x;
		float z_value = transform.position.z;
		float new_y = y_value + range * Mathf.Sin (Time.time * v_speed);
		bool t_selected = transform.parent.GetComponent<DummyTornado> ().selected;
		if(! (t_selected || selected) )
			transform.position = new Vector3 (x_value, new_y, z_value);
		sharkpan.SetActive (selected);
		if (colorChange) {
			colorChange = false;
			Color new_color;
			if (selected) {
				new_color = selcolor;
			}
			else
				new_color = nativecol;
			GameObject child = this.gameObject.transform.GetChild(2).gameObject;
			child.GetComponent<Renderer> ().material.SetColor ("_Color", new_color);

		}
	}
}
