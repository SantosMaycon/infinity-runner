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

  public virtual int onHit() {
    return damage;
  }

  protected virtual void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Bullet")) {
      Projectile projectile = other.GetComponent<Projectile>();
      projectile.createExplose();
      ApplyDamage(projectile.damage);
    }
  }
}
