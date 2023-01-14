using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
  [SerializeField] private float speed;
  [SerializeField] public int damage;
  [SerializeField] private GameObject explosionPrefab;
  private Rigidbody2D rigidbody2d;
  // Start is called before the first frame update
  void Start() {
    rigidbody2d = GetComponent<Rigidbody2D>();
    rigidbody2d.velocity = Vector2.right * speed;
  }

  // Update is called once per frame
  void Update() {}

  public void createExplose() {
    Destroy(gameObject);
    Instantiate(explosionPrefab, transform.position, transform.rotation);
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.layer == 8) {
      createExplose();
    }
  }
}
