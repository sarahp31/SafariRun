using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject PressurePlateColor;
    public static bool isActivated;

    void Start()
    {
        isActivated = false;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Player_1" || collision.gameObject.name == "Player_2"){
            var renderer = PressurePlateColor.GetComponent<SpriteRenderer>();

            renderer.color = Color.green;
            isActivated = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.name == "Player_1" || collision.gameObject.name == "Player_2"){
            var renderer = PressurePlateColor.GetComponent<SpriteRenderer>();

            renderer.color = Color.red;
            isActivated = false;
        }
    }
}
