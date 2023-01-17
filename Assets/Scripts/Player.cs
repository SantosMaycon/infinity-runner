using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  [SerializeField] private int health;
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
    if (Input.GetKeyDown(KeyCode.UpArrow)) {
      onJump();
    }

    if (Input.GetKeyDown(KeyCode.Space)) {
      onShoot();
    }
  }

  public void onJump() {
    if (!isJumping) {
      rigidbody2d.AddForce(Vector2.up * jumpFoarce, ForceMode2D.Impulse);
      animator.SetBool("isJump", true);
      isJumping = true;
    }
  }

  public void onShoot() {
    var bullet = Instantiate(bulletPrefab, pointOfShoot.position, Quaternion.identity);
    Destroy(bullet, 2f);
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

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Enemy")) {
      Enemy enemy = other.GetComponent<Enemy>();
      health -= enemy.onHit();
      Destroy(enemy.gameObject);
      checkHealth();
    }

    if (other.CompareTag("Bomb")) {
      Bomb bomb = other.GetComponent<Bomb>();
      health -= bomb.onHit();
      Destroy(bomb.gameObject);
      checkHealth();
    }
  }

  private void checkHealth() {
    if (health <= 0) {
      GameManager.instance.showGameOver();
      gameObject.SetActive(false);
    }
  }
}
