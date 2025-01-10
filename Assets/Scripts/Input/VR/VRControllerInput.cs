using UnityEngine;

public class VRControllerInput : MonoBehaviour, IControllerInput
{
    [SerializeField] private OVRInput.Controller _controllerType;
    
    public Vector2 Joystick => OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, _controllerType);

    public Transform GetTransform()
    {
        return transform;
    }

    public bool IsButtonPressed(ControllerButtonId buttonId)
    {
        return buttonId switch
        {
            ControllerButtonId.One => OVRInput.Get(OVRInput.Button.One, _controllerType),
            ControllerButtonId.Two => OVRInput.Get(OVRInput.Button.Two, _controllerType),
            _ => false
        };
    }

    public bool IsTriggerPressed()
    {
        return OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, _controllerType);
    }
}
