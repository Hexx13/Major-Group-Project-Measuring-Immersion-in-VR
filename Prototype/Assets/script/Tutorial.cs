using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject portal;
    
    private int challengeStatus = 0;
    private bool playerEnterCircle = false;
    //public AudioClip startTutorialClip;

    private bool step1Played = false;
    private float step1Delay = 3f;
    public AudioClip step1Clip;

    
    
    private bool step2Played = false;
    private float step2Delay = 22f;
    public AudioClip step2Clip;
    
    
    private bool step3Played = false;
    private float step3Delay = 23f;
    public AudioClip step3Clip;

    private bool step4Played = false;
    private float step4Delay = 21f;
    public AudioClip step4Clip;
   
    
    private int challengeCount = 0;
    

    
    public AudioClip[] voiceoverSound;
    public AudioSource tutorialPlayer;

    private float startTutorialTimer = 5;
    private float v1Delay = 2, v2Delay = 1.5f;
    private bool v1Played = false, v2Played = false;
    

    public TextMeshPro scoreText;
    public GameObject xrCore;
    public GameObject [] portals;
    public GameObject [] challengePrefabs;
    private BoxCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        level();
    }


    private void OnTriggerEnter(Collider collision)
    {
       
        for (int i = 0; i < challengePrefabs.Length; i++)
            if (collision.gameObject.Equals(challengePrefabs[i]))
            {
                //Count towards challenge completion
                challengeCount++;
                
                Debug.Log("pouch in" + challengeCount);
                
                //make sound/sfx
                // soundPlayer.PlayOneShot(onPickupNoise);
                
                // make particle effect
                //eggs[i].gameObject.GetComponent<ParticleSystem>().Play();
            }
    }
    private void OnTriggerExit(Collider collision)
    {
        for (int i = 0; i < challengePrefabs.Length; i++)
            if (collision.gameObject.Equals(challengePrefabs[i]))
            {
                //Count towards challenge completion
                challengeCount--;
                
                Debug.Log("pouch out" + challengeCount);
                
                //make sound/sfx
                // soundPlayer.PlayOneShot(onPickupNoise);
                
                // make particle effect
                //eggs[i].gameObject.GetComponent<ParticleSystem>().Play();
            }
    }
    
    private void end()
    {
        if (v2Delay >= 0 && !v2Played) v2Delay -= Time.deltaTime;
        else if (v2Delay <= 0 && !v2Played)
        {
            v2Played = true;
            Debug.Log("Audio 2");
            tutorialPlayer.PlayOneShot(voiceoverSound[4]);
            
            portal.SetActive(true);
        }
    }

    private void level()
    {
        //update score text
        // scoreText.SetText("Hidden Items Found " + challengeCount + "/3");
        // Debug.Log("Hidden Items Found " + challengeCount + "/3");
        
        
        //Welcome them to experiment
        //Warn them that they can leave at any time
        if (step1Delay >= 0 && !step1Played) step1Delay-= Time.deltaTime;
        else if (step1Delay <= 0 && !step1Played)
        {
            Debug.Log("Step 1 done");
            tutorialPlayer.PlayOneShot(voiceoverSound[0]);
            step1Played = true;
        }

        //How to look around Voicover
            //How To move
             //how to jump
        if (step1Played)
        {
            if (step2Delay >= 0 && !step2Played) step2Delay -= Time.deltaTime;
            else if (step2Delay <= 0 && !step2Played)
            {
                Debug.Log("Step 2 done");
                tutorialPlayer.PlayOneShot(voiceoverSound[1]);
                step2Played = true;
            }
        }
        
        
        //how to pick up things voice over
        if (step2Played)
        {
            if (step3Delay >= 0 && !step3Played) step3Delay -= Time.deltaTime;
            else if (step3Delay <= 0 && !step3Played)
            {
                Debug.Log("Step 3 done");
                tutorialPlayer.PlayOneShot(voiceoverSound[2]);
                step3Played = true;
            }
        }
        
        
        //challenge them to put things in circle
        if (step3Played)
        {
            if (step4Delay >= 0 && !step4Played) step4Delay -= Time.deltaTime;
            else if (step4Delay <= 0 && !step4Played)
            {
                Debug.Log("Step 4 done");
                tutorialPlayer.PlayOneShot(voiceoverSound[3]);
                step4Played = true;
            }
        }
        
        if (challengeCount >= 3) end();
        
    }
}