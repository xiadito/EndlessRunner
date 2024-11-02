using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cactus : MonoBehaviour
{

    [SerializeField] GameObject[] visual;

    private void Awake()
    {
        SetNewVisual();
    }

    public void SetNewVisual()
    {

        foreach (var item in visual)
        {
            item.gameObject.SetActive(false);
        }

        int i = Random.Range(0, visual.Length);

        visual[i].gameObject.SetActive(true);
    }

}

