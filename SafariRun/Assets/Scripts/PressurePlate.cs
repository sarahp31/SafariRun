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
            StartCoroutine(timer1());
        }
    }

    IEnumerator timer1() {
        yield return new WaitForSeconds(4.0f);
        var renderer = PressurePlateColor.GetComponent<SpriteRenderer>();

        renderer.color = Color.red;
        isActivated = false;
        StartCoroutine(timer2());
    } 

    IEnumerator timer2() {
        yield return new WaitForSeconds(4.0f);
        var renderer = PressurePlateColor.GetComponent<SpriteRenderer>();

        renderer.color = Color.green;
        isActivated = true;
        StartCoroutine(timer1());
    } 
    // void OnCollisionExit2D(Collision2D collision) {
    //     if (collision.gameObject.name == "Player_1" || collision.gameObject.name == "Player_2"){
    //         var renderer = PressurePlateColor.GetComponent<SpriteRenderer>();

    //         renderer.color = Color.red;
    //         isActivated = false;
    //     }
    // }
}
