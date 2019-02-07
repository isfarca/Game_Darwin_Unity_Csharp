using UnityEngine;

public class VirtualStickMovement : MonoBehaviour 
{
    // Declare variables.
    private Joystick _joystickScript;
    private MovementLogic _movementLogicScript;
    
    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get scripts and components.
        _joystickScript = GetComponent<Joystick>();
        _movementLogicScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementLogic>();
    }
    
    /// <summary>
    /// Calling per frame.
    /// </summary>
    private void Update()
    {
        _movementLogicScript.Horizontal = _joystickScript.Horizontal;
        Vertical = _joystickScript.Vertical;
    }
    
    // Auto-properties.
    public float Vertical { get; private set; }
}