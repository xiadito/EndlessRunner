using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;


public class GameManager : MonoBehaviour
{
    public bool runGame;
    public bool pauseGame;

    [SerializeField] TextMeshProUGUI scoreTXT;
    [SerializeField] TextMeshProUGUI highscoreTXT;

    [SerializeField] GameObject normalScreen;
    [SerializeField] GameObject deadScreen;

    private int score;
    private int highscore;

    public enum Screen
    {
        Normal,
        Dead,
    }

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;

        score = 0;
        highscore = PlayerPrefs.GetInt("HighScore");

        UpdateScore();
        UpdateHighScore(); 
    }

    public void ToggleScreen(Screen _screen)
    {
        switch (_screen)
        {
            case Screen.Normal:

                normalScreen.SetActive(true);
                deadScreen.SetActive(false);

                break;

            case Screen.Dead:

                deadScreen.SetActive(true);
                normalScreen.SetActive(false);
                
                break;
        }
    }

    public void AddScore()
    {
       score++;
       UpdateScore();
       SetHighScore();
    }

    public void SetHighScore()
    {
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HighScore", highscore);
            UpdateHighScore();
        }
    }

    public void UpdateScore()
    {
        scoreTXT.text = score.ToString("00000");
    }

    public void UpdateHighScore()
    {
        highscoreTXT.text = highscore.ToString("00000");
    }




}
