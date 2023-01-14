using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy {
  [SerializeField] private float timeOfShoot;
  [SerializeField] private GameObject bombPrefab;
  [SerializeField] private Transform pointOfShoot;
  private float timer;
  // Start is called before the first frame update
  void Start() {
    timer = timeOfShoot;
  }

  // Update is called once per frame
  void Update() {
    timeOfShoot -= Time.deltaTime;

    if (timeOfShoot <= 0f) {
      Instantiate(bombPrefab, pointOfShoot.position, pointOfShoot.rotation);
      timeOfShoot = timer;
    }
  }
}
