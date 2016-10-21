using UnityEngine;
using System.Collections;

public class missile : MonoBehaviour {

	private gameController gameController;
	public float radius;
	public float power;
	private bool exploded = false;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<gameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < -30) {
			Destroy (this.gameObject);
			gameController.SendMessage ("switchColor");
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Water") {
			Physics.IgnoreCollision (this.gameObject.GetComponent<Collider> (), col.gameObject.GetComponent<Collider> ());
		}
		if (!exploded) {
			//võtan mingis raadiuses kinematicu maha
			Vector3 explosionPos = this.gameObject.transform.position;
			Collider[] kinematicColliders = Physics.OverlapSphere (explosionPos, radius * 1.5f);
			foreach (Collider hit in kinematicColliders) {
				if (hit.gameObject.name.StartsWith ("Cube")) {

					exploded = true;
					Rigidbody rb = hit.GetComponent<Rigidbody> ();
				
					if (rb != null) {
						if (rb.isKinematic) {
							rb.isKinematic = false;
						}
					}
				}
			}
			//Kui visati helendavat kasti -> big explosion
			if (!col.gameObject.GetComponent<Renderer>().material.color.Equals(Color.gray)&&col.gameObject.name.StartsWith("Cube")) {
				Collider[] hitColliders = Physics.OverlapSphere (explosionPos, radius);
				foreach (Collider hit in hitColliders) {
					if (hit.gameObject.name.StartsWith ("Cube")) {
						Rigidbody rb = hit.GetComponent<Rigidbody> ();
						if (rb != null) {
							rb.AddExplosionForce (power, explosionPos, radius, 0f);
							}
						//Destroy (this.gameObject);
					}
				}
			} else {//Kui visati tavalist kasti
				Collider[] hitColliders = Physics.OverlapSphere (explosionPos, radius);
				foreach (Collider hit in hitColliders) {
					if (hit.gameObject.name.StartsWith ("Cube")) {
						Rigidbody rb = hit.GetComponent<Rigidbody> ();
						if (rb != null) {
							rb.AddExplosionForce (power / 5f, explosionPos, radius, 0f);
						}
		
						//Destroy (this.gameObject);
					}
				}
			}
}
}
}