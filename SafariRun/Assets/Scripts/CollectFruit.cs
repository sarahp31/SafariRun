using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFruit : MonoBehaviour
{
    public GameObject Player;
    public Animator animator;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.name == Player.name){
            animator.SetTrigger("collect");
            StartCoroutine(timer());
        }
    } 

    IEnumerator timer() {
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    } 
}
