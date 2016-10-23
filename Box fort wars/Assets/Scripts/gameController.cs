using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class gameController : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;
	private Rigidbody p1rb;
	private Rigidbody p2rb;
	private CharacterController p1cc;
	private CharacterController p2cc;
	public GameObject fortBuilder;
	public Slider powerSlider;
	private FirstPersonController p1controller;
	private FirstPersonController p2controller;
	public static int enabledPlayer = 1;
	private Image img;
	public Text EndText;

	private AudioSource p1as;
	private AudioSource p2as;
	public AudioClip gameMusic;
	// Use this for initialization
	void Start() {

		Cursor.visible = false;
		p1as = player1.GetComponent<AudioSource> ();
		p2as = player2.GetComponent<AudioSource> ();
		p1as.clip = gameMusic;
		p2as.clip = gameMusic;
		//p1as.Play ();
		p2as.Play ();
		p1controller = player1.GetComponent<FirstPersonController> ();
		p2controller = player2.GetComponent<FirstPersonController> ();
		img =  GameObject.Find ("Image").gameObject.GetComponent<Image>();
		img.CrossFadeAlpha (0, 1.5f, false);
		p1rb = player1.GetComponent<Rigidbody> ();
		p2rb = player2.GetComponent<Rigidbody> ();
		p1cc = player1.GetComponent<CharacterController> ();
		p2cc = player2.GetComponent<CharacterController> ();
		p2controller.enabled = false;
		p2rb.isKinematic = false;
		p2cc.enabled = false;
		p1controller.enabled = true;
		p1rb.isKinematic = true;
		p1cc.enabled = true;
		Camera p1cam = player1.transform.GetComponentInChildren<Camera> ();
		Camera p2cam = player2.transform.GetComponentInChildren<Camera> ();

		p1cam.enabled = true;
		p2cam.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			SwitchPlayer_ ();
		}
		if (player1.transform.position.y < -5) {
			Dead ("Player 2");
		}
		if (player2.transform.position.y < -5) {
			Dead ("Player 1");
		}

	}


	void SwitchPlayer_(){
		StartCoroutine ("SwitchPlayer");
	}

		IEnumerator SwitchPlayer(){
		if (enabledPlayer == 1) {
			p1controller.enabled = false;
			p1rb.isKinematic = false;
			p1cc.enabled = false;
		} else {
			p2controller.enabled = false;
			p2rb.isKinematic = false;
			p2cc.enabled = false;
		}

		img.CrossFadeAlpha(1,2,false);

		yield return new WaitForSeconds(2f);
		if (enabledPlayer == 1) {
			p2controller.enabled = true;
			p2rb.isKinematic = true;
			p2cc.enabled = true;
		} else {
			p1controller.enabled = true;
			p1rb.isKinematic = true;
			p1cc.enabled = true;
		}
		Camera p1cam = player1.transform.GetComponentInChildren<Camera> ();
		Camera p2cam = player2.transform.GetComponentInChildren<Camera> ();

		p1cam.enabled = !p1cam.enabled;
		p2cam.enabled = !p2cam.enabled;

		img.CrossFadeAlpha(0,2,false);

		if (enabledPlayer == 1) {
			enabledPlayer = 2;
		} else {
			enabledPlayer = 1;
		}
		Debug.Log ("Enabled player " + enabledPlayer);
		yield return null;
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

	public void Shot(){

	}

	public void Dead(string player){
		Camera p1cam = player1.transform.GetComponentInChildren<Camera> ();
		Camera p2cam = player2.transform.GetComponentInChildren<Camera> ();
		Camera pan = GameObject.Find ("PanCamera").GetComponent<Camera> ();
		pan.enabled = true;
		p1cam.enabled = false;
		p2cam.enabled = false;
		EndText.text = player + " wins!";
		StartCoroutine ("Death");
	}

	IEnumerator Death(){
		yield return new WaitForSeconds (10f);
		Cursor.visible = true;
		Application.LoadLevel ("Menu");
		yield return null;
	}

}
