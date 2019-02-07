using UnityEngine;

public class Player3DExample : MonoBehaviour 
{
    public float MoveSpeed = 8f;
    public Joystick Joystick;

	private void Update() 
	{
		// Declare variables.
        Vector3 moveVector = (Vector3.right * Joystick.Horizontal + Vector3.forward * Joystick.Vertical);

		if (moveVector == Vector3.zero)
			return;
		
        transform.rotation = Quaternion.LookRotation(moveVector);
        transform.Translate(moveVector * MoveSpeed * Time.deltaTime, Space.World);
	}
}