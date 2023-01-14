using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
  [SerializeField] private float xAxis;
  [SerializeField] private float yAxis;
  private Rigidbody2D rigidbody2d;
  // Start is called before the first frame update
  void Start() {
    rigidbody2d = GetComponent<Rigidbody2D>();
    rigidbody2d.AddForce(new Vector2(xAxis, yAxis), ForceMode2D.Impulse);
    Destroy(gameObject, 2f);
  }

  // Update is called once per frame
  void Update() {}
}
