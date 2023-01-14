using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  [SerializeField] private float speed;
  [SerializeField] private float jumpFoarce;
  [SerializeField] private GameObject bulletPrefab;
  [SerializeField] private Transform pointOfShoot;
  [SerializeField] private Animator animator;
  private Rigidbody2D rigidbody2d;
  private bool isJumping;
  // Start is called before the first frame update
  void Start() {
    rigidbody2d = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping) {
      rigidbody2d.AddForce(Vector2.up * jumpFoarce, ForceMode2D.Impulse);
      animator.SetBool("isJump", true);
      isJumping = true;
    }

    if (Input.GetKeyDown(KeyCode.Space)) {
      var bullet = Instantiate(bulletPrefab, pointOfShoot.position, Quaternion.identity);
      Destroy(bullet, 5f);
    }
  }

  void FixedUpdate() {
    rigidbody2d.velocity = new Vector2(speed, rigidbody2d.velocity.y);
  }

  void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.layer == 8) {
      animator.SetBool("isJump", false);
      isJumping = false;
    }  
  }
}
