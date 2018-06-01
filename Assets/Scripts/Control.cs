using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public void Multiplayer()
    {
        SceneManager.LoadScene("multiplayer");
    }

    public void Infinite()
    {
        SceneManager.LoadScene("main_scene");
    }

    public void Levels()
    {
        SceneManager.LoadScene("Level_Select");
    }

    public void title()
    {
        SceneManager.LoadScene("title_page");
    }
}