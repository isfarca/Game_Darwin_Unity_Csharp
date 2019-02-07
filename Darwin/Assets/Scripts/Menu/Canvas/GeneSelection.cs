using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GeneSelection : MMenu<GeneSelection> 
{
    // Declare variables.
    [SerializeField] private Image[] _images;
    [SerializeField] private Button _continueButton;
    private MutationHandler _mutationHandlerScript;

    /// <inheritdoc cref="MMenu{T}.Awake"/>
    protected override void Awake()
    {
        base.Awake();
        
        // Initialize array instance.
        MutationHandler.ThreeMutations = new MutationHandler.MutationType[3];
        
        // Get the mutation handler script.
        _mutationHandlerScript = GameObject.FindGameObjectWithTag("MutationHandler").GetComponent<MutationHandler>();
    }

    /// <summary>
    /// Calling by start.
    /// </summary>
    private void Start()
    {
        // Initialize variables.
        _continueButton.interactable = false;
        MutationHandler.ElephantCounter = MutationHandler.FishCounter = MutationHandler.HawkCounter =
            MutationHandler.RhinoCounter = MutationHandler.TurtleCounter = 0;
        MutationHandler.ElephantIndex = MutationHandler.FishIndex =
            MutationHandler.HawkIndex = MutationHandler.RhinoIndex = MutationHandler.TurtleIndex = 0;
    }

    /// <summary>
    /// Open this menu.
    /// </summary>
    public static void Show()
    {
        Open();
    }
    
    /// <summary>
    /// Close the game.
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }
    
    /// <summary>
    /// Open the level selection menu.
    /// </summary>
    public void ShowLevelSelection()
    {
        Close();
        LevelSelection.Show();
    }

    /// <summary>
    /// Open the main menu.
    /// </summary>
    public void ShowMainMenu()
    {
        Close();
        MainMenu.Show();
    }
    
    // Mutation icons.
    public void Elephant()
    {
        Selection(ref MutationHandler.ElephantCounter, MutationHandler.MutationType.Elephant,
            ref MutationHandler.ElephantIndex, 0);
        
        ContinueInteract();   
    }
    public void Fish()
    {
        Selection(ref MutationHandler.FishCounter, MutationHandler.MutationType.Fish,
            ref MutationHandler.FishIndex, 1);
        
        ContinueInteract();
    }
    public void Hawk()
    {
        Selection(ref MutationHandler.HawkCounter, MutationHandler.MutationType.Hawk,
            ref MutationHandler.HawkIndex, 2);
        
        ContinueInteract();
    }
    public void Rhino()
    {
        Selection(ref MutationHandler.RhinoCounter, MutationHandler.MutationType.Rhino,
            ref MutationHandler.RhinoIndex, 3);
        
        ContinueInteract();
    }
    public void Turtle()
    {
        Selection(ref MutationHandler.TurtleCounter, MutationHandler.MutationType.Turtle,
            ref MutationHandler.TurtleIndex, 4);
        
        ContinueInteract();
    }

    /// <summary>
    /// Enter the mutation selection for the level.
    /// </summary>
    /// <param name="counter">Mutation specify counter.</param>
    /// <param name="mutation">Current mutation type.</param>
    /// <param name="index">Mutation specify index.</param>
    /// <param name="spriteImageIndex">Index for the respective mutation image and sprite.</param>
    private void Selection(ref int counter, MutationHandler.MutationType mutation, ref int index, int spriteImageIndex)
    {
        if (counter <= 0) // Select the mutation.
        {
            for (int i = 0; i < MutationHandler.ThreeMutations.Length; i++)
            {
                if (MutationHandler.ThreeMutations[i] != 0)
                    continue;
                
                counter++;
                MutationHandler.ThreeMutations[i] = mutation;
                index = i;
                _images[spriteImageIndex].sprite = _mutationHandlerScript.Selected[spriteImageIndex];
                break;
            }
        }
        else if (counter > 0) // Deselect the mutation.
        {
            counter = 0;
            MutationHandler.ThreeMutations[index] = 0;
            _images[spriteImageIndex].sprite = _mutationHandlerScript.Crossed[spriteImageIndex];
        }
    }

    /// <summary>
    /// Enable / Disable the continue button.
    /// </summary>
    private void ContinueInteract()
    {
        // LINQ.
        if (MutationHandler.ThreeMutations.Any(currentMutation => currentMutation == 0))
        {
            _continueButton.interactable = false;
            return;
        }

        _continueButton.interactable = true;
    }

    /// <summary>
    /// Open the loading window.
    /// </summary>
    public void ShowLoad()
    {
        Close();
        Load.Show();
    }
}