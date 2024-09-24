using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCamera : MonoBehaviour
{

    [SerializeField] Transform player;

    private void Update()
    {
        CameraToPlayer();
    }

    void CameraToPlayer()
    {
        Vector2 _position = transform.position;
        _position.x = player.position.x;
        transform.position = _position;
    }
}
