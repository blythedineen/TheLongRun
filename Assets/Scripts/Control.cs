using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class Control : MonoBehaviour {
    private List <GameObject> rootObjects = new List<GameObject>();
    private GameObject gameObject;

    public void Multiplayer() {
        SceneManager.LoadScene("multiplayer");
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);

        for (int i = 0; i < rootObjects.Count; ++i)
        {
            gameObject = rootObjects[i];
            gameObject.SetActive(true);
        }
    }

    public void Infinite() {
        SceneManager.LoadScene("main_scene");
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);

        for (int i = 0; i < rootObjects.Count; ++i)
        {
            gameObject = rootObjects[i];
            gameObject.SetActive(true);
        }
    }

    public void Levels() {
        SceneManager.LoadScene("levels");
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);

        for (int i = 0; i < rootObjects.Count; ++i)
        {
            gameObject = rootObjects[i];
            gameObject.SetActive(true);
        }
    }

    public void title() {
        SceneManager.LoadScene("title_page");
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);

        for (int i = 0; i < rootObjects.Count; ++i) {
            gameObject = rootObjects[i];
            gameObject.SetActive(true);
        }
    }

    public void dontChange() {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active scene is '" + scene.name + "'.");
        scene.GetRootGameObjects(rootObjects);

        // iterate root objects and do something
        for (int i = 0; i < rootObjects.Count; ++i){
            if (gameObject.name != "Main Camera") {
                gameObject = rootObjects[i];
                DontDestroyOnLoad(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}