using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RunnerS : MonoBehaviour {

    public static float distanceTraveled;
    public float acceleration;
    private bool touchingPlatform;
    public Vector3 jumpVelocity;
    public float gameOverY;
    private Vector3 startPosition;
    private Color random;

    void Update() {
        if (touchingPlatform && Input.GetButtonDown("Jump")) {
            GetComponent<Rigidbody>().AddForce(jumpVelocity, ForceMode.VelocityChange);
            touchingPlatform = false;
        }

        transform.Translate(5f * Time.deltaTime, 0f, 0f);
        distanceTraveled = transform.localPosition.x;
        GUIManagerS.SetDistance(distanceTraveled);

        if (transform.localPosition.y < gameOverY) {
            GameEventManagerS.TriggerGameOver();
        }

        if (SceneManager.GetActiveScene().name == "Level1") {
            if (transform.localPosition.x >= 527) {
                acceleration = 0;
                jumpVelocity = new Vector3((float)0, (float)0, (float)0);
                GUIManagerS.endLvl();
            }
        } else if (SceneManager.GetActiveScene().name == "Level3") {
            if (transform.localPosition.x >= 520) {
                acceleration = 0;
                jumpVelocity = new Vector3((float)0, (float)0, (float)0);
                GUIManagerS.endLvl();
            }
        } else if (SceneManager.GetActiveScene().name == "Level3") {
            if (transform.localPosition.x >= 515) {
                acceleration = 0;
                jumpVelocity = new Vector3((float)0, (float)0, (float)0);
                GUIManagerS.endLvl();
            }
        }
    }

    void FixedUpdate(){
        if (touchingPlatform) {
            GetComponent<Rigidbody>().AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
        }
    }

    void OnCollisionEnter() {
        touchingPlatform = true;
    }

    void OnCollisionExit() {
        touchingPlatform = false;
    }

    void Start() {
        GameEventManagerS.GameStart += GameStart;
        GameEventManagerS.GameOver += GameOver;
        startPosition = transform.localPosition;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        enabled = false;
    }

    private void GameStart() {
        distanceTraveled = 0f;
        GUIManagerS.SetDistance(distanceTraveled);
        transform.localPosition = startPosition;
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        enabled = true;
    }

    private void GameOver() {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        enabled = false;
    }
}