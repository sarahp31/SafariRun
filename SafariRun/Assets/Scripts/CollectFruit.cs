using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFruit : MonoBehaviour
{
    public GameObject Player;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.name == Player.name){
            gameObject.SetActive(false);
        }
    }  
}
