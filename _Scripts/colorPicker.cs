using UnityEngine;
using System.Collections;

public class colorPicker : MonoBehaviour {

	public GameObject mainPicker, cone, slider, display;
	public Transform fingerPos;

	private static GameObject[,] picker;
	private static Color[] firstColors;
	private static Vector3 location;
	private static Color chosenColor;
	private static bool pickingColor;

	public static Color selectedColor;

	private void Start () {
		picker = new GameObject[40, 40]; 
		firstColors = new Color[40];
		location = this.gameObject.transform.position;
		pickingColor = false;


		CreatePicker (transform);
	}

	private void Update(){
		if (pickingColor) {
			RaycastHit hit;
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Camera.main.WorldToScreenPoint(fingerPos.position)), out hit, 100f)) {
				//Debug.DrawRay (fingerPos.position, hit.point, Color.yellow, 2f);

				if (hit.collider.CompareTag ("maincolors")) {
					Texture2D tex = mainPicker.GetComponent<Renderer> ().material.mainTexture as Texture2D;
					chosenColor = tex.GetPixel ((int)(hit.textureCoord.x * tex.width), (int)(hit.textureCoord.y * tex.height));
					slider.transform.position = new Vector3 (slider.transform.position.x, hit.point.y, slider.transform.position.z);

					ColorPicker ();
				} else if (hit.collider.CompareTag ("pickercell")) {
					selectedColor = hit.collider.gameObject.GetComponent<Renderer> ().material.color;
					cone.transform.position = hit.point + new Vector3 (0, 0, -.5f);
				} else {
					Debug.Log (hit.collider.gameObject);
				}
			}
		}

		display.GetComponent<Renderer> ().material.color = selectedColor;
	}

	public void togglePicking(){
		pickingColor = !pickingColor;
	}

	private static void CreatePicker(Transform parent){
		GameObject[] kids = new GameObject[parent.childCount];
		int i = 0;
		foreach (Transform kid in parent) {
			kids [i] = kid.gameObject;
			i++;
		}

		int j = 0;
		for(int x=0; x<picker.GetLength(0); x++){
			for (int y = 0; y < picker.GetLength (1); y++) {
				picker [x,y] = kids [j];
				j++;
			}
		}
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