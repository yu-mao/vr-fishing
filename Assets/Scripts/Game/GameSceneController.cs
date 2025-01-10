using System;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    private GameManager _gameManager;
    private IInputProvider _inputProvider;
    private IControllerInput _leftController;
    private IControllerInput _rightController;

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        _inputProvider = gameManager.inputProvider;
        _leftController = _inputProvider.GetLeftController();
        _rightController = _inputProvider.GetRightController();
    }

    private void Start()
    {
        if (_gameManager == null)
        {
            Initialize(GameManager.BootstrapFromEditor());
        }
    }
}
