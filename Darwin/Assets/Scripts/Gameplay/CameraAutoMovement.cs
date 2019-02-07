using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraAutoMovement : MonoBehaviour 
{
    // Declare variables.
    private GameObject _playerGameObject;
    private CameraShaker _cameraShakerScript;
    private float _cameraSpeedMultiplicator;
    private float _playerLerpValue;
    
    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get the scripts and components.
        _playerGameObject = GameObject.FindGameObjectWithTag("Player");
        _cameraShakerScript = GetComponent<CameraShaker>();
    }

    /// <summary>
    /// Calling by start.
    /// </summary>
    private void Start()
    {
        // Set the camera position for smart phones.
        if (Application.platform == RuntimePlatform.Android)
        {
            transform.position = new Vector3(1.0f, -1.0f, transform.position.z);
            _playerLerpValue = -0.2f;
        }
        else
            _playerLerpValue = 0.9357735f;
    }

    /// <summary>
    /// Called once per frame, after update has finished.
    /// </summary>
    private void LateUpdate()
    {
        // Move the camera horizontal.
        transform.Translate(Vector3.right * _cameraSpeedMultiplicator * Time.deltaTime);
        
        // Shake the camera, when the player stand on the left side.
        if (transform.position.x > _playerGameObject.transform.position.x + 5.0f)
            _cameraShakerScript.ShouldShake = true;
        
        // Game over, when the player out of the screen.
        if (transform.position.x > _playerGameObject.transform.position.x + 7.0f)
            SceneManager.LoadScene(0);
        
        // Push the camera to right, when the player stand on the right side.
        _cameraSpeedMultiplicator = _playerGameObject.transform.position.x > transform.position.x + 5.5f ? 5.5f : 1.0f;
        
        // Smooth follow the camera vertical.
        Vector3 cameraPosition = transform.position;
        
        cameraPosition.y = Mathf.Lerp(cameraPosition.y, _playerGameObject.transform.position.y + _playerLerpValue, Time.deltaTime);
        transform.position = cameraPosition;
    }
}