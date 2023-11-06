using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameState gameState;
    public Difficulty difficulty;
    public int score = 0;
    int scoreMultiplier = 1;

    public enum GameState { Title, Playing, Paused, GameOver }

    public enum Difficulty { Easy, Medium, Hard }

    void Start()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                scoreMultiplier = 1;
                break;

            case Difficulty.Medium:
                scoreMultiplier = 2;
                break;

            case Difficulty.Hard:
                scoreMultiplier = 3;
                break;
        }
    }

    public void AddScore(int _points)
    {
        score += _points * scoreMultiplier;
        _UI.UpdateScore(score); 
    }

}
