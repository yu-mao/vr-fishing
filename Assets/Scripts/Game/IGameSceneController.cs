using System;

public interface IGameSceneController
{
    // spawn a catchable in a random transform
    void SpawnACatchable();

    // spawn catchables in a random time series
    void SpawnCatchables();

    // Update score when player has caught a catchable
    void UpdateScore();
    
    // manage timer updates
    void CheckTimer();
    
    // transit to game over once time runs up
    void EndGame();
}
