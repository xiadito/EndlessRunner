using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        _position.x = player.position.x + 5; //+5 to center the camera
        transform.position = _position;
    }
}
