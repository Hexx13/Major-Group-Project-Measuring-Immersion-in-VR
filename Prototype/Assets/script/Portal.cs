using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    //scene number value for teleporter, set in editor
    public int sceneNumber;

    //when the user collides with the portal they are sent to a different level
     void OnCollisionEnter(Collision collision)
    {
        //ensures that only player will trigger this
        if (collision.gameObject.tag == "Plaer")
        {
            SceneManager.LoadScene(sceneNumber);
        }
        
    }
}
