using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {
	private Vector3 startPos;
	private bool killable;
	void Start () {
		startPos = this.gameObject.transform.position;
		killable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(this.gameObject.transform.position,startPos)> 2.0f) {
			killable = true;
		}
		if (this.gameObject.transform.position.y < -100) {
			Destroy (this.gameObject);
		}
	}

	void FixedUpdate(){
		
	}

	void OnCollisionEnter(Collision col){
		if (killable && col.gameObject.tag == "Water") {
			
			Physics.IgnoreCollision (col.gameObject.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
		}
	}
}
