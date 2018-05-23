using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {
    public Text gameOverText, title, distanceText;
    public Button button;
    private static GUIManager instance;

    void Start() {
        instance = this;
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        gameOverText.enabled = false;
        title.enabled = true;
        distanceText.enabled = false;
        button.gameObject.SetActive(true);

    }

    void Update() {
        button.onClick.AddListener(() => { GameEventManager.TriggerGameStart(); button.gameObject.SetActive(false); });
        if (Input.GetButtonDown("Jump")) {
            GameEventManager.TriggerGameStart();
        }
    }

    private void GameStart() {
        button.gameObject.SetActive(false);
        distanceText.enabled = true;
        gameOverText.enabled = false;
        title.enabled = false;
        enabled = false;
    }

    private void GameOver() {
        gameOverText.enabled = true;
        enabled = true;
    }

    public static void SetDistance(float distance) {
        instance.distanceText.text = distance.ToString("f0");
    }

}
