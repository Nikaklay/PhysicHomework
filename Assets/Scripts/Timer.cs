using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] int _playTime;

    private float _remainingTime;
    private bool _isTimeStopped;

    public bool IsTimeOver => _isTimeStopped;

    public void StopTime() => _isTimeStopped = true;

    private void Awake()
    {
        _remainingTime = _playTime;
    }

    private void FixedUpdate()
    {
        if (_isTimeStopped == false)
        {
            if (_remainingTime == 0)
            {
                Debug.Log("Время закончилось");
                _isTimeStopped = true;

                return;
            }

            if (Time.timeSinceLevelLoad % 1 == 0)
            {
                _remainingTime = _playTime - Time.timeSinceLevelLoad;
                Debug.Log($"Осталось {_remainingTime} сек");
            }
        }
    }

}
