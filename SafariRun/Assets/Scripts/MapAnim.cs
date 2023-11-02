using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAnim : MonoBehaviour
{
    public Animator animator1;
    public GameObject player1;
    public Animator animator2;
    public GameObject player2;

    public List<GameObject> pathList;
    public List<bool> animaList;
    public List<bool> animaList2;

    private bool level2;
    private bool level3;
    private bool level4;
    private bool level5;
    private bool level6;
    private bool level7;
    
    private Vector2 position1;
    private Vector2 position2;
    private Vector2 temp;
    public GameObject Level2Button;
    private float speed = 2f;
    public float level2x;

    void Start() {
        level2 = (LevelUnlock.level2) ? true : false;
        //level3 = (LevelUnlock.level2) ? true : false;
        //level4 = (LevelUnlock.level2) ? true : false;
        //level5 = (LevelUnlock.level2) ? true : false;
        //level6 = (LevelUnlock.level2) ? true : false;
        //level7 = (LevelUnlock.level2) ? true : false;

        levelCheck(level2, 1);
    }

    void Update() {
        if (!animaList[1]) {
            disabledPaths(1);
        }
        if (animaList2[1]) {
            animator1.SetTrigger("isAnimated");
            animator2.SetTrigger("isAnimated");
            
            temp.x = 0;
            temp.y = player1.transform.position.y;
            StartCoroutine(timer2());
            
        }
    }

    void disabledPaths(int i) {
        for (int j = (i-1) * 4; j < i * 4; j++) {
            pathList[j].SetActive(false);
        } 
    }

    IEnumerator timer(int i) {
        yield return new WaitForSeconds(0.5f);
        animaList[i] = true;
        StartCoroutine(Anim(i));
    }

    IEnumerator timer2() {
        player1.transform.position = Vector2.MoveTowards(player1.transform.position, temp, Time.deltaTime * speed);
        yield return new WaitForSeconds(0.5f);
        temp.y = player2.transform.position.y;
        player2.transform.position = Vector2.MoveTowards(player2.transform.position, temp, Time.deltaTime * speed);
    }

    IEnumerator Anim(int i) {
        int j = (i - 1) * 4;
        yield return new WaitForSeconds(0.5f);
        pathList[j].SetActive(true);
        j++;
        yield return new WaitForSeconds(0.5f);
        pathList[j].SetActive(true);
        j++;
        yield return new WaitForSeconds(0.5f);
        pathList[j].SetActive(true);
        j++;
        yield return new WaitForSeconds(0.5f);
        pathList[j].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        animaList2[i] = true;
    }

    void levelCheck(bool level, int i) {
        if (level && !animaList[i]) {
            StartCoroutine(timer(i));
        }
    }
    
}
