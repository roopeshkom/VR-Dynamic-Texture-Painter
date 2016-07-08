using UnityEngine;
using System.Collections;

public class SwabSwapper : MonoBehaviour {

	public static Queue colorCycle;
	private static GameObject[] childSwabs;

	// Use this for initialization
	void Start () {
		colorCycle = new Queue (12);
		for (int i = 0; i < 12; i++) {
			colorCycle.push (Color.black);
		}
		childSwabs = new GameObject[transform.childCount];

		int j = 0;
		foreach (Transform kid in transform) {
			childSwabs [j] = kid.gameObject;
			j++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		Node itr = colorCycle.inter.front;
		do{
			childSwabs[i].GetComponent<Renderer>().material.color = itr.data;
			itr = itr.next;
			i++;
		}while(itr != colorCycle.inter.front);
	}
}
