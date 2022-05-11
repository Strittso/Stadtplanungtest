using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class ToggleRay_Left : MonoBehaviour
{
    public XRRayInteractor rayInteractor;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
        bool joystickTouch;
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();

        try
        {
            UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);
            UnityEngine.XR.InputDevice device_left = leftHandDevices[0];
            if (device_left.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisTouch, out joystickTouch) && joystickTouch) {
                rayInteractor.enabled = true;
            } else if(device_left.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisTouch, out joystickTouch) && !joystickTouch) {
                rayInteractor.enabled = false;
            }
        }
        catch
        {
        }
    }
}
