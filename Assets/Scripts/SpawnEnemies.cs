using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
  [SerializeField] private GameObject[] enemies;
  [SerializeField] private float spawnTime;
  private float timer;
  
  // Start is called before the first frame update
  void Start() {
    timer = spawnTime;
  }

  // Update is called once per frame
  void Update() {
    spawnTime -= Time.deltaTime;

    if (spawnTime <= 0f) {
      spawnEnemy();
      spawnTime = timer;
    }
  }

  void spawnEnemy() {
    Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position + new Vector3(0f, Random.Range(-1f, 3.5f), 0f), Quaternion.identity);
  }
}
