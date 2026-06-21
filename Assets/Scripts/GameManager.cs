using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private CollectibleManager _collectibleManager;

    private bool _isGameOver;

    private void Update()
    {
        if (_isGameOver )
            return;

        if (_collectibleManager.IsAllCollected)
        {
            _timer.StopTime();
            Win();
        }
        else if(_timer.IsTimeOver)
            Lose();
    }

    private void Win()
    {
        Debug.Log("Вы победили!");
        _isGameOver = true;
    }

    private void Lose()
    {
        Debug.Log("Вы проиграли!");
        _isGameOver = true;
    }
}
