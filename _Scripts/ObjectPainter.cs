using UnityEngine;
using System.Collections;

public class ObjectPainter : MonoBehaviour {

	public Material objMat;
	public Color baseCol, addCol;

	private static Texture2D tex;

	void Start(){
		tex = new Texture2D (1024, 1024, TextureFormat.ARGB32, false);

		for (int i=0; i<1024; i++) {
			for (int j = 0; j < 1024; j++) {
				tex.SetPixel (i, j, baseCol);
			}
		}
			
		tex.Apply ();
		objMat.mainTexture = tex;
	}

	void Update() {
		if (Input.GetMouseButton (0)) {

			RaycastHit hit;
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100f)) {

				if (hit.collider.CompareTag ("paintable")) {
					int xPix = (int)(hit.textureCoord.x * tex.width);
					int yPix = (int)(hit.textureCoord.y * tex.height);

					for (int i = 0; i < 29; i++) {
						for (int j = 0; j < 29; j++) {
							tex.SetPixel (xPix + i, yPix + j, addCol);
						}
					}

					tex.Apply ();
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			objMat.mainTexture = null;
			Application.Quit ();
			UnityEditor.EditorApplication.isPlaying = false;
		}
	}
}