using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy {
  [SerializeField] private float speed;
  private Rigidbody2D rigidbody2d;
  // Start is called before the first frame update
  void Start() {
    rigidbody2d = GetComponent<Rigidbody2D>();
    rigidbody2d.velocity = Vector2.left * speed;
    Destroy(gameObject, 5f);
  }

  // Update is called once per frame
  void Update() {}
}
