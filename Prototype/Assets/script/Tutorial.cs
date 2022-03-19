using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    private bool challengeItem1,  challengeItem2,  challengeItem3;

    //Step 1 - Run Voicover for introduction
    //Step 2 
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
    

    public GameObject xrCore;
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
        
    }


    private void OnTriggerEnter(Collider collision)
    {

        if(collision.gameObject.Equals(challengePrefabs[0])){
            challengeItem1 = true;
            Debug.Log("Pouch enter");
        }else if(collision.gameObject.Equals(challengePrefabs[1])){
            challengeItem2 = true;
            Debug.Log("Red Shroom enter");
        }else if(collision.gameObject.Equals(challengePrefabs[2])){
            challengeItem3 = true;
            Debug.Log("Purple Shroom enter");
        }
        Debug.Log("Collision enter");
    }
    private void OnTriggerExit(Collider collision)
    {
        
        if(collision.gameObject.Equals(challengePrefabs[0])){
            challengeItem1 = false;
            Debug.Log("Pouch exit");
        }else if(collision.gameObject.Equals(challengePrefabs[1])){
            challengeItem2 = false;
            Debug.Log("Red Shroom exit");
        }else if(collision.gameObject.Equals(challengePrefabs[2])){
            challengeItem3 = false;
            Debug.Log("Purple Shroom exit");
        }
        Debug.Log("Collision eexit");
    }
}
