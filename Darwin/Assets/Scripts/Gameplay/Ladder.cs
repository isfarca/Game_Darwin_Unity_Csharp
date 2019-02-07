using UnityEngine;

public class Ladder : MonoBehaviour 
{
    // Declare variables.
    [SerializeField] private VirtualStickMovement _virtualStick;
    [SerializeField] private ControlPadMovement _controlPadUp;
    [SerializeField] private ControlPadMovement _controlPadDown;
    [SerializeField] private SwipeMovement _swipe;
    [SerializeField] private KeyboardControllerMovement _keyboardController;

    /// <summary>
    /// Calling by stayed trigger.
    /// </summary>
    /// <param name="other">Player.</param>
    private void OnTriggerStay2D(Collider2D other)
    {
        // Climb the ladder.
        if (_virtualStick.Vertical > 0.0f || _controlPadUp.Vertical > 0.0f || _swipe.Vertical > 0.0f || _keyboardController.Vertical > 0.0f)
            other.transform.Translate(Vector3.up * 3.0f * Time.deltaTime);
        else if (_virtualStick.Vertical < 0.0f || _controlPadDown.Vertical < 0.0f || _swipe.Vertical < 0.0f || _keyboardController.Vertical < 0.0f)
            other.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        else
        {
            // Gravity off.
            other.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
    
    /// <summary>
    /// Calling by exited trigger.
    /// </summary>
    /// <param name="other">Player.</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        // Gravity on.
        other.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
    }
}