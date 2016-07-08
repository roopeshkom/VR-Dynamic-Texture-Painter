using UnityEngine;
using System.Collections;

public class Queue{

	public CLL inter;
	public int max;

	public Queue(int max){
		this.max = max;
		inter = new CLL ();
	}

	public void push(Color data){
		if (inter.size < max) {
			inter.AddToRear (data);
		} else {
			pop ();
			push (data);
		}
	}

	public Color pop(){
		return inter.RemoveFromFront ();
	}

	public Color peek(){
		return inter.front.data;
	}
}
