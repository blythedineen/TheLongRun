using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                 
public class Runner : MonoBehaviour {
    
    public static float distanceTraveled;
    private Camera cam;
    public float acceleration;
    private bool touchingPlatform;
    public Vector3 jumpVelocity;
    public float gameOverY;
    private Vector3 startPosition;


    void Update() {
        cam.transform.position = new Vector3(transform.localPosition.x+5, 15, -40);

        if (touchingPlatform && Input.GetButtonDown("Jump")) {
            GetComponent<Rigidbody>().AddForce(jumpVelocity, ForceMode.VelocityChange);
            touchingPlatform = false;
        }
        transform.Translate(5f * Time.deltaTime, 0f, 0f);
        distanceTraveled = transform.localPosition.x;
        GUIManager.SetDistance(distanceTraveled);
        if (transform.localPosition.y < gameOverY) {
            GameEventManager.TriggerGameOver();
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
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        startPosition = new Vector3(0, 3, 0);
        foreach (Camera c in Camera.allCameras) {
                if (c.gameObject.name == "cam1") {
                    cam = c;
                }
            }

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