using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountains : MonoBehaviour
{
    [SerializeField] GameObject[] visuals;

    private void Awake()
    {
        SetNewVisual();
    }

    public void SetNewVisual()
    {
        foreach (var visual in visuals)
        {
            visual.gameObject.SetActive(false);
        }

        for (int i = 0; i < Random.Range(0,3); i++)
        {
            int x = Random.Range(0, visuals.Length);

            visuals[x].gameObject.SetActive(true);
        }
    }
}
