using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{    
    public static GameManager Instance { get; private set; }

    [Header("First Msg setup")]
    public GameObject FirstMsgDisplay;
    public Text FirstMsgTimer;
    private int countdownToStart = 3;
    public bool canStart = false;

    [Header("ScoreBoard")]
    public Text FirstPlayerScoreText;
    public Text SecondPlayerScoreText;
    private int FirstPlayerScore;
    private int SecondPlayerScore;
    public static string player1NameInGame;
    public static string player2NameInGame;

    [Header("GameOver Scrn")]
    public GameObject GameOverScrn;
    public GameObject FirstPlayerWon;
    public GameObject SecondPlayerWon;
    public GameObject TieScrn;
    public bool canPlay = false;

    [Header("Game Timer")]
    public float TimeLeft;
    public bool TimerOn = false;
    public Text TimerText;



    private void Awake()
    {
        /*if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }*/
        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitializePlayerNames();
        FirstMsgTimer.text = $"0" + countdownToStart;
        TimerOn = true;
        FirstMsgDisplay.SetActive(true);
    }

    private void Update()
    {
        StartClocks();        
    }

    void StartClocks()
    {        
        if (canStart == false && countdownToStart > 0)
        {
            StartCoroutine(FirstMsg());
        }
        else
        {
            Timer();
           
        }
    }

    IEnumerator FirstMsg()
    {
        canStart = true;
        yield return new WaitForSeconds(1);
        countdownToStart -= 1;
        FirstMsgTimer.text = $"0" + countdownToStart;
        canStart = false;
    }

    public void ScorePointPlayerOne(int point)
    {
        FirstPlayerScore += point;
        FirstPlayerScoreText.text = $"{player1NameInGame} Score : {FirstPlayerScore}";
    }

    public void ScorePointPlayerTwo(int point)
    {
        SecondPlayerScore += point;
        SecondPlayerScoreText.text = $"{player2NameInGame} Score : {SecondPlayerScore}";
    }      

    void InitializePlayerNames()
    {
        FirstPlayerScoreText.text = $"{player1NameInGame} Score : {FirstPlayerScore}";
        SecondPlayerScoreText.text = $"{player2NameInGame} Score : {SecondPlayerScore}";
    }

    void Timer()
    {
        if (TimerOn && countdownToStart == 0)
        {
            if (TimeLeft > 0)
            {
                FirstMsgDisplay.SetActive(false);
                TimeLeft -= Time.deltaTime;
                UpdateTimer(TimeLeft);
                canPlay = true;
            }
            else
            {
                Debug.Log("gameover");
                TimeLeft = 0;
                TimerOn = false;
                GameOver();
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = String.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void GameOver()
    {
        canPlay = false;
        GameOverScrn.SetActive(true);
        if (FirstPlayerScore > SecondPlayerScore)
        {
            FirstPlayerWon.SetActive(true);
        } else if (SecondPlayerScore> FirstPlayerScore)
        {
            SecondPlayerWon.SetActive(true);
        }
        else
        {
            TieScrn.SetActive(true);
        }       
    }
}
