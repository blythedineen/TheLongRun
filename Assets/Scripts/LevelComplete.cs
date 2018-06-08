using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour {
    public Text textLevel;
    private static LevelComplete instance;

    public static void endLvl(float distance) {
        instance.textLevel.text = "Level Complete!";
    }
}
 