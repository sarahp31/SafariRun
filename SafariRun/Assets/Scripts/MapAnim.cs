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
    public List<bool> animatedList;
    public List<bool> animatingList;

    private bool level2;
    private bool level3;
    private bool level4;
    private bool level5;
    private bool level6;
    private bool level7;
    
    private Vector2 temp;
    private float speed = 2f;

    public int world;
    public static int currentWorld;
    private int wl1;
    private int wl2;

    private bool localAnimated1;
    private bool localAnimated2;

    void Start() {
        currentWorld = world;
        if (world == 1) {
            level2 = (LevelUnlock.level2) ? true : false;
            level3 = (LevelUnlock.level3) ? true : false;
            localAnimated1 = MapAnimList.animated1;
            localAnimated2 = MapAnimList.animated2;
        } else if (world == 2) {
            level2 = (LevelUnlock.level4) ? true : false;
            level3 = (LevelUnlock.level5) ? true : false;
            localAnimated1 = MapAnimList.animated3;
            localAnimated2 = MapAnimList.animated4;
        } else if (world == 3) {
            level2 = (LevelUnlock.level6) ? true : false;
            level3 = (LevelUnlock.level7) ? true : false;
            localAnimated1 = MapAnimList.animated5;
            localAnimated2 = MapAnimList.animated6;
        }

        animatedList[1] = localAnimated1;
        animatedList[2] = localAnimated2;
        
        wl2 = world * 2;
        wl1 = wl2 - 1;
        levelCheck(level2, 1);
        levelCheck(level3, 2);

        if (!animatedList[1]) {
            player1.transform.position = new Vector2(-4, player1.transform.position.y);
            player2.transform.position = new Vector2(-4, player2.transform.position.y);
        } else if (animatedList[1]) {
            player1.transform.position = new Vector2(0, player1.transform.position.y);
            player2.transform.position = new Vector2(0, player2.transform.position.y);
        }
    }

    void Update() {
        for (int i = 1; i < 3; i++) {
            if (!animatedList[i]) {
                disabledPaths(i);
            }
            if (animatingList[i] && !animatingList[i-1]) {
                animator1.SetTrigger("isAnimated");
                animator2.SetTrigger("isAnimated");
                
                if (i == 1) {
                    temp.x = 0;
                } else if (i == 2) {
                    temp.x = 4;
                }
                temp.y = player1.transform.position.y;
                StartCoroutine(timer2(i));
                
            }
        }
    }

    void disabledPaths(int i) {
        for (int j = (i-1) * 4; j < i * 4; j++) {
            pathList[j].SetActive(false);
        } 
    }

    IEnumerator timer(int i) {
        yield return new WaitForSeconds(0.5f);
        animatedList[i] = true;
        updateMapAnimList(i);
        
        StartCoroutine(Anim(i));
    }

    IEnumerator timer2(int i) {
        player1.transform.position = Vector2.MoveTowards(player1.transform.position, temp, Time.deltaTime * speed);
        yield return new WaitForSeconds(0.5f);
        temp.y = player2.transform.position.y;
        player2.transform.position = Vector2.MoveTowards(player2.transform.position, temp, Time.deltaTime * speed);
        if (player2.transform.position.x == temp.x) {
            animatingList[i] = false;
            animator1.SetTrigger("isStill");
            animator2.SetTrigger("isStill");
        }       
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
        animatingList[i] = true;
    }

    void levelCheck(bool level, int i) {
        if (level && !animatedList[i]) {
            StartCoroutine(timer(i));
        }
    }

    void updateMapAnimList(int i) {
        if (world == 1) {
            if (i == 1) {
                MapAnimList.animated1 = true;
            } else if (i == 2) {
                MapAnimList.animated2 = true;
            }
        } else if (world == 2) {
            if (i == 1) {
                MapAnimList.animated3 = true;
            } else if (i == 2) {
                MapAnimList.animated4 = true;
            }
        } else if (world == 3) {
            if (i == 1) {
                MapAnimList.animated5 = true;
            } else if (i == 2) {
                MapAnimList.animated6 = true;
            }
        }
    }
    
}
