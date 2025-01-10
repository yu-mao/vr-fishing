using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public IInputProvider inputProvider { get; private set; }

    [SerializeField] private VRInputManager _vrInputManagerPrefab;
    [SerializeField] private KeyboardMouseInputManager _keyboardMouseInputManagerPrefab;
    [SerializeField] private bool _useKeyboardMouse = false;
    
    private bool _inTransition = false;

    public static GameManager BootstrapFromEditor()
    {
#if UNITY_EDITOR
        var gameManagerPrefab = Resources.Load<GameManager>("GameManager");
        var gameManager = Instantiate(gameManagerPrefab);
        return gameManager;
#else
        throw new NotImplementedException();
#endif
    }

    public Coroutine GoToMenuScene()
    {
        throw new NotImplementedException();
    }

    public Coroutine GoToGameScene()
    {
        return StartCoroutine(LoadScene("Game", () =>
        {
            var sceneController = GameObject.FindAnyObjectByType<GameSceneController>();
            sceneController.Initialize(this);
        }));
    }

    private IEnumerator LoadScene(string sceneName, Action sceneLoadedCallback)
    {
        if (_inTransition) yield break; // exit
        
        _inTransition = true;
        // yield return loadingScreen.Show(); 
        
        yield return SceneManager.LoadSceneAsync(sceneName);
        sceneLoadedCallback?.Invoke();

        // yield return loadingScreen.Hide(); 
        _inTransition = false;
    }
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
#if !UNITY_EDITOR
        _useKeyboardMouse = false;
#endif
        if (_useKeyboardMouse)
        {
            inputProvider = Instantiate(_keyboardMouseInputManagerPrefab, transform);
        }
        else
        {
            inputProvider = Instantiate(_vrInputManagerPrefab, transform);
        }

        inputProvider.TryInitialize();
    }
}
