using UnityEngine;
using System.Collections;

public class Running : MonoBehaviour {
	public AnimationClip animation;
	public Animation anim;
	// Use this for initialization
	void Start () {
		anim=GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {

			anim.AddClip (animation, "walk");

		}
	}
}
