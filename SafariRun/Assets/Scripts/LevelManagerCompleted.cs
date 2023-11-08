using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerCompleted : MonoBehaviour
{
    private string scene;
    void Update() {
        if (CurrentWorld.nextWorld == 1) {
            scene = "SelectLevel";
        } else if (CurrentWorld.nextWorld == 2) {
            scene = "SelectLevel1";
        } else if (CurrentWorld.nextWorld == 3) {
            scene = "SelectLevel2";
        }
    }
    public void changeScene() 
    {
        string sceneName = "Scenes/" + scene;
        SceneManager.LoadScene(sceneName);
    }
}
