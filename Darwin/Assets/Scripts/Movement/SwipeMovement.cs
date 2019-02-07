using UnityEngine;

public class SwipeMovement : MonoBehaviour 
{
    // Declare variables.
    private bool _isDraging;
    private Vector2 _startTouch, _swipeDelta;
    private ActionJumpLogic _actionJumpLogicScript;
    private MovementLogic _movementLogicScript;
    private float _vertical;
    private float _horizontal;
    
    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get scripts and components.
        _actionJumpLogicScript = GameObject.FindGameObjectWithTag("Player").GetComponent<ActionJumpLogic>();
        _movementLogicScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementLogic>();
    }

    /// <summary>
    /// Calling by start.
    /// </summary>
    private void Start()
    {
        // Initialize variables.
        _isDraging = false;
        _vertical = 0.0f;
        _horizontal = 0.0f;
    }

    /// <summary>
    /// Calling per frame.
    /// </summary>
    private void Update()
    {                
        // Standalone input.
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse tap!");
            _isDraging = true;
            _startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _actionJumpLogicScript.IsJumpButtonClicked = false;
            _isDraging = false;
            Reset();
        }

        // Mobile input.
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Debug.Log("Touch tap!");
                _isDraging = true;
                _startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                _actionJumpLogicScript.IsJumpButtonClicked = false;
                _isDraging = false;
                Reset();
            }
        }
        
        // Calculate the distance.
        _swipeDelta = Vector2.zero;

        if (_isDraging && Input.GetMouseButton(0))
            _swipeDelta = (Vector2)Input.mousePosition - _startTouch;
        else if (_isDraging && Input.touches.Length > 0)
            _swipeDelta = Input.touches[0].position - _startTouch;
        
        // Did we cross the dead zone?
        if (_swipeDelta.magnitude <= 125)
            return;
        
        // Which direction?
        float x = _swipeDelta.x, y = _swipeDelta.y;
        
        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            _vertical = 0.0f;
            
            // Left or Right.
            if (x < 0)
                _horizontal = -1.0f;
            else
                _horizontal = 1.0f;
        }
        else
        {
            // Down or Up
            if (y < 0)
            {
                _vertical = -1.0f;
                _horizontal = 0.0f;
            }
            else
            {
                _vertical = 1.0f;
                _actionJumpLogicScript.IsJumpButtonClicked = true;
            }
        }

        Vertical = _vertical;
        _movementLogicScript.Horizontal = _horizontal;
        
        Reset();
    }
    
    /// <summary>
    /// Calling by reset.
    /// </summary>
    private void Reset()
    {
        // Set default values.
        _isDraging = false;
        _startTouch = _swipeDelta = Vector2.zero;
    }
    
    // Auto-properties.
    public float Vertical { get; private set; }
}