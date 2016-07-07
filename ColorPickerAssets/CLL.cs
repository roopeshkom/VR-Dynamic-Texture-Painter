using UnityEngine;
using System.Collections;

public class CLL{
	public Node front;
	public Node rear;
	public int size, limit;


	public CLL(int limit){
		this.limit = limit;
		size = 0;

		front = null;
		rear = null;
	}

	public void AddToRear(Color data){
		if (size < limit) {
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
	}
}

