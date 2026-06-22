using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int _totalCoins;
    private int _collectedCoins;

    public bool IsAllCollected { get; private set; }

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

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();

        if (coin != null)
        {
            coin.gameObject.SetActive(false);
            RegisterPickup();
        }
    }

    private void RegisterPickup() => _collectedCoins++;
}
