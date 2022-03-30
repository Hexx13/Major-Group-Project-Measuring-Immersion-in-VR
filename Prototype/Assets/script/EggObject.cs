using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggObject : MonoBehaviour
{
    public AudioSource objectPlayer;
    private float timer = 5;
    public AudioClip ambience;

    public AudioClip onPickup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       timerPlayer();
    }

    void timerPlayer()
    {
        if (timer > 0)
        {
            PlayAmbience();
            timer = 20;
        }

    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("hand"))
        {
            objectPlayer.PlayOneShot(onPickup);
        }
    }

    void PlayAmbience()
    {
        if (!objectPlayer.isPlaying)
        {
            objectPlayer.PlayOneShot(ambience);
        }
    }
    
   
}
