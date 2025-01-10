using System;
using UnityEngine;
using UnityEngine.XR.Management;

public class VRInputManager : MonoBehaviour, IInputProvider
{
    [SerializeField] private Transform _headTransform;
    [SerializeField] private Transform _rigTransform;
    [SerializeField] private VRControllerInput _leftController;
    [SerializeField] private VRControllerInput _rightController;

    public bool TryInitialize()
    {
        var manager = XRGeneralSettings.Instance.Manager;

        //Clean up everything from a previous run. This is only needed in the editor
        //when plugging in the headset. Sometimes the previous systems can remain initialized
        //between runs and this is a safe-guard against this. 
        if (manager.isInitializationComplete)
        {
            manager.DeinitializeLoader();
        }

        //Manually initialize the XR system. We are not using "Init Managers on Start" to be 
        //able to control exactly when we use XR.
        manager.InitializeLoaderSync();

        if (!manager.isInitializationComplete)
        {
            return false;
        }

        //This is the last step in the manual startup process.
        manager.StartSubsystems();
        return true;
    }
    
    public Transform GetRigTransform ()
    {
        return _rigTransform;
    }

    public Transform GetHeadTransform()
    {
        return _headTransform;
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
        OVRInput.Update();
    }

    private void FixedUpdate()
    {
        OVRInput.FixedUpdate();
    }
}
