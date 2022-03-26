using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    private int challengeStatus = 0;
    private bool playerLeftSpawn = false;
    private int challengeCount = 0;

    //Step 1 - Run Voicover for introduction
    //  Step 2.1 - Introduce movement
    //      Step 2.1.1 - Run Voiceover for movement
    //      Step 2.1.2 - Confirm Movement
    //      Step 2.1.3 - Introduce Jump
    //  Step 2.2 - Introduce Looking around voiceover
    //Step 3 - Introduce Hand interaction
    //  Step 3.1 - Run voiceover for Hand interaction
    //Challenge 
    //  Run voiceover for challenge
    //  collect items and confirm
    //  reveal portal
    

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

        if(collision.gameObject.Equals(challengePrefabs[0])){
            challengeCount++;
            Debug.Log("Pouch enter");
        }else if(collision.gameObject.Equals(challengePrefabs[1])){
            challengeCount++;
            Debug.Log("Red Shroom enter");
        }else if(collision.gameObject.Equals(challengePrefabs[2])){
            challengeCount++;
            Debug.Log("Purple Shroom enter");
        }
        Debug.Log("Collision enter");
    }
    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Plaer"))Debug.Log("player left spawn");//playerLeftSpawn = true;
        

        if(collision.gameObject.Equals(challengePrefabs[0])){
            challengeCount--;
            Debug.Log("Pouch exit");
        }else if(collision.gameObject.Equals(challengePrefabs[1])){
            challengeCount--;
            Debug.Log("Red Shroom exit");
        }else if(collision.gameObject.Equals(challengePrefabs[2])){
            challengeCount--;
            Debug.Log("Purple Shroom exit");
        }
        Debug.Log("Collision eexit");
    }


    private void tutorial(){
        switch(challengeStatus){
            case 0:
                challenge1();
                if(playerLeftSpawn)challengeStatus++;
                break;
        
            case 1:
                challenge2();
                challengeStatus++;
                break;
                //make unity wait a few seconds

            case 2:
                challenge3();
                break;
        }


    }




    private void challenge1(){
        //intro voiceover
            //How to look around Voicover
            //How To move
            //how to jump
            

        


    }
    private void challenge2(){
        //how to pick up things voice over
        

    }
    private void challenge3(){
        scoreText.SetText("Items Collected " + challengeCount + "/3");
        if(challengeCount >= 3){
            for(int i = 0; i < portals.Length; i++)
            portals[i].SetActive(true);
        }
    }
}
