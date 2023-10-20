using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public List<GameObject> frutas;
    public int sizeList;
    private bool isNotOver;
    public GameObject trophy;

    void Start(){
        trophy.SetActive(false);
    }

    void Update(){
        isNotOver = false;
        for (int i = 0; i < sizeList; i++) {
            if (frutas[i].activeSelf) {
                isNotOver = true;
            }
        }

        if (!isNotOver) {
            trophy.SetActive(true);
        }
    } 
}
