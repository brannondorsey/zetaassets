using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour {
	
	public int numbRows    = 10;
	public float size;
	public int wallSize    = 5;
	public float wallDepth = 0.3f;

	
	public GameObject floor;
	
	void Awake(){
		size = numbRows*wallSize;
		Debug.Log("The size is " + size);
	}
			
	// Use this for initialization
	void Start () {
		CreateFloor();
		GameObject[] horizontalWalls = new GameObject[numbRows*numbRows];
		int i = 0;
		char letter = 'A';
		for(int x = 0; x < horizontalWalls.Length/numbRows; x++){
			//if x is even 
			if(x % 2 == 0) letter++;
				for(int z = 0; z < horizontalWalls.Length/numbRows; z++){
					horizontalWalls[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
					horizontalWalls[i].AddComponent<Wall>().index = letter+""; //add the Wall class script
					horizontalWalls[i].name = "Horizontal Wall"; //name it
					horizontalWalls[i].transform.position = new Vector3(x*wallSize, 0, z*wallSize); //place it
					horizontalWalls[i].transform.localScale = new Vector3(wallSize, wallSize, wallDepth); //scale it
					//horizontalWalls[i].GetComponent<Wall>.index = "A1";
					i++;
				}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	protected void CreateFloor(){
		floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
		floor.transform.localScale = new Vector3(numbRows/2f, 1, (numbRows/2f)-0.5f);
		floor.transform.position = new Vector3(size/2f-wallSize/2-wallDepth, -wallSize/2f, size/2f-wallSize/2-wallDepth);
	}

}
