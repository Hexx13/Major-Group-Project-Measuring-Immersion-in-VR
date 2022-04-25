using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomSound : MonoBehaviour
{
    public AudioSource objectPlayer;
    public AudioClip onPickup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        objectPlayer.PlayOneShot(onPickup);
    }
}
