using UnityEngine;
using System.Collections;

public class DisplayCon : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<Renderer> ().material.color = colorPicker.selectedColor;
	}
}
