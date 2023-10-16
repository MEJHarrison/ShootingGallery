using System;
using System.Security.Cryptography;
using UnityEngine;

public class ShootingGalleryService : MonoBehaviour
{
    [SerializeField] private GameObject shootingGalleryMenu = null;
    [SerializeField] private int shotsAllowed = 10;

    public event Action<int> ScoreUpdated;
    //public event Action<int, int> AmmoUpdated;

    private int _score;
    private int _shotsTaken;

    public bool GameOver => _gameOver;
    private bool _gameOver = true;

    public void AddToScore(int scoreToAdd)
    {
        _score += scoreToAdd;

        ScoreUpdated?.Invoke(_score);
    }

    public void TakeShot()
    {
        _shotsTaken++;

        //AmmoUpdated?.Invoke(shotsAllowed, _shotsTaken);

        if (!GameOver && _shotsTaken >= shotsAllowed)
        {
            _gameOver = true;

            shootingGalleryMenu?.SetActive(true);
        }
    }

    [ContextMenu("Start Game")]
    public void StartGame()
    {
        if (_gameOver)
        {
            _gameOver = false;

            shootingGalleryMenu?.SetActive(false);

            ResetGame();
        }
    }

    [ContextMenu("End Game")]
    private void EndGame()
    {
        _score = 100;
        ScoreUpdated?.Invoke(_score);

        _shotsTaken = shotsAllowed;

        TakeShot();
    }

    [ContextMenu("Reset Game")]
    public void ResetGame()
    {
        _score = 0;
        _shotsTaken = 0;

        ScoreUpdated?.Invoke(_score);
        //AmmoUpdated?.Invoke(shotsAllowed, _shotsTaken);
    }
}
