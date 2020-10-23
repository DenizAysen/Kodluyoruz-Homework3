using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
  
    private GameState _gameState;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        DontDestroyOnLoad(this);

    }

    public static GameManager Instance()
    {
        return _instance;
    }

    private void Start()
    {
        PrepareGame();
    }

    private void PrepareGame()
    {
        _gameState = new GameState();
        _gameState.totalCheckPoint = 5;
       
    }

    public void ChangeCheckPoint(int id)
    {
        _gameState.currentCheckPoint = id + 1;
        if(_gameState.currentCheckPoint == _gameState.totalCheckPoint)
        {
            LoadWinScene();
        }
    }

    private void LoadWinScene()
    {
        SceneManager.LoadScene(2);
    }
}
