using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GUIManager : MonoBehaviour
{
    public Text distanceText, Start_Message;
    public Text gameOver;
    public Text winner;
    public GameObject title;
    private static GUIManager instance;

    void Start() {
        instance = this;
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        title.SetActive(true);
        distanceText.enabled = false;
        gameOver.enabled = false;
        winner.enabled = false;
        Start_Message.enabled = true;
    }

    void Update() {
        if (Input.GetButtonDown("Jump"))
        {
            GameEventManager.TriggerGameStart();
        }
    }

    private void GameStart() {
        distanceText.enabled = true;
        enabled = false;
        gameOver.enabled = false;
        winner.enabled = false;
        Start_Message.enabled = false;
        title.SetActive(false);
    }

    private void GameOver() {
        enabled = true;
        winner.enabled = true;
        gameOver.enabled = true;
        title.SetActive(true);
    }

    public static void SetDistance(float distance) {
        instance.distanceText.text = distance.ToString("f0");
    }

    public static void setWinner(string player) {
        instance.winner.text = player + " won!";
    }
}
