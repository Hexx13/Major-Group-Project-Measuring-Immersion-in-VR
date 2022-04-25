using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleCourse : MonoBehaviour
{
    
    public AudioSource soundPlayer;

    private bool winCondition = false;
    
    private float v1Delay = 2, v2Delay = .5f;
    private bool v1Played = false, v2Played = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        level();
    }


   

    private void OnTriggerEnter(Collider collision)
    {
        
            if (collision.gameObject.Equals())
            {
                winCondition = true;
            }
    }




    private void level()
    {
        //itterate timer for voicover
        if (v1Delay >= 0 && !v1Played) v1Delay -= Time.deltaTime;
        else if (v1Delay <= 0 && !v1Played)
        {
            Debug.Log("Audio 1");
            //soundPlayer.PlayOneShot(voiceoverSound[1]);
            v1Played = true;
        }
        
        if (winCondition)
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