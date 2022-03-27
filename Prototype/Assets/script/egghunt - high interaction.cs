using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class egghunt : MonoBehaviour
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


    private void OnTriggerEnter(Collider collision)
    {
        for(int i = 0; i < eggs.Length; i++)
            if(collision.gameObject.Equals(eggs[i])){
                challengeCount++;
                Debug.Log("Pouch enter");
            }
        Debug.Log("Collision enter");
    }
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
    }


    private void hunt(){
       
        soundPlayer.PlayOneShot(voiceoverSound[1]);
        scoreText.SetText("Items Collected " + challengeCount + "/5");
        if(challengeCount >= 3){
            for(int i = 0; i < portals.Length; i++)
                portals[i].SetActive(true);
        }
    }
}
