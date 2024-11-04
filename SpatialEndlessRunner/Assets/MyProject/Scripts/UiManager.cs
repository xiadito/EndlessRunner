using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void RestartScene()
    {
        AudioController.Instance.buttonSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        GameManager.Instance.runGame = true;
        AudioController.Instance.buttonSound.Play();
        GameManager.Instance.ToggleScreen(GameManager.Screen.Normal);
    }
    
}
