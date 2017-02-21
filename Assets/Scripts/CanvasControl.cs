using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CanvasControl : MonoBehaviour {
	public Slider tor_scale;
	public Camera cam;
	public Slider shark_v_speed;
	public Slider shark_range;
	public Slider shark_rot;
	public Slider barn_spin;
	public Slider barn_rot;
	public Slider car_speed;
	public Dropdown car_direction;
	public Button mainview;
	public Button carview;
	public Button flyview;
	public Camera carcam;
	public Camera flycam;
	// Use this for initialization
	void Start () {
		tor_scale.onValueChanged.AddListener ((value) => cam.GetComponent<Cam> ().scaleTor (value));
		shark_v_speed.onValueChanged.AddListener ((value) => sharkControl (value, 0));
		shark_range.onValueChanged.AddListener ((value) => sharkControl (value, 1));
		shark_rot.onValueChanged.AddListener ((value) => sharkControl (value, 2));
		barn_spin.onValueChanged.AddListener ((value) => barnControl (value, 0));
		barn_rot.onValueChanged.AddListener ((value) => barnControl (value, 1));
		car_speed.onValueChanged.AddListener ((value) => carSpeed (value));
		car_direction.onValueChanged.AddListener(delegate {
			carDir(car_direction.value);
		});
		cam.gameObject.SetActive (true);
		carcam.gameObject.SetActive (false);
		mainview.onClick.AddListener(delegate() { 
			cam.gameObject.SetActive (true);
			carcam.gameObject.SetActive (false);
		});
		carview.onClick.AddListener(delegate() { 
			carcam.gameObject.SetActive (true);
			cam.gameObject.SetActive (false);
		});
		flyview.onClick.AddListener(delegate() { 
			switchCam();
		});
		mainview.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void sharkControl(float value, int choice){
		Shark shark = cam.GetComponent<Cam> ().shark_obj;
		if (choice == 0)
			shark.v_speed = 5f * value;
		if (choice == 1)
			shark.range = value;
		if (choice == 2)
			cam.GetComponent<Cam> ().fake_tor.shark_speed = 50f * value;
	}
	void barnControl(float value, int choice){
		if (choice == 0)
			cam.GetComponent<Cam> ().barn_obj.spin_speed = value;
		if (choice == 1)
			cam.GetComponent<Cam> ().fake_tor.barn_speed = 50f * value;
	}
	void carSpeed(float value){
		cam.GetComponent<Cam> ().fake_tor.car_speed = 50f * value;
	}
	void carDir(int value){
		Car car = cam.GetComponent<Cam> ().car_obj;
		DummyTornado faketor = cam.GetComponent<Cam> ().fake_tor;
		if (value == 0 && faketor.car_dir != -1f) {
			car.changeDir = true;
			faketor.car_dir = -1f;
			return;
		}
		if (value == 1 && faketor.car_dir != 1f) {
			car.changeDir = true;
			faketor.car_dir = 1f;
			return;
		}
	}
	// switch the camera to flying object and activate it
	void switchCam(){
		Cam main_cam = cam.GetComponent<Cam> ();
		FlyCamera f_cam = flycam.GetComponent<FlyCamera> ();
		if (main_cam.shark_obj.selected) {
			f_cam.obj_num = 1;
		} else if (main_cam.barn_obj.selected) {
			f_cam.obj_num = 2;
		} else if (main_cam.barn_obj.transform.FindChild ("cow").gameObject.GetComponent<Cow> ().selected) {
			f_cam.obj_num = 3;
		} else {
			return;
		}
		flycam.gameObject.SetActive (true);
		cam.gameObject.SetActive (false);
	}
}
