using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform player;

    Vector2 startPos;
    float startPosZ;

    Vector2 travelDistance => new Vector2(mainCamera.transform.position.x - startPos.x, startPos.y);

    float distanceFromPlayer => transform.position.z - player.position.z;

    float clippingPlane => (mainCamera.transform.position.z + (distanceFromPlayer > 0 ? mainCamera.farClipPlane : mainCamera.nearClipPlane ));

    float parallaxFactor => Mathf.Abs(distanceFromPlayer) / clippingPlane;

    private void Awake()
    {
        startPos = transform.position;
        startPosZ = transform.position.z;
    }

    private void Update()
    {
        Vector2 _newPos = new Vector2(startPos.x + travelDistance.x * parallaxFactor, startPos.y);
        transform.position = new Vector3(_newPos.x, _newPos.y,startPosZ);
    }
}
