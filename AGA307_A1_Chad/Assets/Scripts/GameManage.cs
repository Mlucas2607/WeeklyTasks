using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static GameManage instance;
    public int highScore = 0;
    public Difficulty difficulty;
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
    }
    
    public void AddScore(int score)
    {
        highScore += score;
        UIManager.instance.UpdateHighScore();
    }
}

public enum Difficulty
{
       Easy,
       Normal,
       Hard
}