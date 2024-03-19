using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Ground _ground;
    [SerializeField] private EnemySpawner _enemySpawner;

    private void OnEnable()
    {
        _player.OnPlayerTouchGround += GameOver;
        _player.OnPlayerDie += GameOver;
    }

    private void OnDisable()
    {
        _player.OnPlayerTouchGround -= GameOver;
        _player.OnPlayerDie -= GameOver;
    }

    private void GameOver()
    {
        _ground.StopAnimation();
        _player.enabled = false;
        _enemySpawner.enabled = false;
    }
}