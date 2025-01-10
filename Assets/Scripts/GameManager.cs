using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private bool _inTransition = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
}
