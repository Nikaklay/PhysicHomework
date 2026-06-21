using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _speedRotation;
    [SerializeField] private CollectibleManager _collectibleManager;

    private void Update()
    {
        transform.Rotate(Vector3.up, _speedRotation * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();

        if (ball != null)
        {
            gameObject.SetActive(false);
            _collectibleManager.RegisterPickup();
        }
    }
}
