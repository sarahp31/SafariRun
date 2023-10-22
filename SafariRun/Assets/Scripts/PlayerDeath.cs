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
    public GameObject deathText;

    void Start() {
        deathText.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Player_1" || collision.gameObject.name == "Player_2"){
            animator1.SetTrigger("death");
            animator2.SetTrigger("death");
            StartCoroutine(timer0());
        }
    } 

    IEnumerator timer0() {
        yield return new WaitForSeconds(0.4f);
        player1.SetActive(false);
        player2.SetActive(false);
        deathText.SetActive(true);
        StartCoroutine(timer1());
    }

    IEnumerator timer1() {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
