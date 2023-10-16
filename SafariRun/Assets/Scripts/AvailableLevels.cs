using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableLevels : MonoBehaviour
{
    public List<GameObject> buttons;
    void Start()
    {
        buttons[0].SetActive(LevelUnlock.level1);
        buttons[1].SetActive(LevelUnlock.level2);
        buttons[2].SetActive(LevelUnlock.level3);
        buttons[3].SetActive(LevelUnlock.level4);
        buttons[4].SetActive(LevelUnlock.level5);
        buttons[5].SetActive(LevelUnlock.level6);
        buttons[6].SetActive(LevelUnlock.level7);
        buttons[7].SetActive(LevelUnlock.level8);
        buttons[8].SetActive(LevelUnlock.level9);
    }

}
