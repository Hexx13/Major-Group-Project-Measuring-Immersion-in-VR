using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    private int challengeStatus = 0;
    private bool playerEnterCircle = false;
   
    
    private int challengeCount = 0;


    
    public AudioClip[] voiceoverSound;
    public AudioSource tutorialPlayer;
    
    
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
        //tutorial();
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Plaer"))
        {
        }
        else
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
    
    
    
    private void level()
    {
        if (playerEnterCircle)
        {
            //update score text
            scoreText.SetText("Hidden Items Found " + challengeCount + "/3");
        
        
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
        else
        {
            
        }
        
        
    }
}
    

    
//
//
//     private void tutorial(){
//         switch(challengeStatus){
//             case 0:
//                 challenge1();
//                 if(playerLeftSpawn)challengeStatus++;
//                 break;
//         
//             case 1:
//                 challenge2();
//                 challengeStatus++;
//                 break;
//                 //make unity wait a few seconds
//
//             case 2:
//                 challenge3();
//                 break;
//         }
//
//
//     }
//
//
//
//
//     private void challenge1(){
//         //intro voiceover
//         tutorialPlayer.PlayOneShot(voiceoverSound[0]);
//             //How to look around Voicover
//             //How To move
//             //how to jump
//             
//
//         
//
//
//     }
//     private void challenge2(){
//         tutorialPlayer.PlayOneShot(voiceoverSound[1]);
//         //how to pick up things voice over
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
