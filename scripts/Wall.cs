using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{
	public string index = "test";
	
	// Use this for initialization
	public void Constructor (int size, float depth, int x, int z)
	{
		 GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
		 wall.name = "horizontalWall";
         wall.transform.position = new Vector3(x*size, 0, z*size);
		 wall.transform.localScale = new Vector3(size, size, depth);
		 Debug.Log ("this happened");
	}
	
	void Start(){
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

