using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {
	private Color selcolor = new Color (0, 0, 0);
	private Color nativecol;
	public bool selected = false;
	public bool colorChange = false;
	// Use this for initialization
	void Start () {
		nativecol = transform.GetChild(14).gameObject.GetComponent<Renderer>().material.GetColor("_Color");
	}
	
	// Update is called once per frame
	void Update () {
		if (colorChange) {
			colorChange = false;
			Color new_color;
			if (selected)
				new_color = selcolor;
			else
				new_color = nativecol;
			GameObject child = this.gameObject.transform.GetChild (14).gameObject;
			child.GetComponent<Renderer> ().material.SetColor ("_Color", new_color);

		}
	}
}
