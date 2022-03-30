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
    public AudioClip pickupNoise;
    public AudioSource soundPlayer;
    public GameObject[] portals;

    private float v1Delay = 5, v2Delay = 1.5f;
    private bool v1Played = false, v2Played = false;

    // easter egg array
    public GameObject[] eggs;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        hunt();
    }


    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < eggs.Length; i++)
            if (collision.gameObject.Equals(eggs[i]))
            {
                challengeCount++;

                //make sound/sfx
                soundPlayer.PlayOneShot(pickupNoise);
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


    private void hunt()
    {
        scoreText.SetText("Hidden Items Found " + challengeCount + "/5");


        if (v1Delay >= 0 && !v1Played) v1Delay -= Time.deltaTime;
        else if (v1Delay <= 0 && !v1Played)
        {
            v1Played = true;
            soundPlayer.PlayOneShot(voiceoverSound[1]);
        }


        if (challengeCount >= 5)
        {
            for (int i = 0; i < portals.Length; i++)
                //portal animation here Egguard
                portals[i].SetActive(true);

            if (v2Delay >= 0 && !v2Played) v2Delay -= Time.deltaTime;
            else if (v2Delay <= 0 && !v2Played)
            {
                v2Played = true;
                soundPlayer.PlayOneShot(voiceoverSound[2]);
            }
        }
    }
}