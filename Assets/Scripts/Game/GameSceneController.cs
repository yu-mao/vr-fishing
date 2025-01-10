using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    private GameManager _gameManager;

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        
        // TODO: initialize input provider etc
    }
}
