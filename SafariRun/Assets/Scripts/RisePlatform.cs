using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisePlatform : MonoBehaviour
{
    public float minY = 0f;
    public float maxY = 4f;
    private float speed = 2f;
    private Vector2 temp;
            

    void Update(){
        if (PressurePlate.isActivated) {
            temp.x = transform.position.x;
            temp.y = maxY;
            transform.position = Vector2.MoveTowards(transform.position, temp, Time.deltaTime * speed);
        }
        else if (!PressurePlate.isActivated) {
            temp.x = transform.position.x;
            temp.y = minY;
            transform.position = Vector2.MoveTowards(transform.position, temp, Time.deltaTime * speed);
        }
    }
}
