using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
  [SerializeField] protected int health;
  [SerializeField] protected int damage;

  public virtual void ApplyDamage(int damage) {
    health -= damage;

    if (health <= 0) {
      Destroy(gameObject);
    }
  }

  protected virtual void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Bullet")) {
      Projectile projectile = other.GetComponent<Projectile>();
      projectile.createExplose();
      ApplyDamage(projectile.damage);
    }
  }

  protected virtual void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.CompareTag("Bullet")) {
      Projectile projectile = other.gameObject.GetComponent<Projectile>();
      projectile.createExplose();
      ApplyDamage(projectile.damage);
    }
  }
}
