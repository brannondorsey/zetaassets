using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour {
	
	public int numbRows    = 10;
	public float size;
	public int wallSize    = 5;
	public float wallDepth = 0.3f;
	public float halfWallDepth;

	
	public GameObject floor;
	
	void Awake(){
		size = numbRows*wallSize;
		halfWallDepth = wallDepth;
		Debug.Log("The size is " + size);
	}
			
	// Use this for initialization
	void Start () {
		CreateFloor();
		//account for the fact that for 10 horizontal unitys 11 walls are needed because an extra wall is needed to close the maze
		numbRows = numbRows+1; 
		GameObject[] horizontalWalls = new GameObject[numbRows*numbRows];
		GameObject[] verticalWalls = new GameObject[numbRows*numbRows];
		int i = 0;
		char letter = 'A';
		int limit = horizontalWalls.Length/numbRows;
		for(int x = 0; x < limit; x++){
				int number = 1;
				for(int z = 0; z < limit; z++){
					if(x != limit-1) horizontalWalls[i] = initWall ("Horizontal Wall", letter+number.ToString(), wallSize, wallDepth, new Vector3((x*wallSize)+wallDepth*2+wallDepth/2, 0, (z*wallSize)-wallDepth/2-halfWallDepth/2), new Vector3(0, 0, 0));
					if(z != limit-1) verticalWalls[i] = initWall ("Vertical Wall", letter+number.ToString(), wallSize, wallDepth, new Vector3((x*wallSize-wallSize/2)+wallDepth/2+halfWallDepth/2, 0, (z*wallSize+wallSize/2)+wallDepth/2+halfWallDepth/2), new Vector3(0, 90, 0));
					number++;
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
		floor.transform.localScale = new Vector3(numbRows/2f, 1, (numbRows/2f));
		floor.transform.position = new Vector3(size/2f-wallSize/2-wallDepth, -wallSize/2f, size/2f-wallDepth);
	}
	
	protected GameObject initWall(string name, string index, int wallSize, float wallDepth, Vector3 position, Vector3 rotation){
		GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
		wall.AddComponent<Wall>().index = index; //add the Wall class script
		wall.name = "Horizontal Wall"; //name it
		wall.transform.position = position; //place it
		wall.transform.Rotate(rotation); //rotate it
		wall.transform.localScale = new Vector3(wallSize, wallSize, wallDepth); //scale it
		return wall;
	}

}
