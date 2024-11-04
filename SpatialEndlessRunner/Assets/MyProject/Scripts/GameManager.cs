using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool runGame;
    public bool pauseGame;

    [SerializeField] TextMeshProUGUI scoreTXT;
    [SerializeField] TextMeshProUGUI highscoreTXT;

    [SerializeField] GameObject menuScreen;
    [SerializeField] GameObject normalScreen;
    [SerializeField] GameObject deadScreen;

    private int score;
    private int highscore;

    public enum Screen
    {   
        Menu,
        Normal,
        Dead,
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        ResetScore();
        highscore = PlayerPrefs.GetInt("HighScore");

        UpdateScore();
        UpdateHighScore(); 
    }

    public void ToggleScreen(Screen _screen)
    {
        switch (_screen)
        {
            case Screen.Menu:

                normalScreen.SetActive(false);
                deadScreen.SetActive(false);
                menuScreen.SetActive(true);

                break;  

            case Screen.Normal:

                deadScreen.SetActive(false);
                menuScreen.SetActive(false);
                normalScreen.SetActive(true);

                break;

            case Screen.Dead:

                normalScreen.SetActive(false);
                menuScreen.SetActive(false);
                deadScreen.SetActive(true);
                
                break;
        }
    }

    public void ResetScore()
    {
        /** Set the variable score to 0. **/
        score = 0;
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
