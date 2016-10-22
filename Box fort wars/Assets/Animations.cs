using UnityEngine;
using System.Collections;

public class EthanScript : MonoBehaviour 
{
	Animator anim;

	int runStateHash = Animator.StringToHash("Base Layer.Run");


	void Start ()
	{
		anim = GetComponent<Animator>();
	}


	void Update ()
	{
		float move = Input.GetAxis ("Vertical");
		anim.SetFloat("Speed", move);

	}
}