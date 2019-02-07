using UnityEngine;

public class ActionJumpLogic : MonoBehaviour 
{
    // Declare variables.
    private Rigidbody2D _playerRigidbody2D;
    private bool _isJumping;
    private float _jumpTimeCounter;
    private float _jumpTime;
    
    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get the scripts and components.
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    /// <summary>
    /// Calling by start.
    /// </summary>
    private void Start()
    {
        // Initialize variables.
        JumpForce = 5.0f;
        _jumpTime = 0.35f;
        IsJumpButtonClicked = false;
    }

    /// <summary>
    /// Calling per frame.
    /// </summary>
    private void Update()
    {
        // Initialize variables for jumping.
        if (IsGrounded && IsJumpButtonClicked)
        {
            _isJumping = true;
            _jumpTimeCounter = _jumpTime;
            _playerRigidbody2D.velocity = Vector2.up * JumpForce;
        }
        
        // Begin jump.
        if (IsJumpButtonClicked && _isJumping)
        {
            if (_jumpTimeCounter > 0)
            {
                _playerRigidbody2D.velocity = new Vector2(_playerRigidbody2D.velocity.x, JumpForce);
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
                _isJumping = false;
        }
        
        // End jump.
        if (!IsJumpButtonClicked)
            _isJumping = false;
    }

    /// <summary>
    /// Calling by enter collision.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground"))
            IsGrounded = true;
    }

    /// <summary>
    /// Calling by exited collision.
    /// </summary>
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground"))
            IsGrounded = false;
    }
    
    // Auto-properties.
    public float JumpForce { private get; set; }
    public bool IsJumpButtonClicked { private get; set; }
    public bool IsGrounded { private get; set; }
}