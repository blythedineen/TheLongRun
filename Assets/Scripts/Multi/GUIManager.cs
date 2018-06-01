using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GUIManager : MonoBehaviour {
    public Text distanceText;
    private static GUIManager instance;

    void Start() {
        instance = this;
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        distanceText.enabled = false;
    }

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            GameEventManager.TriggerGameStart();
        }
    }

    private void GameStart() {
        distanceText.enabled = true;
        enabled = false;
    }

    private void GameOver() {
        enabled = true;
    }

    public static void SetDistance(float distance) {
        instance.distanceText.text = distance.ToString("f0");
    }
}
