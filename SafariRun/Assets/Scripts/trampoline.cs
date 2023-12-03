using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Trampoline : MonoBehaviour{
    public Animator animator;
    public Rigidbody2D  Player;

    void OnTriggerEnter2D(Collider2D collider) {
    
        if (collider.gameObject.name == Player.name){
        
            animator.SetTrigger("Trampoline"); // Activate the animation for the trampoline
            Player.AddForce(Vector3.up * 1100); // Propel the character upwards
        }
    }
}
