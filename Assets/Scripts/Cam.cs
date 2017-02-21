using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cam : MonoBehaviour {
	public Camera camer;
	public Tornado tor_obj;
	public Cow cow_obj;
	public Shark shark_obj;
	public Barn barn_obj;
	public House house_obj;
	public Car car_obj;
	public Canvas can_obj;
	public DummyTornado fake_tor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){

			//Code to be place in a MonoBehaviour with a GraphicRaycaster component
			GraphicRaycaster gr = can_obj.GetComponent<GraphicRaycaster>();
			//Create the PointerEventData with null for the EventSystem
			PointerEventData ped = new PointerEventData(null);
			//Set required parameters, in this case, mouse position
			ped.position = Input.mousePosition;
			//Create list to receive all results
			List<RaycastResult> results = new List<RaycastResult>();
			//Raycast it
			gr.Raycast(ped, results);
			if (results.Count == 0)
				selectionControl ();
		}
		if (tor_obj.transform.position.z - transform.position.z < 36) {
			Vector3 temp = camer.transform.position;
			temp.z = tor_obj.transform.position.z - 36;
			camer.transform.position = temp;
		}
	}
	void reset() {
		tor_obj.selected = false;
		cow_obj.selected = false;
		shark_obj.selected = false;
		barn_obj.selected = false;
		house_obj.selected = false;
		car_obj.selected = false;

		tor_obj.colorChange = true;
		cow_obj.colorChange = true;
		shark_obj.colorChange = true;
		barn_obj.colorChange = true;
		house_obj.colorChange = true;
		car_obj.colorChange = true;
	}

	void selectionControl(){
		RaycastHit hit;
		Ray ray = camer.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
			Transform objectHit = hit.transform;
			Transform parobj;
			if (objectHit.parent != null) {
				reset ();
				parobj = objectHit.parent;
				if (parobj.name == "tornado")
					tor_obj.selected = true;
//				if (parobj.name == "house2")
//					house_obj.selected = true;
				if (parobj.name == "cow")
					cow_obj.selected = true;
				if (parobj.name == "shark")
					shark_obj.selected = true;
				if (parobj.name == "barn")
					barn_obj.selected = true;
				if (parobj.name == "GLX_400_GRP")
					car_obj.selected = true;
			} else {
				if (objectHit.name == "house2") {
					reset ();
					house_obj.selected = true;
				}
				if (objectHit.name == "Terrain") {
					tor_obj.moveto = true;
					tor_obj.targetPos = hit.point;
					reset ();
				}
			}
//			Debug.Log (objectHit.name);
//			Debug.Log (hit.collider.name);
			// Do something with the object that was hit by the raycast.
		} else {
			reset ();
		}
	}

	// scale tornardo with the float value
	public void scaleTor(float scalar){
		
		tor_obj.transform.localScale = new Vector3(scalar, scalar, scalar);
		float scale = fake_tor.pos_scale;
		// scale the orbital of shark object
		shark_obj.transform.localPosition /= scale;
		shark_obj.transform.localPosition *= scalar;
		shark_obj.y_value = shark_obj.transform.position.y;

		// barn scale orbit
		barn_obj.transform.localPosition /= scale;
		barn_obj.transform.localPosition *= scalar;


		// car scale orbit
		car_obj.transform.localPosition /= scale;
		car_obj.transform.localPosition *= scalar;

		fake_tor.pos_scale = scalar;
		Vector3 temp = camer.transform.position;
		if (scalar > 1.30)
			camer.transform.position = new Vector3 (temp.x, temp.y, -40f);
		else
			camer.transform.position = new Vector3 (temp.x, temp.y, -8f);
	}
}
