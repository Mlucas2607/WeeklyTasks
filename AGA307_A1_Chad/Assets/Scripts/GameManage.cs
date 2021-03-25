using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static GameManage instance;
    public int highScore = 0;
    public GameState gameState;
    public Difficulty difficulty;
    int scoreMultiplier = 1;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        UIManager.instance.UpdateDifficulty();

        gameState = GameState.Start;
        difficulty = Difficulty.Easy;

        SetUp();
    }
    
    public void AddScore(int score)
    {
        highScore += score;
        UIManager.instance.UpdateHighScore();
    }

    void SetUp()
    {
        switch(difficulty)
        {
            case Difficulty.Easy:
                scoreMultiplier = 1;
                break;
            case Difficulty.Normal:
                scoreMultiplier = 2;
                break;
            case Difficulty.Hard:
                scoreMultiplier = 3;
                break;
        }
    }
}

public enum Difficulty
{
       Easy,
       Normal,
       Hard
}

public enum GameState
{
    Start,
    Playing,
    Paused,
    GameOver
}