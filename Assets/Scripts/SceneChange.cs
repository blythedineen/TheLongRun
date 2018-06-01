using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    private List<GameObject> rootObjects = new List<GameObject>();
    private new GameObject gameObject;

    // Use this for initialization
    public void changeMenu(string sceneName) {
        SceneManager.LoadScene(sceneName);
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);

        for (int i = 0; i < rootObjects.Count; ++i)
        {
            gameObject = rootObjects[i];
            gameObject.SetActive(true);
        }
    }

    public void dontChange() {
            Scene scene = SceneManager.GetActiveScene();
            Debug.Log("Active scene is '" + scene.name + "'.");
            scene.GetRootGameObjects(rootObjects);

            // iterate root objects and do something
            for (int i = 0; i < rootObjects.Count; ++i)
            {
                if (gameObject.name != "Main Camera")
                {
                    gameObject = rootObjects[i];
                    DontDestroyOnLoad(gameObject);
                    gameObject.SetActive(false);
                }
            }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
