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
		//account for the fact that for 10 horizontal unitys 11 walls are needed because an extra wall is needed to close the maze
		numbRows = numbRows+1; 
		GameObject[] horizontalWalls = new GameObject[numbRows*numbRows];
		GameObject[] verticalWalls = new GameObject[numbRows*numbRows];
		int i = 0;
		char letter = 'A';
		int textureFilename = 0;
		int limit = horizontalWalls.Length/numbRows;
		for(int x = 0; x < limit; x++){
				int number = 1;
				for(int z = 0; z < limit; z++){
					if(x != limit-1){
						horizontalWalls[i] = initWall (textureFilename.ToString(),"Horizontal Wall", letter+number.ToString(), wallSize, wallDepth, new Vector3(x*(wallSize-wallDepth), 0, z*(wallSize-wallDepth)), new Vector3(0, 0, 0));
						textureFilename++;
					}
					if(z != limit-1){
						verticalWalls[i] = initWall (textureFilename.ToString(), "Vertical Wall", letter+number.ToString(), wallSize, wallDepth, new Vector3(x*(wallSize-wallDepth)-(wallSize-wallDepth)/2, 0, z*(wallSize-wallDepth)+(wallSize-wallDepth)/2), new Vector3(0, 90, 0));
						textureFilename++;
					}
					if(textureFilename >= 99) textureFilename = 0; //remove this once there are 200 pictures in the folder
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
		floor.transform.position = new Vector3(size/2f-wallSize/2-wallDepth/2, -wallSize/2f, size/2f-wallDepth);
	}
	
	protected GameObject initWall(string filename, string name, string index, int wallSize, float wallDepth, Vector3 position, Vector3 rotation){
		GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
		wall.transform.parent = transform;
		wall.AddComponent<Wall>().index = index; //add the Wall class script
		wall.name = name; //name it
		wall.transform.position = position; //place it
		wall.transform.Rotate(rotation); //rotate it
		wall.transform.localScale = new Vector3(wallSize, wallSize, wallDepth); //scale it
		wall.renderer.material.mainTexture = Resources.Load("test_images/" + filename.ToString()) as Texture;
		return wall;
	}

}
