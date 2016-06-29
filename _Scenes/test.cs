using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	
	void Update() {
		if (Input.GetMouseButton (0)) {

			RaycastHit hit;
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100f)) {

				Renderer rend = hit.transform.GetComponent<Renderer> ();
				MeshCollider meshCollider = hit.collider as MeshCollider;

				if (rend == null) {
					Debug.Log ("no rend");
				}
				else if(rend.sharedMaterial == null){
					Debug.Log("no shared mat");
				}
				else if(rend.sharedMaterial.mainTexture == null){
					Debug.Log("no main tex");
				}
				else if(meshCollider == null){
					Debug.Log("no mesh collider");
				}
				else {
					Debug.Log (hit.textureCoord);
					Texture2D tex = rend.material.mainTexture as Texture2D;
					Vector2 pixelUV = hit.textureCoord;
					pixelUV.x *= tex.width;
					pixelUV.y *= tex.height;


					tex.SetPixel ((int)pixelUV.x, (int)pixelUV.y, Color.red);
					tex.Apply ();
				}
			}
		}
	}
}