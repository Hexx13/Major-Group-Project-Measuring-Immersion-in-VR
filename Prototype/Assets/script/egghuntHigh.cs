using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.Serialization;

public class egghuntHigh : MonoBehaviour
{
    //old code from tutorial
    private int challengeCount = 0;


    //old code from tutorial
    public TextMeshPro scoreText;
    public AudioClip[] voiceoverSound;
    public AudioClip putDownNoise;
    public AudioClip onPickupNoise;
    public AudioSource soundPlayer;
    

    // easter egg array
    public GameObject[] eggs;
    public ParticleSystem[] eggParticleSystem;
    private float v1Delay = 3, v2Delay = 1.5f;
    private bool v1Played = false, v2Played = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hunt();
    }


    private void OnTriggerEnter(Collider collision)
    {
        for (int i = 0; i < eggs.Length; i++)
            if (collision.gameObject.Equals(eggs[i]))
            {
                //Count towards challenge completion
                challengeCount++;
                
                //make sound/sfx
                soundPlayer.PlayOneShot(onPickupNoise);
                
                // make particle effect
                eggs[i].gameObject.GetComponent<ParticleSystem>().Play();
                //disable gameobject
                eggs[i].SetActive(false);
            }
    }

    /*
    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Plaer"))Debug.Log("player left spawn");//playerLeftSpawn = true;

        for(int i = 0; i < eggs.Length; i++)
            if (collision.gameObject.Equals(eggs[0]))
            {
                challengeCount--;
                Debug.Log("Pouch exit");
            }

        Debug.Log("Collision eexit");
    }*/


    private void hunt()
    {
        //update score text
        scoreText.SetText("Hidden Items Found " + challengeCount + "/5");
        
        //itterate timer for voicover
        if (v1Delay >= 0 && !v1Played) v1Delay -= Time.deltaTime;
        else if (v1Delay <= 0 && !v1Played)
        {
            Debug.Log("Audio 1");
            //soundPlayer.PlayOneShot(voiceoverSound[1]);
            v1Played = true;
        }
        
        if (challengeCount >= 5)
        {
            if (v2Delay >= 0 && !v2Played) v2Delay -= Time.deltaTime;
            else if (v2Delay <= 0 && !v2Played)
            {
                v2Played = true;
                Debug.Log("Audio 2");
                //soundPlayer.PlayOneShot(voiceoverSound[2]);
                
            }
        }
    }
}