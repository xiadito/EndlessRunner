using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    public AudioSource jumpSound;
    public AudioSource deathSound;
    public AudioSource landSound;
    public AudioSource buttonSound;

    private void Awake()
    {
        Instance = this;
    }
}
