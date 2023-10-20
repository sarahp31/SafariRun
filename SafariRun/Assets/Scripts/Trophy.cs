using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    public GameObject endText;

    void Start() {
        endText.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.name == "Player_1" || collider.gameObject.name == "Player_2"){
                endText.SetActive(true);
        }
    }
}
