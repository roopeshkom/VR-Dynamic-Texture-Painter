using UnityEngine;
using System.Collections;

public class ObjectPainter : MonoBehaviour {

	public Transform rayOrigin;
	public Material objMat;
	public Color baseCol, addCol;
	public int texSize, brushSize;

	private static Texture2D tex;
	private static RaycastHit hit;
	private static int xPix, yPix;
	private static bool painting;

	void Start(){
		painting = false;

		objMat.mainTexture = null;
		tex = new Texture2D (texSize, texSize, TextureFormat.ARGB32, false);

		for (int i = 0; i < texSize; i++) {
			for (int j = 0; j < texSize; j++) {
				tex.SetPixel (i, j, baseCol);
			}
		}
		
		tex.Apply ();
		objMat.mainTexture = tex;
	}

	public void togglePainting(){
		painting = !painting;
	}

	void Update() {
		if (painting){

			if (Physics.Raycast (rayOrigin.position, rayOrigin.forward, out hit, 100f)) {
				if (hit.collider.CompareTag ("paintable")) {
					xPix = (int)(hit.textureCoord.x * tex.width);
					yPix = (int)(hit.textureCoord.y * tex.height);

					for (int i = 0; i < brushSize/2; i++) {
						for (int j = 0; j < brushSize; j++) {
							tex.SetPixel (xPix + i - brushSize/4, yPix + j - brushSize/2, addCol);
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