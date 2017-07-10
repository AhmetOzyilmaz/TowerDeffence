using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public bool stop;
	public GameObject Enemy;

	public float spawnRate= 1.0f;
	float timeLeftToSpawn;

	
	// Use this for initialization
	void Start () {
		timeLeftToSpawn= spawnRate;

	}
	
	// Update is called once per frame
	void Update () {
		timeLeftToSpawn-= Time.deltaTime;
		if(timeLeftToSpawn < 0 && !stop) {
			Spawn();
			timeLeftToSpawn= spawnRate;
		}
	}

	void Spawn(){
		GameObject enemyObject=  Instantiate(Enemy) as GameObject;
		enemyObject.transform.position= transform.position;

	}
}
