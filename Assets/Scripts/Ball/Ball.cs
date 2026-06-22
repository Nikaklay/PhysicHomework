using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    [SerializeField] private int _speedForce;
    [SerializeField] private int _maxSpeed;
    [SerializeField] private int _jumpForce;

    private Rigidbody _rigidbody;

    private Vector3 _movementDirection;

    private bool _isJumpKeyPressed;
    private bool _isGrounded;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.sleepThreshold = 0;
    }

    private void Update()
    {
        _movementDirection = _playerInput.ReadMovementInput();

        if (_playerInput.ReadJumpInput())
            _isJumpKeyPressed = true;
    }

    private void FixedUpdate()
    {
        if (_isJumpKeyPressed && _isGrounded)
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

        if (_isGrounded)
            _rigidbody.AddForce(_movementDirection * _speedForce, ForceMode.Force);

        if (IsTooFast())
            LimitSpeed();

        _isGrounded = false;
        _isJumpKeyPressed = false;
    }

    private bool IsTooFast() => _rigidbody.velocity.magnitude > _maxSpeed;

    private void LimitSpeed()
    {
        Vector3 currentVelocity = _rigidbody.velocity;
        float verticalVelocity = currentVelocity.y;
        currentVelocity.y = 0;

        Vector3 limitedVelocity = Vector3.ClampMagnitude(currentVelocity, _maxSpeed);
        limitedVelocity.y = verticalVelocity;

        _rigidbody.velocity = limitedVelocity;
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (var contact in collision.contacts)
        {
            Vector3 touch = contact.normal;

            if (Vector3.Dot(touch, Vector3.up) > 0.5f)
            {
                _isGrounded = true;
                break;
            }
        }
    }
}
