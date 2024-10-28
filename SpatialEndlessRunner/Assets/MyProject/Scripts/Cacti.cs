using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacti : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D _other)
    {
        _other.gameObject.GetComponent<PlayerController>().isDead = true;
        _other.gameObject.GetComponent<PlayerController>().Death();
    }

}
