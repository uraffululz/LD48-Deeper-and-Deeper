using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonScript : MonoBehaviour {

	[SerializeField] GameObject bloodParticle;

	public bool wasFired;
	public bool inactive = false;

	float lifeTimer = 5;
	
	void Start() {
        
    }


    void Update() {
		if (wasFired) {
			transform.position = new Vector3(transform.position.x, transform.position.y, 0);

			lifeTimer -= Time.deltaTime;

			if (lifeTimer < 0) {
				Destroy(this.gameObject);
			}
		}
    }


	void OnTriggerEnter (Collider other) {
		//print("Harpoon entered another collider: " + other.gameObject.name);

		if (wasFired && !inactive && (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Cthulhu"))) {
			print("You killed an enemy");

			inactive = true;
			Instantiate(bloodParticle, other.bounds.ClosestPoint(transform.position + (-transform.up * .5f)), Quaternion.identity, other.gameObject.transform);
			//Kill the enemy by calling a Die() function on it's script
			transform.parent = other.gameObject.transform;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			//GetComponent<Rigidbody>().Sleep();
			other.gameObject.transform.parent.GetComponent<EnemyScript>().Die();
		}
	}
}
