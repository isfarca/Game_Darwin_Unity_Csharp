using UnityEngine;

public class Control : MonoBehaviour 
{
    // Declare variables.
    [SerializeField] private GameObject[] _controlsGameObject;
    [SerializeField] private GameObject _actionGameObject;
    [SerializeField] private MovementSelection _movementSelectionScript;
    
    /// <summary>
    /// Calling per frame bundle.
    /// </summary>
    private void FixedUpdate()
    {
        // By runtime platform 'Android' enable display controls, by another runtime platforms enable keyboard/controller.
        if (Application.platform != RuntimePlatform.Android)
        {
            _controlsGameObject[0].SetActive(false);
            _controlsGameObject[1].SetActive(false);
            _controlsGameObject[2].SetActive(false);
            _controlsGameObject[3].SetActive(true); // Activate keyboard controller movement.
            
            _actionGameObject.SetActive(false);
        }
        else if (!_movementSelectionScript.IsWoked)
            return;
        
        // Disable movement selection canvas and this game object.
        _movementSelectionScript.gameObject.SetActive(false);
    }
}