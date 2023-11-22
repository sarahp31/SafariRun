using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtons : MonoBehaviour
{
    public string buttonName;
    public PlayerController player;
    private bool isMoving;

    public void movementOn() 
    {
        if (buttonName == "jump") {
            player.jumpButtonExt = 1f;
            StartCoroutine(timer());
        }
    }
    
    void Update() 
    {
        if (isMoving) {
            if (buttonName == "jump") {
                player.jumpButtonExt = 0f;
                isMoving = false;
            }
        }
        
    }

    IEnumerator timer() {
        yield return new WaitForSeconds(0.1f);
        isMoving = true;
    }
}
