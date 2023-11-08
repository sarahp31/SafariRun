using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWorld : MonoBehaviour
{
    public static int currentWorld;
    public static int nextWorld;

    void Start() {
        if (!LevelUnlock.level3) {
            currentWorld = 1;
        } else if (LevelUnlock.level3 && !LevelUnlock.level5) {
            currentWorld = 2;
        } else if (LevelUnlock.level5) {
            currentWorld = 3;
        }

        if (!LevelUnlock.level4) {
            nextWorld = 1;
        } else if (LevelUnlock.level4 && !LevelUnlock.level6) {
            nextWorld = 2;
        } else if (LevelUnlock.level6) {
            nextWorld = 3;
        }
    }
}
