using UnityEngine;
using UnityEngine.EventSystems;

public class MutationButton : MonoBehaviour, IPointerDownHandler
{
    // Declare variables.
    [SerializeField] private MutationHandler.MutationType _mutationType;
    private Mutation _mutationScript;

    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get the functions.
        _mutationScript = GameObject.FindGameObjectWithTag("Mutation").GetComponent<Mutation>();
    }
    
    /// <summary>
    /// Calling per time step.
    /// </summary>
    private void FixedUpdate()
    {
        // When the platform android, then return this update function.
        if (Application.platform == RuntimePlatform.Android)
            return;
        
        // Call the function for select the mutation with pc or joystick buttons.
        if (Input.GetButtonDown("Mutation1"))
            SelectMutation(MutationHandler.ThreeMutations[0]);
        else if (Input.GetButtonDown("Mutation2"))
            SelectMutation(MutationHandler.ThreeMutations[1]);
        else if (Input.GetButtonDown("Mutation3"))
            SelectMutation(MutationHandler.ThreeMutations[2]);
    }

    // Calling by clicking or touching.
    public void OnPointerDown(PointerEventData eventData) 
    {
        SelectMutation(_mutationType);
    }

    /// <summary>
    /// Select the mutation.
    /// </summary>
    /// <param name="currentMutationType">Type of the current mutation icon.</param>
    private void SelectMutation(MutationHandler.MutationType currentMutationType)
    {
        switch (currentMutationType)
        {
            case MutationHandler.MutationType.Elephant:
                _mutationScript.SelectElephant();
                break;
            case MutationHandler.MutationType.Fish:
                _mutationScript.SelectFish();
                break;
            case MutationHandler.MutationType.Hawk:
                _mutationScript.SelectHawk();
                break;
            case MutationHandler.MutationType.Rhino:
                _mutationScript.SelectRhino();
                break;
            case MutationHandler.MutationType.Turtle:
                _mutationScript.SelectTurtle();
                break;
            default:
                return;
        }
    }
}