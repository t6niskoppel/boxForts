using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class fortBuilder : MonoBehaviour {
	private GameObject plank;
	private List<GameObject> cubes = new List<GameObject>();
	// Use this for initialization
	void Start () {
		
		plank = (GameObject)Resources.Load ("Prefabs/Plank", typeof(GameObject));

		//Load cube prefabs into array
		for (int i = 1; i < 7; i++) {
			cubes.Add((GameObject) Resources.Load("Prefabs/Cube "+ i,typeof(GameObject)));
		}


		//buildWall (0, 0, 0, 1, 2, 25);

		//building a fort
		buildWall(4,0,0,1,6,16);
		buildWall (1, 0, 16, 5, 10, 1);
		buildWall (6, 0, 16, 1, 8, 6);
		buildWall (0, 0, 16, 1, 10, 6);
		buildWall (0, 0, 22, 7, 10, 1);
		buildWall (7, 0, 20, 18, 6, 1);
		buildWall (25, 0, 22, 7, 10, 1);
		buildWall (31, 0, 17, 1, 10, 5);
		buildWall (25, 0, 16, 1, 8, 6);
		buildWall(26,0,16,6,10,1);
		buildWall(26,0,0,1,6,16);


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	GameObject cubeSelector(){
		return cubes [Random.Range (1, 6)];
	}


	//Builds a wall and it's reflection along z-axis
	void buildWall(int startX, int startY, int startZ, int lenX,int lenY,int lenZ){
		for (int k = startZ; k < (startZ+lenZ); k++) {
		for (int i = startX; i < (startX+lenX); i++) {
			for (int j = startY; j < (startY+lenY); j++) {
					float l = 2.0f;//cube size 
					Instantiate (cubeSelector ().gameObject, new Vector3 (i*l, (j+0.5f)*l, k*l), Quaternion.identity);
				}
			}
		}

		startZ = -startZ-1;

		for (int k = startZ; k > (startZ-lenZ); k--) {
			for (int i = startX; i < (startX+lenX); i++) {
				for (int j = startY; j < (startY+lenY); j++) {
					float l = 2.0f;
					Instantiate (cubeSelector ().gameObject, new Vector3 (i*l, (j+0.5f)*l, k*l), Quaternion.identity);
				}
			}
		}
	}

		
}

