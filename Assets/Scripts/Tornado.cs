using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour {
	private Color selcolor = new Color (0, 0, 0);
	private Color nativecol;
	public bool selected = false;
	public bool colorChange = false;
	public bool moveto = false;
	public Vector3 targetPos;
	public GameObject t_panel;

	//public GameObject tornado;
	// Use this for initialization
	void Start () {
		//Renderer rend = GetComponent<Renderer>();
		//rend.material.SetColor("_Color", greycolor);
		nativecol = transform.GetChild(0).gameObject.GetComponent<Renderer>().material.GetColor("_Color");
	}
	
	// Update is called once per frame
	void Update () {
		if(!selected)
			transform.RotateAround (transform.position, Vector3.up, -50 * Time.deltaTime);
		
		t_panel.SetActive (selected);
		if (colorChange) {
			colorChange = false;
			Color new_color;
			if (selected)
				new_color = selcolor;
			else
				new_color = nativecol;
				
			int count = transform.childCount;
			for (int i = 0; i < count; i++) {
				GameObject child = this.gameObject.transform.GetChild (i).gameObject;
				child.GetComponent<Renderer> ().material.SetColor ("_Color", new_color);
			}
		}
		if (moveto && !selected) {
			transform.position = Vector3.MoveTowards (transform.position, targetPos, 2f* Time.deltaTime);
			if (transform.position == targetPos)
				moveto = false;
		}
	}

}
