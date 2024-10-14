using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Score : MonoBehaviour
{
    //controlar quando ele sai do trigger e vai add ponto e o gamemanager vai pontuar e registrar

    private void OnTriggerExit2D(Collider2D _other)
    {
        if (_other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddScore();
        }
    }
}
