using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWorld : MonoBehaviour
{
    public GameObject button;
    void Start() {
        if (MapAnim.currentWorld == 1) {
            if (LevelUnlock.level3 == true) {
                button.SetActive(true);
            } else {
                button.SetActive(false);
            }
        } else if (MapAnim.currentWorld == 2) {
            if (LevelUnlock.level5 == true) {
                button.SetActive(true);
            } else {
                button.SetActive(false);
            }
        } else if (MapAnim.currentWorld == 3) {
            if (LevelUnlock.level7 == true) {
                button.SetActive(true);
            } else {
                button.SetActive(false);
            }
        }
    }
    
}
