using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	GameManager gameMan;

	[SerializeField] GameObject player;


	[SerializeField] float speed;
	[SerializeField] bool dead = false;
	[SerializeField] float floatSpeed;

	public int pointsForKill;

	[SerializeField] GameObject playerDeathsplosion;


	void Start () {
		gameMan = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update() {
		if (!gameMan.gameOver) {
			if (!dead) {
				Follow();
			}
			else {
				Float();
			}
		}
    }


	void Follow() {
		Vector3 currentPos = new Vector3(transform.position.x, transform.position.y, 0);
		transform.position = currentPos;

		Vector3 followPos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
		transform.position = Vector3.MoveTowards(transform.position, followPos, speed * Time.deltaTime);
		
		transform.LookAt(player.transform.position, Vector3.up);
	}

	
	public void Die() {
		dead = true;
		GetComponent<Animator>().SetBool("Alive", false);
		print("You killed a " + gameObject.name);
		gameMan.IncreaseScore(pointsForKill);
		//this.enabled = false;

		if (tag == "Cthulhu") {
			gameMan.Win();
		}
	}


	void Float() {
		transform.position += Vector3.up * floatSpeed * Time.deltaTime;
		//////transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.up), .5f);
	}
	

	void OnCollisionEnter (Collision collision) {
		//print(gameObject.name + " entered a collider: " + collision.gameObject.name);

		if (!gameMan.gameOver && !dead && collision.gameObject == player) {
			print(gameObject.name + " ate the player.");

			gameMan.GameOver(gameObject.name);
		}
	}


	private void OnTriggerEnter (Collider other) {
		if (!gameMan.gameOver) {
			//print(gameObject.name + " entered a trigger: " + other.gameObject.name);

			if (!dead && other.gameObject.CompareTag("Harpoon")) {
				other.gameObject.GetComponent<HarpoonScript>().inactive = true;
				Die();
			}

			if (!dead && other.gameObject == player) {
				print(gameObject.name + " ate the player.");
				player.GetComponent<Animator>().SetBool("Alive", false);
				Instantiate(playerDeathsplosion, player.transform.position + (Vector3.up * .5f), Quaternion.identity);
				gameMan.GameOver(gameObject.name);
			}
		}
	}
}
