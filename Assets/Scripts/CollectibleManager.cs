using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    private int _totalCoins;
    private int _collectedCoins;

    public bool IsAllCollected { get; private set; }

    public void RegisterPickup() => _collectedCoins++;

    private void Awake()
    {
       Coin[] coins = FindObjectsOfType<Coin>();
       _totalCoins = coins.Length;
    }

    private void Update()
    {
        if (_totalCoins == _collectedCoins)
            IsAllCollected = true;
    }
}
