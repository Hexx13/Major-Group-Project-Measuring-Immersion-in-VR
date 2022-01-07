using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int sceneNumber;
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plaer")
        {
            SceneManager.LoadScene(sceneNumber);
        }
        
    }
}
