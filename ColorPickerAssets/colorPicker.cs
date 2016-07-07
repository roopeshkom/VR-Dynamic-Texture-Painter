using UnityEngine;
using System.Collections;

public class colorPicker : MonoBehaviour {

	public GameObject pickerCell, mainPicker, cone, slider, standin;
	public int xSize, ySize;

	private static GameObject[,] picker;
	private static Color[] firstColors;
	private static Vector3 location;
	private static Color chosenColor;

	public static Color selectedColor;

	private void Start () {
		standin.SetActive (false);

		picker = new GameObject[xSize, ySize]; 
		firstColors = new Color[ySize];
		location = this.gameObject.transform.position;

		CreatePicker (pickerCell, transform);
	}

	private void Update(){
		if (Input.GetMouseButton(0)) {
			RaycastHit hit;
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100f)) {
				if (hit.collider.CompareTag ("maincolors")) {
					Texture2D tex = mainPicker.GetComponent<Renderer> ().material.mainTexture as Texture2D;
					chosenColor = tex.GetPixel ((int)(hit.textureCoord.x * tex.width), (int)(hit.textureCoord.y * tex.height));
					slider.transform.position = new Vector3 (0, hit.point.y, -.01f);

					ColorPicker ();
				} else if (hit.collider.CompareTag ("pickercell")) {
					selectedColor = hit.collider.gameObject.GetComponent<Renderer> ().material.color;
					cone.transform.position = hit.point + new Vector3 (0, 0, -.5f);
				}
			}
		}
	}

	private static void CreatePicker(GameObject pickerCell, Transform parent){
		float xStart = location.x;
		float yStart = location.y;

		for(int i=0; i<picker.GetLength(0); i++) {
			for(int j=0; j<picker.GetLength(1); j++) {
				picker[i, j] = Instantiate (pickerCell, location, Quaternion.Euler (Vector3.zero)) as GameObject;
				picker [i, j].transform.parent = parent;

				location.x += .1f;
			}

			location.x = xStart;
			location.y -= .1f;
		}

		location.y = yStart;
	}

	private static void ColorPicker(){
		for (int i = 0; i < picker.GetLength (0); i++) {
			for (int j = 0; j < picker.GetLength (1); j++) {
				Color add;
				if (i == 0) {
					add = Color.Lerp (Color.white, chosenColor, j / (float)picker.GetLength(1));
					firstColors [j] = add;
				} else {
					add = Color.Lerp (firstColors [j], Color.black, i / (float)picker.GetLength(0));
				}

				picker [i, j].GetComponent<Renderer> ().material.color = add;
			}
		}
	}
}