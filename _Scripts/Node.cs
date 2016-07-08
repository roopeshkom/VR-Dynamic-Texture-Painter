using UnityEngine;
using System.Collections;

public class Node{

	public Color data;
	public Node next;

	public Node(Color data){
		this.data = data;
		this.next = null;
	}
}
