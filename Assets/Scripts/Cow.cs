using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour {
	private Color selcolor = new Color (0, 0, 0);
	private Color nativecol;
	public bool selected = false;
	public bool colorChange = false;
	private Vector3 ori_pos;
	// Use this for initialization
	void Start () {
		nativecol = transform.GetChild(0).gameObject.GetComponent<Renderer>().material.GetColor("_Color");
		ori_pos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		// translate the cow in and out of the barn
		DummyTornado fake_t = transform.parent.parent.GetComponent<DummyTornado> ();
		float scale_tran = fake_t.pos_scale * 1.3f;

		Vector3 temp = new Vector3 (ori_pos.x, ori_pos.y, ori_pos.z + (Mathf.Sin (Time.time) - 1) * scale_tran);
		if (!fake_t.selected)
			transform.localPosition = temp;

		if (colorChange) {
			colorChange = false;
			Color new_color;
			if (selected)
				new_color = selcolor;
			else
				new_color = nativecol;
			GameObject child = this.gameObject.transform.GetChild (0).gameObject;
			child.GetComponent<Renderer> ().material.SetColor ("_Color", new_color);

		}
	}
}
