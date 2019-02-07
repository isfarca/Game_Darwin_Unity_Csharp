using UnityEngine;

public class MovementLogic : MonoBehaviour 
{
    // Declare variables.
    private ActionJumpLogic _actionJumpLogicScript;
    private Rigidbody2D _playerRigidbody2D;
    
    /// <summary>
    /// Calling by awake.
    /// </summary>
    private void Awake()
    {
        // Disable jump script.
        _actionJumpLogicScript = GetComponent<ActionJumpLogic>();
        _actionJumpLogicScript.enabled = false;
        
        // Get the scripts and components.
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    /// <summary>
    /// Calling by start.
    /// </summary>
    private void Start()
    {
        // Enable jump script.
        _actionJumpLogicScript.enabled = true;
        
        // Initialize variables.
        PlayerHorizontalSpeed = 300.0f;
        Horizontal = 0.0f;
    }
    
    /// <summary>
    /// Calling by enable.
    /// </summary>
    private void OnEnable()
    {
        _actionJumpLogicScript.enabled = true;
    }
    
    /// <summary>
    /// Calling by disable.
    /// </summary>
    private void OnDisable()
    {
        _actionJumpLogicScript.enabled = false;
    }

    /// <summary>
    /// Calling per frame.
    /// </summary>
    private void Update()
    {
        // Movement.
        _playerRigidbody2D.velocity =
            new Vector2(Horizontal * PlayerHorizontalSpeed * Time.deltaTime, _playerRigidbody2D.velocity.y);
    }

    // Auto-properties.
    public float PlayerHorizontalSpeed { private get; set; }
    public float Horizontal { private get; set; }
}