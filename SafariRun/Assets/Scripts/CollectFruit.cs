using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFruit : MonoBehaviour
{
    public GameObject Player;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == Player.name){
            gameObject.SetActive(false);
        }
    }  
}
