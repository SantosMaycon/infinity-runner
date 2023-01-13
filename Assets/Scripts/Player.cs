using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  [SerializeField] private float speed;
  [SerializeField] private float jumpFoarce;
  private Rigidbody2D rigidbody2d;
  // Start is called before the first frame update
  void Start() {
    rigidbody2d = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      rigidbody2d.AddForce(Vector2.up * jumpFoarce, ForceMode2D.Impulse);
    }
  }

  void FixedUpdate() {
    rigidbody2d.velocity = new Vector2(speed, rigidbody2d.velocity.y);
  }
}
