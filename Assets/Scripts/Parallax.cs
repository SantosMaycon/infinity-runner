using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
  private float length;
  private float startPosition;
  [SerializeField] private Transform cam;
  [SerializeField] private float parallaxFactor;
  // Start is called before the first frame update
  void Start() {
    startPosition = transform.position.x;
    length = GetComponent<SpriteRenderer>().bounds.size.x;    
  }

  // Update is called once per frame
  void Update() {
    float reposition = cam.transform.position.x * (1 - parallaxFactor);
    float distance = cam.transform.position.x * parallaxFactor;
    transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

    if (reposition > startPosition + length) {
      startPosition += length;
    }
  }
}
