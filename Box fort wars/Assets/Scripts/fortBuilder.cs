using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class fortBuilder : MonoBehaviour {
	private GameObject plank;
	private List<GameObject> cubes = new List<GameObject>();
	private List<Material> materials = new List<Material>();
	public GameObject fort1;
	public GameObject fort2;
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

		buildFort (0, 0, 0, fort1);
		buildFort (-40, 0, 0, fort2);
		fort2.transform.Rotate (new Vector3 (0, 180, 0));
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
		/*
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
		*/
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	Material materialSelector(){
		return materials [Random.Range (0, 6)];
	}

	GameObject cubeSelector(){
		return cubes [Random.Range (0, 6)];
	}

	//create planks - moves towards z axis
	void plankify_z (float startX, float startY, float startZ, float plank_len, int n, GameObject fort){
		for (int i = 0; i < n; i++) {
			GameObject new_plank = (GameObject) Instantiate (plank.gameObject, new Vector3 (0f, -5f, 0f), Quaternion.identity);
			new_plank.gameObject.transform.localScale = new Vector3 (plank_len, 1f, 3f);
			new_plank.transform.position = new Vector3 ((float)startX+(plank_len*1.5f),(float) startY+.5f,(float) startZ + (3 * i));
			new_plank.transform.parent = fort.transform;
		}

		for (int i = 1; i < n; i++) {
			GameObject new_plank = (GameObject) Instantiate (plank.gameObject, new Vector3 (0f, -5f, 0f), Quaternion.identity);
			new_plank.gameObject.transform.localScale = new Vector3 (plank_len, 1f, 3f);
			new_plank.transform.position = new Vector3 ((float)startX+(plank_len*1.5f),(float) startY+.5f, (float)-1f*(startZ + (3 * i)));
			new_plank.transform.parent = fort.transform;
		}
	}

	//create planks - moves towards x axis
	void plankify_x (float startX, float startY, float startZ, float plank_len, int n, GameObject fort){
		for (int i = 0; i < n; i++) {
			GameObject new_plank = (GameObject) Instantiate (plank.gameObject, new Vector3 (0f, -5f, 0f), Quaternion.identity);
			new_plank.gameObject.transform.localScale = new Vector3 (plank_len, 1f, 3f);
			new_plank.transform.Rotate (new Vector3 (0, 90, 0));
			new_plank.transform.position = new Vector3 ((float)startX+ (3 * i),(float) startY+.5f,(float) startZ +(plank_len*1.5f));

			new_plank.transform.parent = fort.transform;
		}

		for (int i = 0; i < n; i++) {
			GameObject new_plank = (GameObject) Instantiate (plank.gameObject, new Vector3 (0f, -5f, 0f), Quaternion.identity);
			new_plank.gameObject.transform.localScale = new Vector3 (plank_len, 1f, 3f);
			new_plank.transform.Rotate (new Vector3 (0, 90, 0));
			new_plank.transform.position = new Vector3 ((float)startX+ (3 * i),(float) startY+.5f, (float)-1f*(startZ +(plank_len*1.5f)));
			new_plank.transform.parent = fort.transform;
		}
	}

	//plank method for towers
	void plankify_tow (float startX, float startY, float startZ, float plank_len, int n, GameObject fort){
		for (int i = 0; i < n; i++) {
			GameObject new_plank = (GameObject) Instantiate (plank.gameObject, new Vector3 (0f, -5f, 0f), Quaternion.identity);
			new_plank.gameObject.transform.localScale = new Vector3 (plank_len, 1f, 3f);
			new_plank.transform.position = new Vector3 ((float)startX+(plank_len*1.5f),(float) startY+.5f, (float)startZ + (3 * i));
			new_plank.transform.parent = fort.transform;
		}

		for (int i = 1; i < n+1; i++) {
			GameObject new_plank = (GameObject) Instantiate (plank.gameObject, new Vector3 (0f, -5f, 0f), Quaternion.identity);
			new_plank.gameObject.transform.localScale = new Vector3 (plank_len, 1f, 3f);
			new_plank.transform.position = new Vector3 ((float)startX+(plank_len*1.5f), (float)startY+.5f, (float)-1f*(startZ + (3 * i)-1));
			new_plank.transform.parent = fort.transform;
		}
	}

	//Builds a wall and it's reflection along z-axis
	void buildWall(float startX, float startY, float startZ, int lenX,int lenY,int lenZ, GameObject fort){
			for (float k = startZ; k < (startZ + lenZ); k++) {
				for (float i = startX; i < (startX + lenX); i++) {
					for (float j = startY; j < (startY + lenY); j++) {
						float l = 2.0f;//cube size 

					GameObject temp = (GameObject) Instantiate (cubeSelector ().gameObject, new Vector3 ((float)i * l, (float)(j + 0.5f) * l, (float)k * l), Quaternion.identity);
						temp.transform.parent = fort.transform;
					}
				}
			}

			startZ = -startZ - 1;

		for (float k = startZ; k > (startZ - lenZ); k--) {
			for (float i = startX; i < (startX + lenX); i++) {
				for (float j = startY; j < (startY + lenY); j++) {
						float l = 2.0f;
					GameObject temp = (GameObject) Instantiate (cubeSelector ().gameObject, new Vector3 ((float)i * l, (float)(j + 0.5f) * l,(float) k * l), Quaternion.identity);
						temp.transform.parent = fort.transform;
					}
				}
			}

	}

	public void switchColor(){
		foreach (Material m in materials) {
				m.color = Color.grey;
			}
		materialSelector ().color = Color.white;
	}

	private void buildFort(float x, float y, float z, GameObject fort){
		//front wall
		buildWall(4f,0f,0f,1,6,16,fort);
		//tower 1
		buildWall (1f, 0f, 16f, 5, 8, 1,fort);
		buildWall (6f, 0f, 16f, 1, 8, 6,fort);
		buildWall (0f, 0f, 16f, 1, 8, 6,fort);
		buildWall (0f, 0f, 22f, 7, 8, 1,fort);
		plankify_tow (-15f, 16f, 32f, 14f, 5,fort);
		plankify_tow (-2f, 17f, 35f, 14f, 2,fort);
		//2nd floor walls tower 1
		buildWall (1f, 8.5f, 16f, 5, 1, 1,fort);
		//buildWall (6f, 7.5f, 16f, 1, 1, 6,fort);
		buildWall (0f, 8.5f, 16f, 1, 1, 6,fort);
		buildWall (0f, 8.5f, 22f, 7, 1, 1,fort);

		plankify_x(25,12,6,18f,5,fort);

		//side wall
		buildWall (7f, 0f, 20f, 18, 6, 1,fort);


		//tower2
		buildWall (25f, 0f, 22f, 7, 12, 1,fort);
		buildWall (31f, 0f, 17f, 1, 12, 5,fort);
		buildWall (25f, 0f, 16f, 1, 12, 6,fort);
		buildWall(26f,0f,16f,6,12,1,fort);
		plankify_tow (35f, 24f, 32f, 14f, 5,fort);
		buildWall (25f, 12.5f, 22f, 7, 1, 1,fort);
		buildWall (31f, 12.5f, 17f, 1, 1, 5,fort);
		buildWall (25f, 12.5f, 16f, 1, 1, 6,fort);
		//buildWall(26f,12.5f,16f,6,1,1,fort);
		plankify_x(55,26,-24,30f,2,fort);



		//backwall
		buildWall(26f,0f,0f,1,6,16,fort);

		//back middle tower
		buildWall (31f, 0f, 0f, 1, 8, 5, fort);
		buildWall (27f, 0f, 5f, 5, 8, 1, fort);
		buildWall (27f, 0f, 0f, 1, 8, 5, fort);
		plankify_z (42f, 16f, 0f, 10f, 4, fort);
		buildWall (26f, 6.5f, 0f, 1, 1, 5, fort);

		//inner walls
		buildWall(11f,0f,0f,1,6,20,fort);
		buildWall (12f, 0f, 12f, 8, 6, 1,fort);
		buildWall (20f, 0f, 0f, 1, 6, 20,fort);

		//add planks
		plankify_z(25,12,0,14f,11,fort);
		plankify_z(-9,12,0,16f,11,fort);

		fort.transform.position = new Vector3(x,fort.transform.position.y,z);
	}		
}

