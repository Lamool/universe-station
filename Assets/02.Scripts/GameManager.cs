using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int life = 3;
    private bool isGameOver = false;
    public int day = 1;
    public int dayCount = 0;
    public int DayCount
    {
        get
        {
            return dayCount;
        }
        set
        {
            dayCount = value;
            if(dayCount%10 == 0)
            {
                day++;
                Debug.Log($"{day} 일차");
                dayCount = 0;
            }
        }
    }
    public bool IsGameOver {
        get
        {
            return isGameOver;
        }

        set
        {
            isGameOver = value;
            if (isGameOver)
            {
                UIManager.instance.ConversationText.text = "게임 오버";
            }
        }
    }
    void Awake()
    {
        if (GameManager.Instance == null) GameManager.Instance = this;
        else if (GameManager.Instance != this) Destroy(gameObject);
    }

    public void ReduceLife()
    {
        if (isGameOver) return;
        life--;
        Debug.Log($"틀렸습니다. 남은 기회 : {life}");
        if (life <= 0) 
        {
            isGameOver = true;
            Debug.Log("게임 오버");
        }
    }


}
