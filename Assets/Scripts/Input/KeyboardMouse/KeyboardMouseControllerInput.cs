using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class KeyboardMouseControllerInput : MonoBehaviour, IControllerInput
{
    [SerializeField] private bool _isLeftController = false;
    [SerializeField] private KeyControl _buttonA; // ? KeyControl
    [SerializeField] private InputAction _buttonB; // ? InputAction

    public Vector2 Joystick { get; private set; }

    public Transform GetTransform()
    {
        return transform;
    }

    public bool IsTriggerPressed()
    {
        if (_isLeftController)
        {
            return Mouse.current.leftButton.isPressed;
        }
        else
        {
            return Mouse.current.rightButton.isPressed;
        }
    }

    public bool IsButtonPressed(ControllerButtonId buttonId)
    {
        return buttonId switch
        {
            ControllerButtonId.One => _isLeftController
                ? Keyboard.current.digit1Key.isPressed
                : Keyboard.current.digit3Key.isPressed,
            ControllerButtonId.Two => _isLeftController
                ? Keyboard.current.digit2Key.isPressed
                : Keyboard.current.digit4Key.isPressed,
            _ => false
        };
    }

    private void Update()
    {
        var joystick = Vector2.zero;
        var kb = Keyboard.current;

        if (_isLeftController)
        {
            joystick.x += kb.lKey.value;
            joystick.x -= kb.jKey.value;
            joystick.y += kb.iKey.value;
            joystick.y -= kb.kKey.value;
        }
        else
        {
            joystick.x += kb.rightArrowKey.value;
            joystick.x -= kb.leftArrowKey.value;
            joystick.y += kb.upArrowKey.value;
            joystick.y -= kb.downArrowKey.value;
        }
        
        Joystick = joystick.normalized;
    }
}
