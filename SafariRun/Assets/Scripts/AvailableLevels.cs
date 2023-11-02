using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableLevels : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    public List<GameObject> buttonBoxes = new List<GameObject>();
    void Start()
    {
        buttons[0].SetActive(LevelUnlock.level1);
        buttons[1].SetActive(LevelUnlock.level2);
        buttons[2].SetActive(LevelUnlock.level3);
        buttons[3].SetActive(LevelUnlock.level4);
        buttons[4].SetActive(LevelUnlock.level5);
        buttons[5].SetActive(LevelUnlock.level6);
        buttons[6].SetActive(LevelUnlock.level7);

        buttonBoxes[0].SetActive(LevelUnlock.level1);
        buttonBoxes[1].SetActive(LevelUnlock.level2);
        //buttonBoxes[2].SetActive(LevelUnlock.level3);
        //buttonBoxes[3].SetActive(LevelUnlock.level4);
        //buttonBoxes[4].SetActive(LevelUnlock.level5);
        //buttonBoxes[5].SetActive(LevelUnlock.level6);
        //buttonBoxes[6].SetActive(LevelUnlock.level7);
    }

}
