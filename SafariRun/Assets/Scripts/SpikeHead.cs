using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : MonoBehaviour
{
    public float minY;
    public float maxY;
    private float riseSpeed = 4f;
    private float fallSpeed = 4f;
    private Vector2 temp;
    public bool isBottom;
    public List<GameObject> players; 
    private bool stopFalling;          

    void Update(){
        if (isBottom) {
            temp.x = transform.position.x;
            temp.y = maxY;
            transform.position = Vector2.MoveTowards(transform.position, temp, Time.deltaTime * riseSpeed);
            if (transform.position.y == maxY) {
                isBottom = false;
            }
        }
        else if (!isBottom) {
            if (!stopFalling) {
                temp.x = transform.position.x;
                temp.y = minY;
                transform.position = Vector2.MoveTowards(transform.position, temp, Time.deltaTime * fallSpeed);
                if (transform.position.y == minY) {
                    isBottom = true;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Player_1" || collision.gameObject.name == "Player_2"){
            stopFalling = true;
        }
    } 
    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.name == "Player_1" || collision.gameObject.name == "Player_2"){
            stopFalling = false;
        }
    } 
}
