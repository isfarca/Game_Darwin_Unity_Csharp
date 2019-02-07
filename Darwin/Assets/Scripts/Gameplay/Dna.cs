using UnityEngine;
using UnityEngine.EventSystems;

public class Dna : MonoBehaviour, IPointerDownHandler
{
    // Declare variables.
    [SerializeField] private SpecialButton _specialButton;
    private MutationHandler _mutationHandlerScript;
    [SerializeField] private SpecialAbilities _specialAbilitiesScript;
    
    /// <summary>
    /// List of all special buttons.
    /// </summary>
    private enum SpecialButton
    {
        Dna
    }

    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get the scripts and components.
        _mutationHandlerScript = GameObject.FindGameObjectWithTag("MutationHandler").GetComponent<MutationHandler>();
        
        // Set default values.
        IsSpecialButtonClicked = false;
    }

    /// <summary>
    /// Calling per time step.
    /// </summary>
    private void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
            return;

        // ReSharper disable once InvertIf
        if (!IsSpecialButtonClicked && Input.GetButtonDown("SpecialAbility")) 
        {        
            IsSpecialButtonClicked = true;
            SetAbility();
        }
    }

    // Calling by clicking or touching.
    public void OnPointerDown(PointerEventData eventData) 
    {
        // Switch to the special button.
        switch (_specialButton)
        {
            case SpecialButton.Dna:
                SetAbility();
                break;
            default:
                return;
        }
    }

    /// <summary>
    /// Start the current ability.
    /// </summary>
    private void SetAbility()
    {
        // Start ability.
        if (_mutationHandlerScript.IsElephant)
            _specialAbilitiesScript.ElephantAbility();
        else if (_mutationHandlerScript.IsFish)
            _specialAbilitiesScript.FishAbility();
        else if (_mutationHandlerScript.IsHawk)
            _specialAbilitiesScript.HawkAbility();
        else if (_mutationHandlerScript.IsRhino)
            _specialAbilitiesScript.RhinoAbility();
        else if (_mutationHandlerScript.IsTurtle)
            _specialAbilitiesScript.TurtleAbility();
    }
    
    // Auto-property.
    public bool IsSpecialButtonClicked { private get; set; }
}