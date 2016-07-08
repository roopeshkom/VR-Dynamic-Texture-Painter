using UnityEngine;
using System.Collections;

public class CLL{
	public Node front;
	public Node rear;
	public int size;


	public CLL(){
		front = null;
		rear = null;
		size = 0;
	}

	public void AddToRear(Color data){
		Node addition = new Node (data);

		if (size == 0) {
			front = addition;
			front.next = addition;
		} else{
			addition.next = front;
			rear.next = addition;
		}
		rear = addition;

		size++;
	}

	public Color RemoveFromFront(){
		if (size > 0) {
			Color ret = front.data;

			if (size > 1) {
				rear.next = front.next;
				front = front.next;
			} else {
				front = null;
				rear = null;
			}
		
			size--;
			return ret;
		} else {
			
			Debug.Log("There is nothing in the queue");
			return Color.black;
		}
	}
}

