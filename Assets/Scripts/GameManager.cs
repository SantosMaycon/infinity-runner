using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
  [SerializeField] private GameObject gameOverPanel;
  public static GameManager instance;

  // Start is called before the first frame update
  void Start() {
    instance = this;
  }

  // Update is called once per frame
  void Update() {}

  public void showGameOver() {
    gameOverPanel.SetActive(true);
  }

  public void restartGame() {
    SceneManager.LoadScene(0);
  }
}
