using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class FlyCamera : MonoBehaviour {
	public Camera maincam;
	public Camera flycam;
	public Button mainview;
	public int obj_num = 0;
	public Shark sharkobj;
	public Barn barnobj;
	public Cow cowobj;
	public Car carobj;
	// Use this for initialization
	void Start () {
		mainview.onClick.AddListener(delegate() {
			maincam.gameObject.SetActive (true);
			flycam.gameObject.SetActive (false);

		});
	}
	
	// Update is called once per frame
	void Update () {
		if (obj_num == 1)
			transform.position = sharkobj.transform.position;
		if (obj_num == 2) {
			Vector3 temp = barnobj.transform.position;
			temp.y = temp.y - 2;
			transform.position = temp;

		}
		if (obj_num == 3) {
			Vector3 temp = cowobj.transform.position;
			temp.y = temp.y - 2;
			transform.position = temp;
		}

		transform.LookAt (carobj.transform);
	}
}
