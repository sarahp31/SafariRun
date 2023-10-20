using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisePlatform : MonoBehaviour
{
    public float minY = 0f;
    public float maxY = 4f;
    private float speed = 2f;
    private Vector2 temp;
    private bool stopFalling; 
            
    void Update(){
        if (PressurePlate.isActivated) {
            temp.x = transform.position.x;
            temp.y = maxY;
            transform.position = Vector2.MoveTowards(transform.position, temp, Time.deltaTime * speed);
        }
        else if (!PressurePlate.isActivated) {
            if (!stopFalling) {
                temp.x = transform.position.x;
                temp.y = minY;
                transform.position = Vector2.MoveTowards(transform.position, temp, Time.deltaTime * speed);
            }
        }
    }

    // void OnCollisionEnter2D(Collision2D collision) {
    //     if (collision.gameObject.name == "Player_1" || collision.gameObject.name == "Player_2"){
    //         stopFalling = true;
    //     }
    // } 
    // void OnCollisionExit2D(Collision2D collision) {
    //     if (collision.gameObject.name == "Player_1" || collision.gameObject.name == "Player_2"){
    //         stopFalling = false;
    //     }
    // } 
}
