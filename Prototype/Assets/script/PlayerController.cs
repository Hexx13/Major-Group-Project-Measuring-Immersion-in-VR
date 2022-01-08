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
    // Start is called before the first frame update
    void Start()
    {
        _xrOrigin = GetComponent<XROrigin>();
        _collider = GetComponent<CapsuleCollider>();
        _body = GetComponent<Rigidbody>();
        jumpActionReference.action.performed += OnJump;
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(boby.velocity.magnitude);
        //footstep();
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

     void footstep()
     {
         
         
      Debug.Log(_body.velocity.magnitude);
         if(_isGrounded && audioPlayer.isPlaying == false && _body.velocity.magnitude == 0)
         {
             audioPlayer.volume = Random.Range(.8f, 1f);
             audioPlayer.pitch = Random.Range(.9f, 1f);
             audioPlayer.Play();
         }


     }

     private void OnJump(InputAction.CallbackContext obj)
    {
        if (!_isGrounded) return;
        _body.AddForce(Vector3.up * jumpForce);
        _isGrounded = false;
    }
}
