using UnityEngine;

public class CameraShaker : MonoBehaviour 
{
    // Declare variables.
    private float _power;
    private float _resetDuration;
    private float _duration;
    private float _slowDownAmount;
    private Vector3 _cameraCurrentPosition;
    private Transform _cameraTransform;

    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Declare variables.
        Camera mainCamera = Camera.main;
        
        // Get the scripts and components.
        _cameraTransform = mainCamera != null ? mainCamera.transform : null;
    }
    
    /// <summary>
    /// Calling by start.
    /// </summary>
    private void Start()
    {
        // Initialize variables.
        _power = 0.1f;
        _duration = 1.0f;
        _slowDownAmount = 0.5f;
        
        _resetDuration = _duration;

        ShouldShake = false;
    }
    
    /// <summary>
    /// Calling per frame.
    /// </summary>
    private void Update()
    {
        // Is shaking?
        if (!ShouldShake)
            return;
        
        _cameraCurrentPosition = _cameraTransform.localPosition;
        
        // Shake.
        if (_duration > 0)
        {
            // Shake the camera and slow down the duration.
            _cameraTransform.localPosition = _cameraCurrentPosition + Random.insideUnitSphere * _power;
            _duration -= Time.deltaTime * _slowDownAmount;
        }
        else
        {
            // Reset the values.
            ShouldShake = false;
            _duration = _resetDuration;
            _cameraTransform.localPosition = _cameraCurrentPosition;
        }
    }

    // Auto-properties.
    public bool ShouldShake { private get; set; }
}