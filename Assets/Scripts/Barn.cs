using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn : MonoBehaviour {
	private Color selcolor = new Color (255, 255, 153);
	private Color nativecol;
	public bool selected = false;
	public bool colorChange = false;
	public GameObject barn_pan;
	public float spin_speed = 1f;

	// Use this for initialization
	void Start () {
		Transform temp = transform.GetChild (12);
		nativecol = temp.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
		barn_pan.SetActive (selected);
	}
	
	// Update is called once per frame
	void Update () {
		barn_pan.SetActive (selected);
		bool t_selected = transform.parent.GetComponent<DummyTornado> ().selected;
		if(! (t_selected || selected) )
			transform.Rotate(Vector3.up * (Time.deltaTime * 100 * spin_speed));
		if (colorChange) {
			colorChange = false;
			Color new_color;
			if (selected) {
				new_color = selcolor;
			}
			else
				new_color = nativecol;
			GameObject child = this.gameObject.transform.GetChild(12).gameObject;
			child.GetComponent<Renderer> ().material.SetColor ("_Color", new_color);
			
		}
	}
}
