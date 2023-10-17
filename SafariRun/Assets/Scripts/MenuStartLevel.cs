using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStartLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        LevelUnlock.level1 = true;
        LevelUnlock.level2 = false;
        LevelUnlock.level3 = false;
        LevelUnlock.level4 = false;
        LevelUnlock.level5 = false;
        LevelUnlock.level6 = false;
        LevelUnlock.level7 = false;
        LevelUnlock.level8 = false;
        LevelUnlock.level9 = false;
    }

}
