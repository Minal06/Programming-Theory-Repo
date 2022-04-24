using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{    
    public static GameManager Instance { get; private set; }
    public Text FirstPlayerScoreText;
    public Text SecondPlayerScoreText;

    public GameObject GameOverScrn;

    public GameObject FirstPlayerWon;
    public GameObject SecondPlayerWon;
    public GameObject TieScrn;

    private int FirstPlayerScore;
    private int SecondPlayerScore;

    public static int setGameTime;
    public static string player1NameInGame;
    public static string player2NameInGame;
    public int gameTime
    {
        get { return m_gameTime; }
        set
        {
            if (1 <= value && value <= 9) { m_gameTime = value; }
            else { Debug.LogError("Use nrs between 1-9!"); setGameTime = 1; }
        }
    }
    private int m_gameTime = setGameTime;

    private bool gameOver = false;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitializePlayerNames();
    }

    private void Update()
    {
        
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

    public void GameOver()
    {
        gameOver = true;
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
