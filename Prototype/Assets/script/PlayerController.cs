using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] private InputActionReference jumpActionReference;
    [SerializeField] private float jumpForce = 500;
    private XROrigin _xrOrigin;
    private CapsuleCollider _collider;
    private Rigidbody _body;
    public AudioSource audioPlayer;
    private bool _isGrounded=true;
 
    public Rigidbody boby;

    private Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
       
        lastPos = boby.transform.position;
        _xrOrigin = GetComponent<XROrigin>();
        _collider = GetComponent<CapsuleCollider>();
        _body = GetComponent<Rigidbody>();
        jumpActionReference.action.performed += OnJump;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        footstep();
        var center = _xrOrigin.CameraInOriginSpacePos;
        _collider.center = new Vector3(center.x, _collider.center.y, center.z);
        _collider.height = _xrOrigin.CameraInOriginSpaceHeight;
    }

    
     void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.tag == "Floor")
             _isGrounded = true;

         if (collision.gameObject.tag=="Prop")
        Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());     
     }


    //Function to check if the player is moving by comparing its current position to its last position
     Boolean isMoving()
     {
         Boolean _isMoving = (boby.transform.position != lastPos);
         lastPos = boby.transform.position;
         return _isMoving;
     }


    //Plays footstep whenever the player moves
     void footstep()
     {
         //makes sure player is on the ground, step sound isnt playing and player is moving.
         if(_isGrounded && audioPlayer.isPlaying == false && isMoving())
         {
             //play sound
             audioPlayer.volume = Random.Range(.8f, 1f);
             audioPlayer.pitch = Random.Range(.9f, 1f);
             audioPlayer.Play();
         }


     }

    //changes the global variablere _isGrounded to false and makes the player physically jump
     private void OnJump(InputAction.CallbackContext obj)
    {
        //makes sure the player is grounded.
        if (!_isGrounded) return;
        _body.AddForce(Vector3.up * jumpForce);
        _isGrounded = false;
    }
}
