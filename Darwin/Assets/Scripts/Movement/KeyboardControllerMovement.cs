using UnityEngine;

public class KeyboardControllerMovement : MonoBehaviour
{
    // Declare variables.
    private MovementLogic _movementLogicScript;
    
    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get scripts and components.
        _movementLogicScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementLogic>();
    }
    
    /// <summary>
    /// Calling per frame.
    /// </summary>
    private void Update()
    {
        _movementLogicScript.Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
    }
    
    // Auto-properties.
    public float Vertical { get; private set; }
}