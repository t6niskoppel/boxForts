using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class fortBuilder : MonoBehaviour {
	private GameObject plank;
	private List<GameObject> cubes = new List<GameObject>();
	private List<Material> materials = new List<Material>();
	// Use this for initialization
	void Start () {
		
		plank = (GameObject)Resources.Load ("Prefabs/Plank", typeof(GameObject));

		//Load cube prefabs into array
		for (int i = 1; i < 7; i++) {
			cubes.Add((GameObject) Resources.Load("Prefabs/Cube "+ i,typeof(GameObject)));
		}

		for (int i = 1; i < 7; i++) {
			materials.Add((Material) Resources.Load("Materials/Cube"+ i,typeof(Material)));
		}

		//buildWall (0, 0, 0, 1, 2, 25);
		 //backup

		buildWall(4,0,0,1,6,16);
		buildWall (1, 0, 16, 5, 14, 1);
		buildWall (6, 0, 16, 1, 8, 6);
		buildWall (0, 0, 16, 1, 14, 6);
		buildWall (0, 0, 22, 7, 14, 1);
		buildWall (7, 0, 20, 18, 6, 1);
		buildWall (25, 0, 22, 7, 14, 1);
		buildWall (31, 0, 17, 1, 14, 5);
		buildWall (25, 0, 16, 1, 8, 6);
		buildWall(26,0,16,6,14,1);
		buildWall(26,0,0,1,6,16);
		//inner walls
		buildWall(11,0,0,1,6,13);
		buildWall (12, 0, 12, 8, 6, 1);
		buildWall (20, 0, 0, 1, 6, 13);
		
		 


		//building a fort
		//add planks
		plankify_z(23,12,0,16f,6);
		plankify_z(-9,12,0,16f,6);
		/*
		//outer walls
		buildWall(4,0,0,1,5,12);
		buildWall (1, 0, 12, 5, 12, 1);
		buildWall (6, 0, 12, 1, 10, 4);
		buildWall (0, 0, 12, 1, 12, 4);
		buildWall (0, 0, 16, 7, 12, 1);
		buildWall (7, 0, 14, 18, 5, 1);
		buildWall (25, 0, 16, 7, 10, 1);
		buildWall (31, 0, 13, 1, 10, 3);
		buildWall (25, 0, 12, 1, 8, 4);
		buildWall(26,0,12,6,10,1);
		buildWall(26,0,0,1,5,12);
		//inner walls
		buildWall(11,0,0,1,5,9);
		buildWall (12, 0, 8, 8, 5, 1);
		buildWall (20, 0, 0, 1, 5, 9);
		*/
		buildWall(4-40,0,0,1,5,12);
		buildWall (1-40, 0, 12, 5, 12, 1);
		buildWall (6-40, 0, 12, 1, 10, 4);
		buildWall (0-40, 0, 12, 1, 12, 4);
		buildWall (0-40, 0, 16, 7, 12, 1);
		buildWall (7-40, 0, 14, 18, 5, 1);
		buildWall (25-40, 0, 16, 7, 10, 1);
		buildWall (31-40, 0, 13, 1, 10, 3);
		buildWall (25-40, 0, 12, 1, 8, 4);
		buildWall(26-40,0,12,6,10,1);
		buildWall(26-40,0,0,1,5,12);
		//inner walls
		buildWall(11-40,0,0,1,5,9);
		buildWall (12-40, 0, 8, 8, 5, 1);
		buildWall (20-40, 0, 0, 1, 5, 9);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.T)) {
			foreach (Material m in materials) {
				m.color = Color.grey;
			}

			materialSelector ().color = Color.white;
		}

	}

	Material materialSelector(){
		return materials [Random.Range (0, 6)];
	}

	GameObject cubeSelector(){
		return cubes [Random.Range (0, 6)];
	}

	//create planks - moves towards z axis
	void plankify_z (int startX, int startY, int startZ, float plank_len, int n){
		for (int i = 0; i < n; i++) {
			GameObject new_plank = (GameObject) Instantiate (plank.gameObject, new Vector3 (0f, -5f, 0f), Quaternion.identity);
			new_plank.gameObject.transform.localScale = new Vector3 (plank_len, 1f, 3f);
			new_plank.transform.position = new Vector3 (startX+(plank_len*1.5f), startY+.5f, startZ + (3 * i));
		}

		for (int i = 1; i < n; i++) {
			GameObject new_plank = (GameObject) Instantiate (plank.gameObject, new Vector3 (0f, -5f, 0f), Quaternion.identity);
			new_plank.gameObject.transform.localScale = new Vector3 (plank_len, 1f, 3f);
			new_plank.transform.position = new Vector3 (startX+(plank_len*1.5f), startY+.5f, -1f*(startZ + (3 * i)));
		}
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

