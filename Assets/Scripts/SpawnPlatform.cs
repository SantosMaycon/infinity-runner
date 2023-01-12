using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour {
  [SerializeField] private List<GameObject> platforms = new List<GameObject>();
  private float distance = 0f;
  // Start is called before the first frame update
  void Start() {
    foreach(GameObject platform in platforms) {
      Instantiate(platform, new Vector2(distance, 0f), transform.rotation);
      distance += 30;
    } 
  }

  // Update is called once per frame
  void Update() {}

  public void recycle(GameObject platform) {
    platform.transform.position = new Vector2(distance, 0f);
    distance += 30f;
  }
}
