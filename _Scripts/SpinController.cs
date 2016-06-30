using UnityEngine;
using System.Collections;

public class SpinController : MonoBehaviour {

	private bool spin = false;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			spin = !spin;
		}

		if (spin) {
			transform.Rotate (0, 1f, 0);
		}
	}
}
