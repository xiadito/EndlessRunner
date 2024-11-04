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
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void RestartScene()
    {
        AudioController.Instance.buttonSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.Instance.ToggleScreen(GameManager.Screen.Menu);
    }

    public void StartGame()
    {
        GameManager.Instance.runGame = true;
        AudioController.Instance.buttonSound.Play();
        GameManager.Instance.ToggleScreen(GameManager.Screen.Normal);
    }
    
}
