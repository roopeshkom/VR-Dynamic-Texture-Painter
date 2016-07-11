using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider other){
		Debug.Log ("hit");

		if (other.CompareTag ("adder")) {
			SwabSwapper.colorCycle.push (colorPicker.selectedColor);
		} else if (other.CompareTag ("swab")) {
			colorPicker.selectedColor = other.gameObject.GetComponent<Renderer> ().material.color;
		}
	}
}
