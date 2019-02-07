using UnityEngine;
using UnityEngine.EventSystems;

public class ControlPadMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Declare variables.
    [SerializeField] private Direction _direction;
    private MovementLogic _movementLogicScript;
    
    /// <summary>
    /// Movement directions for player.
    /// </summary>
    private enum Direction
    {
        None,
        Up,
        Right,
        Down,
        Left
    }
    
    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get scripts and components.
        _movementLogicScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementLogic>();
    }

    // Calling by clicking or touching.
    public void OnPointerDown(PointerEventData eventData) 
    {
        switch (_direction)
        {
            case Direction.None:
                return;
            case Direction.Up:
                Vertical = 1.0f;
                break;
            case Direction.Right:
                _movementLogicScript.Horizontal = 1.0f;
                break;
            case Direction.Down:
                Vertical = -1.0f;
                break;
            case Direction.Left:
                _movementLogicScript.Horizontal = -1.0f;
                break;
            default:
                return;
        }
    }
    
    // Calling after by clicking or touching.
    public void OnPointerUp(PointerEventData eventData)
    {
        Vertical = 0.0f;
        _movementLogicScript.Horizontal = 0.0f;
    }
    
    // Auto-properties.
    public float Vertical { get; private set; }
}