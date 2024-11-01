using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        GameManager.Instance.runGame = true;
        GameManager.Instance.ToggleScreen(GameManager.Screen.Normal);
    }
    
}
