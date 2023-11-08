using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerWorld : MonoBehaviour
{
    private string scene;
    void Update() {
        if (CurrentWorld.currentWorld == 1) {
            scene = "SelectLevel";
        } else if (CurrentWorld.currentWorld == 2) {
            scene = "SelectLevel1";
        } else if (CurrentWorld.currentWorld == 3) {
            scene = "SelectLevel2";
        }
    }
    public void changeScene() 
    {
        string sceneName = "Scenes/" + scene;
        SceneManager.LoadScene(sceneName);
    }
}
