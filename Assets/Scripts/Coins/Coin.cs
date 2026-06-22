using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _speedRotation;

    private void Update()
    {
        transform.Rotate(Vector3.up, _speedRotation * Time.deltaTime, Space.Self);
    }
}
