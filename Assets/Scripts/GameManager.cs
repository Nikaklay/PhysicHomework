using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private CoinCollector _coinCollector;

    private bool _isGameOver;

    private void Update()
    {
        if (_isGameOver)
            return;

        if (_coinCollector.IsAllCollected)
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
