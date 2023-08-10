using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class Handler : MonoBehaviour
{
    [SerializeField]
    Player PlayerObj;
    [SerializeField]
    TMP_Text ScoreLabel;
    [SerializeField]
    GameObject Objects;
    [SerializeField]
    GameObject ObjectsStatic;
    [SerializeField]
    GameObject Foreground;
    [SerializeField]
    GameObject CirclePrefab;
    int Score = 0;
    bool IsGame = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerObj.collidedWithEnemy += EndGame;
        PlayerObj.collidedWithReward += IncScore;
        EndGame();
        StartCoroutine(Spam());
    }
    
    // Update is called once per frame
    void Update()
    {
        if (IsGame)
        {
            if (Input.GetButton("Jump"))
            {
                PlayerObj.Move(1);
            }
            else
            {
                PlayerObj.Move(-1);
            }
        }
        else 
        {
            if (Input.GetButton("Jump"))
            {
                StartGame();
            }
        }
    }

    IEnumerator Spam()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.02f);
            GameObject Circle = Instantiate(CirclePrefab);
            Circle.transform.SetParent(Objects.transform, true);
            Circle.transform.position = PlayerObj.transform.position;
            Destroy(Circle, 1.5f);
        }
    }

    void StartGame()
    {
        Time.timeScale = 1;
        Foreground.SetActive(false);
        IsGame = true;
    }

    void EndGame()
    {
        PlayerObj.ResetPos();
        Time.timeScale = 0;
        foreach (Transform child in Objects.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in ObjectsStatic.transform)
        {
            Destroy(child.gameObject);
        }
        Foreground.SetActive(true);
        Score = 0;
        ScoreLabel.text = 0.ToString();
        IsGame = false;
    }

    void IncScore()
    {
        Score++;
        ScoreLabel.text = Score.ToString();
    }

    void OnDestroy()
    {
        PlayerObj.collidedWithEnemy -= EndGame;
        PlayerObj.collidedWithReward -= IncScore;
    }
}
