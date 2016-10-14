using UnityEngine;
using System.Collections;

public class missile : MonoBehaviour {

	public float radius = 300f;
	public float power = 50000000000f;
	private bool exploded = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		if (!exploded) {
			Vector3 explosionPos = this.gameObject.transform.position;
			Collider[] kinematicColliders = Physics.OverlapSphere (explosionPos, radius * 2);
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

			if (col.gameObject.name.StartsWith ("Cube 4")) {
				Collider[] hitColliders = Physics.OverlapSphere (explosionPos, radius);
				foreach (Collider hit in hitColliders) {
					if (hit.gameObject.name.StartsWith ("Cube")) {
						Rigidbody rb = hit.GetComponent<Rigidbody> ();
						if (rb != null) {
							rb.AddExplosionForce (power, explosionPos, radius, 0f);
							//Destroy (hit.gameObject, 3f);
						}
					}
				}
			} else {
				Collider[] hitColliders = Physics.OverlapSphere (explosionPos, radius);
				foreach (Collider hit in hitColliders) {
					if (hit.gameObject.name.StartsWith ("Cube")) {
						Rigidbody rb = hit.GetComponent<Rigidbody> ();
						if (rb != null) {
							rb.AddExplosionForce (power / 10f, explosionPos, radius, 0f);
						}
		
						Destroy (this.gameObject, 2f);
					}
				}
			}
}
}
}