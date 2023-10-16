using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    void Update(){
        if (Input.GetKey("e")) {
            SceneManager.LoadScene(2);
        }
    }
}
