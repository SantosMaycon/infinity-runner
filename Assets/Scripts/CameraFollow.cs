using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
  [SerializeField] private float speed;
  [SerializeField] private float offset;
  private Transform follow;
  // Start is called before the first frame update
  void Start() {
    follow = GameObject.FindGameObjectWithTag("Player").transform;
  }

  // Update is called once per frame
  void LateUpdate() {
    Vector3 newCameraPosition = new Vector3(follow.position.x + offset, 0f, transform.position.z);
    transform.position = Vector3.Slerp(transform.position, newCameraPosition, speed * Time.deltaTime);  
  }
}
