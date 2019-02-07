using UnityEngine;
using UnityEngine.EventSystems;

public class ActionButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Declare variables.
    [SerializeField] private Action _action;
    private ActionJumpLogic _jumpLogicScript;
    
    /// <summary>
    /// Human actions that the player can perform.
    /// </summary>
    private enum Action
    {
        None,
        Jump
    }
    
    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get scripts and components.
        _jumpLogicScript = FindObjectOfType<ActionJumpLogic>();
    }
    
    /// <summary>
    /// Calling per frame.
    /// </summary>
    private void Update()
    {
        // Is keyboard / controller jump button clicked or released?
        if (Input.GetButtonDown("Jump"))
            _jumpLogicScript.IsJumpButtonClicked = true;
        else if (Input.GetButtonUp("Jump"))
            _jumpLogicScript.IsJumpButtonClicked = false;
    }

    // Calling by clicking or touching.
    public void OnPointerDown(PointerEventData eventData) 
    {
        // Is jump mobile button clicked?
        switch (_action)
        {
            case Action.None:
                return;
            case Action.Jump:
                _jumpLogicScript.IsJumpButtonClicked = true;
                break;
            default:
                return;
        }
    }
    
    // Calling after by clicking or touching.
    public void OnPointerUp(PointerEventData eventData)
    {
        // Is jump mobile button released?
        switch (_action)
        {
            case Action.None:
                return;
            case Action.Jump:
                _jumpLogicScript.IsJumpButtonClicked = false;
                break;
            default:
                return;
        }
    }
}