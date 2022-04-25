using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    private int challengeStatus = 0;
    private bool playerEnterCircle = false;
    //public AudioClip startTutorialClip;

    private bool step1Played = false;
    private float step1Delay = 3f;
    public AudioClip step1Clip;

    
    
    private bool step2Played = false;
    private float step2Delay = .5f;
    public AudioClip step2Clip;
    
    
    private bool step3Played = false;
    private float step3Delay = .5f;
    public AudioClip step3Clip;

    private bool step4Played = false;
    private float step4Delay = .5f;
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
                
                //make sound/sfx
                // soundPlayer.PlayOneShot(onPickupNoise);
                
                // make particle effect
                //eggs[i].gameObject.GetComponent<ParticleSystem>().Play();
            }
        
        Debug.Log("Collision enter");
    }
    private void OnTriggerExit(Collider collision)
    {
        for (int i = 0; i < challengePrefabs.Length; i++)
            if (collision.gameObject.Equals(challengePrefabs[i]))
            {
                //Count towards challenge completion
                challengeCount--;
                
                //make sound/sfx
                // soundPlayer.PlayOneShot(onPickupNoise);
                
                // make particle effect
                //eggs[i].gameObject.GetComponent<ParticleSystem>().Play();
            }
    }

    private void start()
    {
        //play sound on loop
        if (startTutorialTimer >= 0) startTutorialTimer -= Time.deltaTime;
        else
        {
            //soundPlayer.PlayOneShot(startTutorialClip);
            startTutorialTimer = 6f;
            Debug.Log("Please Enter the stone Circle in front of you when you are ready to start the tutorial");
        }
    }

    private void step(float delay, bool played, AudioClip audioClip)
    {
        //itterate timer for voicover
        if (delay >= 0 && !played) v1Delay -= Time.deltaTime;
        else if (v1Delay <= 0 && !played)
        {
            //soundPlayer.PlayOneShot(voiceoverSound[1]);
            played = true;
        }
    }
    
    private void step(float delay, bool played, AudioClip audioClip, String debug)
    {
        //itterate timer for voicover
        if (delay >= 0 && !played) v1Delay -= Time.deltaTime;
        else if (v1Delay <= 0 && !played)
        {
            Debug.Log(debug);
            //soundPlayer.PlayOneShot(voiceoverSound[1]);
            played = true;
        }
    }
    
    

    private void step2()
    {
        
    }
    private void step3(){}

    private void end()
    {
        if (v2Delay >= 0 && !v2Played) v2Delay -= Time.deltaTime;
        else if (v2Delay <= 0 && !v2Played)
        {
            v2Played = true;
            Debug.Log("Audio 2");
            //soundPlayer.PlayOneShot(voiceoverSound[2]);
            
            //TODO make portal visible
        }
    }

    private void level()
    {
        //update score text
        scoreText.SetText("Hidden Items Found " + challengeCount + "/3");
            
        step(step1Delay, step1Played, step1Clip, "Step1");
        //Welcome them to experiment
        //Warn them that they can leave at any time
            
        step(step2Delay, step1Played, step1Clip, "Step2");
        //How to look around Voicover
//             //How To move
//             //how to jump
        
        step(step3Delay, step1Played, step1Clip, "Step3");
        //how to pick up things voice over
            
            
        step(step4Delay, step1Played, step1Clip, "Step4");
        //challenge them to put things in circle
        if (challengeCount >= 3) end();
        
    }
}
    

//
//
//

//     private void challenge2(){
//         tutorialPlayer.PlayOneShot(voiceoverSound[1]);
//         
//         
//
//     }
//     private void challenge3(){
//         tutorialPlayer.PlayOneShot(voiceoverSound[2]);
//         scoreText.SetText("Items Collected " + challengeCount + "/3");
//         if(challengeCount >= 3){
//             for(int i = 0; i < portals.Length; i++)
//             portals[i].SetActive(true);
//         }
//     }
// }