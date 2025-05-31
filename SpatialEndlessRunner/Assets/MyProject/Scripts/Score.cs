using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Score : MonoBehaviour
{
    //Controlls when the player leave the trigger e add the point through the game manager

    private void OnTriggerExit2D(Collider2D _other)
    {
        if (_other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddScore();
        }
    }
}
