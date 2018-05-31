using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManagerS : MonoBehaviour {
    public Text gameOverText, distanceText, Start_Message;
    private static GUIManagerS instance;
    public GameObject title;

    void Start() {
        instance = this;
        GameEventManagerS.GameStart += GameStart;
        GameEventManagerS.GameOver += GameOver;
        title.SetActive(true);
        Start_Message.enabled = true;
        gameOverText.enabled = false;
        distanceText.enabled = false;
    }

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            GameEventManagerS.TriggerGameStart();
        }
    }

    private void GameStart() {
        title.SetActive(false);
        Start_Message.enabled = false;
        distanceText.enabled = true;
        gameOverText.enabled = false;
        enabled = false;
    }

    private void GameOver() {
        Start_Message.enabled = false;
        title.SetActive(true);
        gameOverText.enabled = true;
        enabled = true;
    }

    public static void SetDistance(float distance) {
        instance.distanceText.text = distance.ToString("f0");
    }

}
