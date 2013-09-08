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
		GameObject[] verticalWalls = new GameObject[numbRows*numbRows];
		int i = 0;
		char letter = 'A';
		for(int x = 0; x < horizontalWalls.Length/numbRows; x++){
				for(int z = 0; z < horizontalWalls.Length/numbRows; z++){
					horizontalWalls[i] = initWall("Horizontal Wall", letter+"", wallSize, wallDepth, x, 0, z);
					i++;
				}
			letter++;
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
	
	protected GameObject initWall(string name, string index, int wallSize, float wallDepth, int x, int y, int z){
		GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
		wall.AddComponent<Wall>().index = index; //add the Wall class script
		wall.name = "Horizontal Wall"; //name it
		wall.transform.position = new Vector3(x*wallSize, y, z*wallSize); //place it
		wall.transform.localScale = new Vector3(wallSize, wallSize, wallDepth); //scale it
		return wall;
	}

}
