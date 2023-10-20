using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public List<GameObject> frutas;
    public int sizeList;
    private bool isNotOver;
    public GameObject trophy;
    public Animator animator;
    public AudioClip soundWin;
    private AudioSource audioSource;

    void Start(){
        trophy.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void Update(){
        isNotOver = false;
        for (int i = 0; i < sizeList; i++) {
            if (frutas[i].activeSelf) {
                isNotOver = true;
            }
        }

        if (!isNotOver) {
            trophy.SetActive(true);
            StartCoroutine(timer());      
        }
    } 

    IEnumerator timer() {
        yield return new WaitForSeconds(0.4f);
        audioSource.PlayOneShot(soundWin);
        animator.SetTrigger("appear");
    }
}
