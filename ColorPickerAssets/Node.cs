using UnityEngine;
using System.Collections;

public class Node{

	public Color color;
	public Node next;

	public Node(Color color){
		this.color = color;
		this.next = null;
	}
}
