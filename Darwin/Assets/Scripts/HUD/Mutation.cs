using UnityEngine;
using UnityEngine.UI;

public class Mutation : MonoBehaviour 
{
    // Declare variables.
    private MutationHandler _mutationHandlerScript;
    private Image _elephant, _fish, _hawk, _rhino, _turtle;
    private Transformation _transformationScript;

    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get the mutation handler script.
        _mutationHandlerScript = GameObject.FindGameObjectWithTag("MutationHandler").GetComponent<MutationHandler>();
        
        // Get the images.
        _elephant = transform.GetChild(0).GetComponent<Image>();
        _fish = transform.GetChild(1).GetComponent<Image>();
        _hawk = transform.GetChild(2).GetComponent<Image>();
        _rhino = transform.GetChild(3).GetComponent<Image>();
        _turtle = transform.GetChild(4).GetComponent<Image>();
        
        // Get the transformation script.
        _transformationScript = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0)
            .GetComponent<Transformation>();
    }

    /// <summary>
    /// Calling by start.
    /// </summary>
    private void Start()
    {
        // Set default values.
        _mutationHandlerScript.IsNormal = true;
        
        _mutationHandlerScript.IsElephant = false;
        _mutationHandlerScript.IsFish = false;
        _mutationHandlerScript.IsHawk = false;
        _mutationHandlerScript.IsRhino = false;
        _mutationHandlerScript.IsTurtle = false;

        MutationHandler.ElephantCounter = MutationHandler.FishCounter = MutationHandler.HawkCounter =
            MutationHandler.RhinoCounter = MutationHandler.TurtleCounter = 0;

        // Add mutation icon position by platform.
        if (Application.platform != RuntimePlatform.Android)
        {
            transform.GetChild(5).gameObject.SetActive(true);
            transform.GetChild(6).gameObject.SetActive(true);
            transform.GetChild(7).gameObject.SetActive(true);
            transform.GetChild(8).gameObject.SetActive(true);
            
            SetMutationIcons(100.0f, -125.0f);
        }
        else
            SetMutationIcons(269.0f, 0.0f);
    }

    /// <summary>
    /// Set mutation icons and activate this.
    /// </summary>
    private void SetMutationIcons(float xPosition, float yPosition)
    {
        foreach (MutationHandler.MutationType currentMutation in MutationHandler.ThreeMutations)
        {
            if ((currentMutation & MutationHandler.MutationType.Elephant) != 0)
            {
                transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition =
                    new Vector3(xPosition, yPosition, 0.0f);
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if ((currentMutation & MutationHandler.MutationType.Fish) != 0)
            {
                transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition =
                    new Vector3(xPosition, yPosition, 0.0f);
                transform.GetChild(1).gameObject.SetActive(true);
            }
            else if ((currentMutation & MutationHandler.MutationType.Hawk) != 0)
            {
                transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition =
                    new Vector3(xPosition, yPosition, 0.0f);
                transform.GetChild(2).gameObject.SetActive(true);
            }
            else if ((currentMutation & MutationHandler.MutationType.Rhino) != 0)
            {
                transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition =
                    new Vector3(xPosition, yPosition, 0.0f);
                transform.GetChild(3).gameObject.SetActive(true);
            }
            else if ((currentMutation & MutationHandler.MutationType.Turtle) != 0)
            {
                transform.GetChild(4).GetComponent<RectTransform>().anchoredPosition =
                    new Vector3(xPosition, yPosition, 0.0f);
                transform.GetChild(4).gameObject.SetActive(true);
            }

            // Add offset.
            xPosition = Application.platform != RuntimePlatform.Android ? xPosition + 50.0f : xPosition;
            yPosition = Application.platform != RuntimePlatform.Android ? yPosition : yPosition + 50.0f;
        }
    }

    /// <summary>
    /// De select all images.
    /// </summary>
    private void DeSelectAll()
    {
        // Switch selected / deselected images.
        _elephant.sprite = _mutationHandlerScript.DeSelected[0];
        _fish.sprite = _mutationHandlerScript.DeSelected[1];
        _hawk.sprite = _mutationHandlerScript.DeSelected[2];
        _rhino.sprite = _mutationHandlerScript.DeSelected[3];
        _turtle.sprite = _mutationHandlerScript.DeSelected[4];
    }

    /// <summary>
    /// Select elephant image.
    /// </summary>
    public void SelectElephant()
    {
        // Set default transformation by second click this mutation button.
        MutationHandler.FishCounter = MutationHandler.HawkCounter =
            MutationHandler.RhinoCounter = MutationHandler.TurtleCounter = 0;
        MutationHandler.ElephantCounter++;
        if (MutationHandler.ElephantCounter <= 1) // Switch to elephant.
        {
            // Start transformation process.
            _transformationScript.Change("Elephant");

            // Set boolean.
            _mutationHandlerScript.IsNormal = false;
            _mutationHandlerScript.IsElephant = true;
            _mutationHandlerScript.IsFish = false;
            _mutationHandlerScript.IsHawk = false;
            _mutationHandlerScript.IsRhino = false;
            _mutationHandlerScript.IsTurtle = false;

            // Switch selected / deselected images.
            _elephant.sprite = _mutationHandlerScript.Selected[0];
            _fish.sprite = _mutationHandlerScript.DeSelected[1];
            _hawk.sprite = _mutationHandlerScript.DeSelected[2];
            _rhino.sprite = _mutationHandlerScript.DeSelected[3];
            _turtle.sprite = _mutationHandlerScript.DeSelected[4];
        }
        else if (MutationHandler.ElephantCounter > 1) // Switch to normal.
        {
            // Start transformation process.
            _transformationScript.Change("Normal");

            // Set default values.
            _mutationHandlerScript.IsNormal = true;
            _mutationHandlerScript.IsElephant = false;
            MutationHandler.ElephantCounter = 0;

            // Set the normal transformation.
            DeSelectAll();
        }
    }

    /// <summary>
    /// Select fish image.
    /// </summary>
    public void SelectFish()
    {
        // Set default transformation by second click this mutation button.
        MutationHandler.ElephantCounter = MutationHandler.HawkCounter =
            MutationHandler.RhinoCounter = MutationHandler.TurtleCounter = 0;
        MutationHandler.FishCounter++;
        if (MutationHandler.FishCounter <= 1) // Switch to fish.
        {
            // Start transformation process.
            _transformationScript.Change("Fish");

            // Set boolean.
            _mutationHandlerScript.IsNormal = false;
            _mutationHandlerScript.IsElephant = false;
            _mutationHandlerScript.IsFish = true;
            _mutationHandlerScript.IsHawk = false;
            _mutationHandlerScript.IsRhino = false;
            _mutationHandlerScript.IsTurtle = false;

            // Switch selected / deselected images.
            _elephant.sprite = _mutationHandlerScript.DeSelected[0];
            _fish.sprite = _mutationHandlerScript.Selected[1];
            _hawk.sprite = _mutationHandlerScript.DeSelected[2];
            _rhino.sprite = _mutationHandlerScript.DeSelected[3];
            _turtle.sprite = _mutationHandlerScript.DeSelected[4];
        }
        else if (MutationHandler.FishCounter > 1) // Switch to normal.
        {
            // Start transformation process.
            _transformationScript.Change("Normal");

            // Set default values.
            _mutationHandlerScript.IsNormal = true;
            _mutationHandlerScript.IsFish = false;
            MutationHandler.FishCounter = 0;

            // Set the normal transformation.
            DeSelectAll();
        }
    }

    /// <summary>
    /// Select hawk image.
    /// </summary>
    public void SelectHawk()
    {
        // Set default transformation by second click this mutation button.
        MutationHandler.ElephantCounter = MutationHandler.FishCounter =
            MutationHandler.RhinoCounter = MutationHandler.TurtleCounter = 0;
        MutationHandler.HawkCounter++;
        if (MutationHandler.HawkCounter <= 1) // Switch to hawk.
        {
            // Start transformation process.
            _transformationScript.Change("Hawk");

            // Set boolean.
            _mutationHandlerScript.IsNormal = false;
            _mutationHandlerScript.IsElephant = false;
            _mutationHandlerScript.IsFish = false;
            _mutationHandlerScript.IsHawk = true;
            _mutationHandlerScript.IsRhino = false;
            _mutationHandlerScript.IsTurtle = false;

            // Switch selected / deselected images.
            _elephant.sprite = _mutationHandlerScript.DeSelected[0];
            _fish.sprite = _mutationHandlerScript.DeSelected[1];
            _hawk.sprite = _mutationHandlerScript.Selected[2];
            _rhino.sprite = _mutationHandlerScript.DeSelected[3];
            _turtle.sprite = _mutationHandlerScript.DeSelected[4];
        }
        else if (MutationHandler.HawkCounter > 1) // Switch to normal.
        {
            // Start transformation process.
            _transformationScript.Change("Normal");

            // Set default values.
            _mutationHandlerScript.IsNormal = true;
            _mutationHandlerScript.IsHawk = false;
            MutationHandler.HawkCounter = 0;

            // Set the normal transformation.
            DeSelectAll();
        }
    }

    /// <summary>
    /// Select rhino image.
    /// </summary>
    public void SelectRhino()
    {
        // Set default transformation by second click this mutation button.
        MutationHandler.ElephantCounter = MutationHandler.FishCounter =
            MutationHandler.HawkCounter = MutationHandler.TurtleCounter = 0;
        MutationHandler.RhinoCounter++;
        if (MutationHandler.RhinoCounter <= 1) // Switch to hawk.
        {
            // Start transformation process.
            _transformationScript.Change("Rhino");

            // Set boolean.
            _mutationHandlerScript.IsNormal = false;
            _mutationHandlerScript.IsElephant = false;
            _mutationHandlerScript.IsFish = false;
            _mutationHandlerScript.IsHawk = false;
            _mutationHandlerScript.IsRhino = true;
            _mutationHandlerScript.IsTurtle = false;

            // Switch selected / deselected images.
            _elephant.sprite = _mutationHandlerScript.DeSelected[0];
            _fish.sprite = _mutationHandlerScript.DeSelected[1];
            _hawk.sprite = _mutationHandlerScript.DeSelected[2];
            _rhino.sprite = _mutationHandlerScript.Selected[3];
            _turtle.sprite = _mutationHandlerScript.DeSelected[4];
        }
        else if (MutationHandler.RhinoCounter > 1) // Switch to normal.
        {
            // Start transformation process.
            _transformationScript.Change("Normal");

            // Set default values.
            _mutationHandlerScript.IsNormal = true;
            _mutationHandlerScript.IsRhino = false;
            MutationHandler.RhinoCounter = 0;

            // Set the normal transformation.
            DeSelectAll();
        }
    }

    /// <summary>
    /// Select turtle image.
    /// </summary>
    public void SelectTurtle()
    {
        // Set default transformation by second click this mutation button.
        MutationHandler.ElephantCounter = MutationHandler.FishCounter =
            MutationHandler.HawkCounter = MutationHandler.RhinoCounter = 0;
        MutationHandler.TurtleCounter++;
        if (MutationHandler.TurtleCounter <= 1) // Switch to hawk.
        {
            // Start transformation process.
            _transformationScript.Change("Turtle");

            // Set boolean.
            _mutationHandlerScript.IsNormal = false;
            _mutationHandlerScript.IsElephant = false;
            _mutationHandlerScript.IsFish = false;
            _mutationHandlerScript.IsHawk = false;
            _mutationHandlerScript.IsRhino = false;
            _mutationHandlerScript.IsTurtle = true;

            // Switch selected / deselected images.
            _elephant.sprite = _mutationHandlerScript.DeSelected[0];
            _fish.sprite = _mutationHandlerScript.DeSelected[1];
            _hawk.sprite = _mutationHandlerScript.DeSelected[2];
            _rhino.sprite = _mutationHandlerScript.DeSelected[3];
            _turtle.sprite = _mutationHandlerScript.Selected[4];
        }
        else if (MutationHandler.TurtleCounter > 1) // Switch to normal.
        {
            // Start transformation process.
            _transformationScript.Change("Normal");

            // Set default values.
            _mutationHandlerScript.IsNormal = true;
            _mutationHandlerScript.IsTurtle = false;
            MutationHandler.TurtleCounter = 0;

            // Set the normal transformation.
            DeSelectAll();
        }
    }
}