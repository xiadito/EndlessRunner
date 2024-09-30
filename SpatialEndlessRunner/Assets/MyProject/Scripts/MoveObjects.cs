using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    [SerializeField] int objQuantity;
    [SerializeField] float objDistance;
    [SerializeField] string tagTarget;
    [SerializeField] bool changeVisual;
    

    private void OnTriggerExit2D(Collider2D other)
    {           
        MoveScenario(other);

       
    }

    void MoveScenario(Collider2D _other)
    {
        if (_other.CompareTag(tagTarget))
        {
            if (tagTarget == "Cactus")
            {
                _other.GetComponent<Cactus>().SetNewVisual();
            }

            Vector2 _newPosition = _other.transform.position;
            _newPosition.x += objQuantity * objDistance;
            _other.transform.position = _newPosition;

        }
    }
}
