using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class egghuntLow : MonoBehaviour
{
    //old code from tutorial
    private int challengeStatus = 0;
    private bool playerLeftSpawn = false;
    private int challengeCount = 0;

    
    //old code from tutorial
    public TextMeshPro scoreText;
    public AudioClip[] voiceoverSound;
    public AudioSource soundPlayer;
    public GameObject [] portals;
    private BoxCollider collider;
    // easter egg array
    public GameObject [] eggs;
    
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


    private void OnCollisionEnter(Collider collision)
    {
        for(int i = 0; i < eggs.Length; i++)
            if(collision.gameObject.Equals(eggs[i])){
                challengeCount++;
                
                
                //make sound/sfx
                soundPlayer.PlayOneShot(voiceoverSound[0]);
                //disable gameobject
                eggs[i].SetActive(false);
            }
        
        
        
        
       /* for(int i = 0; i < eggs.Length; i++)
            if(collision.gameObject.Equals(eggs[i])){
                challengeCount++;
                Debug.Log("Pouch enter");
            }
        Debug.Log("Collision enter");*/
    }
   

    private void hunt(){
       
        soundPlayer.PlayOneShot(voiceoverSound[1]);
        scoreText.SetText("Items Collected " + challengeCount + "/5");
        if(challengeCount >= 5){
            for(int i = 0; i < portals.Length; i++)
                portals[i].SetActive(true);
        }
    }
}
