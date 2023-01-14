using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyPlatform : MonoBehaviour {
  [SerializeField] private GameObject enemyPrefab;
  private List<Transform> points = new List<Transform>();
  private GameObject enemy;
  // Start is called before the first frame update
  void Start() {
    getPointsOfSpawn();
    createEnemy();
  }

  // Update is called once per frame
  void Update() {}

  void getPointsOfSpawn () {
    foreach (Transform point in transform.GetComponentsInChildren<Transform>()) {
      if (point.tag == "Point") {
        points.Add(point);
      }
    }
  }

  void createEnemy() {
    enemy = Instantiate(enemyPrefab, points[Random.Range(0, points.Count)].position, Quaternion.identity);
  }

  public void respawnEnemy() {
    enemy.SetActive(true);
    enemy.transform.position = points[Random.Range(0, points.Count)].position;
    Debug.Log("Call!!!");
  }
}
