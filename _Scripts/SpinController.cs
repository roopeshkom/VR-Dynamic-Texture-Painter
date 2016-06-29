using UnityEngine;
using System.Collections;

public class SpinController : MonoBehaviour {

	public bool spin = true;
	
	// Update is called once per frame
	void Update () {
		if (spin) {
			transform.Rotate (0, 1f, 0);
		}
	}
}
