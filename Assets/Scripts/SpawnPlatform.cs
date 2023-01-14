using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour {
  [SerializeField] private List<GameObject> platforms = new List<GameObject>();
  private List<Transform> currentPlatforms = new List<Transform>();
  private float distance = 0f;
  private GameObject player;
  private Transform currentPlatformPoint;
  private int platformIndex;
  // Start is called before the first frame update
  void Start() {
    player = GameObject.FindGameObjectWithTag("Player");

    foreach(GameObject platform in platforms) {
      GameObject obj = Instantiate(platform, new Vector2(distance, -4.5f), transform.rotation);
      currentPlatforms.Add(obj.transform);
      distance += 30;
    }

    currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
  }

  // Update is called once per frame
  void Update() {
    move();
  }

  void move() {
    float distanceBetweenPlayerAndFinalPoint = player.transform.position.x - currentPlatformPoint.position.x;

    if(distanceBetweenPlayerAndFinalPoint >= 1) {
      recycle(currentPlatforms[platformIndex].gameObject);
      platformIndex = platformIndex < currentPlatforms.Count - 1 ? ++platformIndex : 0;
      currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
    }
  }

  public void recycle(GameObject platform) {
    platform.transform.position = new Vector2(distance, platform.transform.position.y);
    distance += 30f;
    platform.GetComponentInChildren<SpawnEnemyPlatform>()?.respawnEnemy();
  }
}
