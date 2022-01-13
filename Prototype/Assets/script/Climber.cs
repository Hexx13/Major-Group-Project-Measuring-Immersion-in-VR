using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class Climber : MonoBehaviour
{

    private CharacterController character;
    public static XRController climbingHand;
    private ActionBasedContinuousMoveProvider coninousMovement;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        coninousMovement = GetComponent<ActionBasedContinuousMoveProvider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(climbingHand){
            coninousMovement.enabled = false;
            Climb();
        }
    }

    void Climb(){
        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
        character.Move(-velocity * Time.fixedDeltaTime);
    }
}
