using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text highScoreUI;
    public Text timerUI;
    public Text difficultyUI;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    
    public void UpdateHighScore()
    {
        highScoreUI.text = "High Score: " + GameManage.instance.highScore;

    }
    public void UpdateDifficulty()
    {
        difficultyUI.text = "Difficulty: " + GameManage.instance.difficulty.ToString();
    }
}
