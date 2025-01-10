using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardMouseInputManager : MonoBehaviour, IInputProvider
{
    [SerializeField] private KeyboardMouseControllerInput _leftController;
    [SerializeField] private KeyboardMouseControllerInput _rightController;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _rigTransform;
    [SerializeField] private float sensitivity;

    private float yaw;
    private float pitch;

    public bool TryInitialize()
    {
        return true;
    }
    
    public Transform GetHeadTransform()
    {
        return _cameraTransform;
    }

    public Transform GetRigTransform()
    {
        return _rigTransform;
    }

    public IControllerInput GetLeftController()
    {
        return _leftController;
    }

    public IControllerInput GetRightController()
    {
        return _rightController;
    }

    private void Update()
    {
        // control camera transform's yaw and pitch by mouse middle button
        if (Mouse.current.middleButton.isPressed)
        {
            var delta = Mouse.current.delta.ReadValue();
            pitch = pitch - delta.y * sensitivity;
            yaw = yaw + delta.x * sensitivity;
            _cameraTransform.eulerAngles = new Vector3(pitch, yaw, 0f);

            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

        var direction = Vector3.zero;
        direction += Keyboard.current.wKey.isPressed ? _cameraTransform.forward : Vector3.zero;
        direction -= Keyboard.current.sKey.isPressed ? _cameraTransform.forward : Vector3.zero;
        direction += Keyboard.current.dKey.isPressed ? _cameraTransform.right : Vector3.zero;
        direction -= Keyboard.current.aKey.isPressed ? _cameraTransform.right : Vector3.zero;
        direction.y = 0;

        if (direction.sqrMagnitude > float.Epsilon)
        {
            direction.Normalize();
            _cameraTransform.position += direction * Time.deltaTime;
        }
    }
}
