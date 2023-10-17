using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public Animator animator1;
    public GameObject player1;
    public Animator animator2;
    public GameObject player2;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Player_1" || collision.gameObject.name == "Player_2"){
            animator1.SetTrigger("death");
            animator2.SetTrigger("death");
            StartCoroutine(timer());
        }
    } 

    IEnumerator timer() {
        yield return new WaitForSeconds(0.4f);
        player1.SetActive(false);
        player2.SetActive(false);
        SceneManager.LoadScene(2);
    }
}
