using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Car : MonoBehaviour {
	private Color selcolor = new Color (0, 0, 0);
	private Color nativecol;
	public bool selected = false;
	public bool colorChange = false;
	public GameObject speed_slider;
	public bool changeDir = false;
	private bool inchange = false;
	private int rotated = 0;
	private float turndir = -3f;
	public Camera car_cam;
	private float pitch_deg = 0f;
	private float yaw_deg = 0f;
	public Slider pitch_slider;
	public Slider yaw_slider;
	public Button mainview;
	public Camera maincam;
	// Use this for initialization
	void Start () {
		Transform temp = transform.GetChild (1).GetChild (2);
		nativecol = temp.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
		speed_slider.SetActive (selected);
		pitch_slider.onValueChanged.AddListener ((value) => pitch (value));
		yaw_slider.onValueChanged.AddListener ((value) => yaw (value));
		mainview.onClick.AddListener(delegate() { 
			car_cam.gameObject.SetActive (false);
			maincam.gameObject.SetActive (true);
		});
	}
	
	// Update is called once per frame
	void Update () {
		speed_slider.SetActive (selected);
		if (colorChange) {
			colorChange = false;
			Color new_color;
			if (selected)
				new_color = selcolor;
			else
				new_color = nativecol;
			GameObject child = this.gameObject.transform.GetChild(1).GetChild(2).gameObject;
			child.GetComponent<Renderer> ().material.SetColor ("_Color", new_color);
		}
		if (changeDir && !inchange) {
			inchange = true;
			changeDir = false;
			turndir = -1 * turndir;
		}
		if (inchange && rotated < 180) {
			rotated = rotated + 3;
			transform.Rotate (Vector3.up * turndir);
			if (rotated == 180) {
				inchange = false;
				rotated = 0;
			}
		}
	}

	void pitch(float value){
		car_cam.transform.Rotate (Vector3.right * ((-1) * pitch_deg));
		car_cam.transform.Rotate (Vector3.right * value);
		pitch_deg = value;
	}
	void yaw(float value){
		car_cam.transform.Rotate (Vector3.up * ((-1) * yaw_deg));
		car_cam.transform.Rotate (Vector3.up * value);
		yaw_deg = value;
	}
}
