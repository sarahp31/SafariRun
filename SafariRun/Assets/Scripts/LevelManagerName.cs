using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerName : MonoBehaviour
{
    public string scene;

    public void changeScene() 
    {
        string sceneName = "Scenes/" + scene;
        SceneManager.LoadScene(sceneName);
    }
}
