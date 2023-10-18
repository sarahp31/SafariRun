using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;
using UnityEditor;
using System;


public class EndLevel : MonoBehaviour
{
    public List<GameObject> frutas;
    public int sizeList;
    private bool isNotOver;
    private bool isOver;
    public Animator animator;
    public int currentLevel;

    void Start(){
        animator.ResetTrigger("collected");
        animator.ResetTrigger("end");
        isOver = false;
    }

    void Update(){
        isNotOver = false;
        for (int i = 0; i < sizeList; i++) {
            if (frutas[i].activeSelf) {
                isNotOver = true;
            }
        }

        if (!isNotOver) {
            animator.SetTrigger("collected");
            StartCoroutine(timer());
        }
    } 

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.name == "Player_1" || collider.gameObject.name == "Player_2"){
            if (isOver) {
                UnlockNextLevel();
                StartCoroutine(timer2());
            }
        }
    }

    IEnumerator timer() {
        yield return new WaitForSeconds(0.4f);
        animator.SetTrigger("end");
        isOver = true;
    }

    IEnumerator timer2() {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(3);
    }

    void UnlockNextLevel(){
        if (currentLevel == 1) {
            LevelUnlock.level2 = true;
        }
        else if (currentLevel == 2) {
            LevelUnlock.level3 = true;
        }
        else if (currentLevel == 3) {
            LevelUnlock.level4 = true;
        }
        else if (currentLevel == 4) {
            LevelUnlock.level5 = true;
        }
        else if (currentLevel == 5) {
            LevelUnlock.level6 = true;
        }
        else if (currentLevel == 6) {
            LevelUnlock.level7 = true;
        }
    }

}
