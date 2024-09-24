using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    [SerializeField] int objQuantity;
    [SerializeField] float objDistance;
    [SerializeField] string tagTarget;

    private void OnTriggerExit2D(Collider2D _other)
    {
        if (_other.CompareTag(tagTarget))
        {

            Debug.Log(_other.name);

            Vector2 _newPosition = _other.transform.position;
            _newPosition.x += objQuantity * objDistance;
            _other.transform.position = _newPosition;

        }
    }

}
