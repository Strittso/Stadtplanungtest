using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
public class FlightMode : MonoBehaviour
{
    private CharacterController character;
    public bool toggleFly = false;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 direction = new Vector3(0, 0, 0);
        bool controllerY;
        bool controllerX;
        bool controllerTrigger;
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);
        UnityEngine.XR.InputDevice device_left = leftHandDevices[0];
        if(device_left.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out controllerTrigger) && controllerTrigger) {
            if(!toggleFly) {
                toggleFly = true;
            } else {
                toggleFly = false;
            }
        }
        //Global Gravity #TODO
        if (device_left.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out controllerY) && controllerY && toggleFly) {
            if(transform.position.y < 30) {
                direction.y += 10f;
                character.Move(direction * Time.deltaTime);
                Debug.Log("Btn Y " + transform.position.y);
            }
        } else if(device_left.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out controllerX) && controllerX && toggleFly) {
            if(!character.isGrounded) {
                direction.y -= 10f;
                character.Move(direction * Time.deltaTime);
                Debug.Log("Btn X " + transform.position.y);
            }
        }
    }
}
