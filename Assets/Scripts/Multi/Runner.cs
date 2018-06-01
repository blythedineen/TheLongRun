using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour {

    public Camera cam;
    public static float distanceTraveled;
    public float acceleration;
    private bool touchingPlatform;
    public Vector3 jumpVelocity;
    public float gameOverY;
    private Vector3 startPosition;
    private Vector3 runner2;

    void Update() {
        runner2 = GameObject.Find("Player 2").transform.position;
        if (runner2.x > transform.localPosition.x) {
            cam.transform.position = new Vector3(runner2.x + 5, 15, -40);
        } else if (runner2.x < transform.localPosition.x) {
            cam.transform.position = new Vector3(transform.localPosition.x + 5, 15, -40);
        }

        if (touchingPlatform && Input.GetButtonDown("Jump")) {
            GetComponent<Rigidbody>().AddForce(jumpVelocity, ForceMode.VelocityChange);
            touchingPlatform = false;
        }
        transform.Translate(5f * Time.deltaTime, 0f, 0f);
        distanceTraveled = transform.localPosition.x;
        GUIManager.SetDistance(distanceTraveled);
        if (transform.localPosition.y < gameOverY) {
            if (runner2.x > transform.localPosition.x) {
                GUIManager.setWinner("Player 2");
            }
            else if (runner2.x < transform.localPosition.x) {
                GUIManager.setWinner("Player 1");
            }
            GameEventManager.TriggerGameOver();
        }
    }

    void FixedUpdate() {
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
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        startPosition = new Vector3(0, 3, 0);
        //GetComponent<Material>().SetColor("diffuse", new Color32(255,0,0, 0));
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        enabled = false;
    }

    private void GameStart() {
        distanceTraveled = 0f;
        GUIManager.SetDistance(distanceTraveled);
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