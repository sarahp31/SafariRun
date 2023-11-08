using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableLevels : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    public List<GameObject> buttonBoxes = new List<GameObject>();
    public int world;
    void Start()
    {
        if (world == 1) {
            buttons[0].SetActive(LevelUnlock.level1);
            buttons[1].SetActive(LevelUnlock.level2);

            buttonBoxes[0].SetActive(LevelUnlock.level1);
            buttonBoxes[1].SetActive(LevelUnlock.level2);
            buttonBoxes[2].SetActive(LevelUnlock.level3);
        } else if (world == 2) {
            buttons[0].SetActive(LevelUnlock.level3);
            buttons[1].SetActive(LevelUnlock.level4);

            buttonBoxes[0].SetActive(LevelUnlock.level3);
            buttonBoxes[1].SetActive(LevelUnlock.level4);
            buttonBoxes[2].SetActive(LevelUnlock.level5);
        } else if (world == 3) {
            buttons[0].SetActive(LevelUnlock.level5);
            buttons[1].SetActive(LevelUnlock.level6);

            buttonBoxes[0].SetActive(LevelUnlock.level5);
            buttonBoxes[1].SetActive(LevelUnlock.level6);
            buttonBoxes[2].SetActive(LevelUnlock.level7);
        }
    }

}
