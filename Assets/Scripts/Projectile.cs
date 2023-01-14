using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
  [SerializeField] private float speed;
  [SerializeField] public int damage;
  private Rigidbody2D rigidbody2d;
  // Start is called before the first frame update
  void Start() {
    rigidbody2d = GetComponent<Rigidbody2D>();
    rigidbody2d.velocity = Vector2.right * speed;
  }

  // Update is called once per frame
  void Update() {}
}
