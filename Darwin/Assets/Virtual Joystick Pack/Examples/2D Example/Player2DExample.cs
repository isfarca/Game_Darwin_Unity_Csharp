using UnityEngine;

public class Player2DExample : MonoBehaviour 
{
    public float MoveSpeed = 8f;
    public Joystick Joystick;

    private void Update()
    {
        Vector3 moveVector = (Vector3.right * Joystick.Horizontal + Vector3.up * Joystick.Vertical);

        if (moveVector == Vector3.zero)
            return;
        
        transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        transform.Translate(moveVector * MoveSpeed * Time.deltaTime, Space.World);
    }
}