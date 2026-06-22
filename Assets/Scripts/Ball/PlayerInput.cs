using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 ReadMovementInput()
    {
            float xMovement = Input.GetAxisRaw("Horizontal");
            float zMovement = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(xMovement, 0, zMovement).normalized;

            return direction;
    }

    public bool ReadJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            return true;
        else
            return false;
    }
}
