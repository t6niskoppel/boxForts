using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameController : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;
	public GameObject fortBuilder;
	public Slider powerSlider;
	private MonoBehaviour p1controller;
	private MonoBehaviour p2controller;
	public static int enabledPlayer = 1;

	private GameObject enabled;//The player who's turn it is
	private GameObject disabled;//The player who's turn it isn't
	// Use this for initialization
	void Start() {
		p1controller = player1.GetComponent<MonoBehaviour> ();
		p2controller = player2.GetComponent<MonoBehaviour> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			SwitchPlayer ();
		}

	}

	void SwitchPlayer(){
		Camera p1cam = player1.transform.GetComponentInChildren<Camera> ();
		Camera p2cam = player2.transform.GetComponentInChildren<Camera> ();

		p1cam.enabled = !p1cam.enabled;
		p2cam.enabled = !p2cam.enabled;

		p1controller.enabled = !p1controller.enabled;
		p2controller.enabled = !p2controller.enabled;

		if (enabledPlayer == 1) {
			enabledPlayer = 2;
		} else
			enabledPlayer = 1;
	}

	public int getEnabledPlayer(){
		return enabledPlayer;
	}

	public void setPowerSlider(float f){
		powerSlider.value = f;
	}

	public void switchColor(){
		fortBuilder.SendMessage("switchColor");
	}
}
