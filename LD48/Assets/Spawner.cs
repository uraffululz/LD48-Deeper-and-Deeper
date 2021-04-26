using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField] GameManager gameMan;

	BoxCollider boxCol;

	[SerializeField] GameObject[] shallowEnemies;
	[SerializeField] GameObject[] deepEnemies;

	float spawnTime;
	float spawnTimeCurrent;

	[SerializeField] GameObject cthulhuPrefab;

	
	void Start() {
        boxCol = GetComponent<BoxCollider>();

		SetSpawnTimer();
    }


    void Update() {
		if (!gameMan.gameOver && spawnTimeCurrent <= 0) {
			Vector3 spawnPlace = new Vector3(transform.position.x, transform.position.y + Random.Range(-boxCol.bounds.extents.y, boxCol.bounds.extents.y), 0);

			if (gameMan.currentDepth >= 1200 && !gameMan.cthulhuSpawned) {
				GameObject Cthulhu = Instantiate(cthulhuPrefab, spawnPlace, Quaternion.identity);
				Cthulhu.name = "Cthulhu";

				gameMan.cthulhuSpawned = true;
			}
			else if (gameMan.currentDepth < 600) {
				int enemyChosen = Random.Range(0, shallowEnemies.Length);
				GameObject newEnemy = Instantiate(shallowEnemies[enemyChosen], spawnPlace, Quaternion.identity);
				newEnemy.name = shallowEnemies[enemyChosen].name;
			}
			else {
				int enemyChosen = Random.Range(0, deepEnemies.Length);
				GameObject newEnemy = Instantiate(deepEnemies[enemyChosen], spawnPlace, Quaternion.identity);
				newEnemy.name = deepEnemies[enemyChosen].name;
			}

			SetSpawnTimer();
		}
		else {
			spawnTimeCurrent -= Time.deltaTime;
		}
    }


	void SetSpawnTimer() {
		spawnTime = Random.Range(4f, 6f);
		spawnTimeCurrent = spawnTime;

//TOMAYBEDO Increase spawn rate over time?

	}
}
