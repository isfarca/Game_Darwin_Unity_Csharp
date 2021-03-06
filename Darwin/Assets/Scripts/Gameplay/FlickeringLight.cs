using UnityEngine;

public class FlickeringLight : MonoBehaviour 
{
    // Declare variables.
    private int _flickerTimer, _flickerAt, _lightOffTimer, _lightOffAt;
    private Light _flickerLight;

    /// <summary>
    /// Calling by start.
    /// </summary>
    private void Start() 
    {
        _flickerLight = GetComponent<Light>();
        _lightOffAt = 3;
        FlickerOn();
	}
	
    /// <summary>
    /// Calling per frame.
    /// </summary>
    private void Update() 
    {
	    _flickerTimer++;

        if (_flickerTimer >= _flickerAt)
            FlickerOn();

        if (_flickerLight.enabled && _lightOffTimer <= _lightOffAt)
            _lightOffTimer++;
        else if (_flickerLight.enabled && _lightOffTimer > _lightOffAt)
            FlickerOff();
	}

    /// <summary>
    /// Flicker the light.
    /// </summary>
    private void FlickerOn()
    {
        // Turn light on.
        _flickerLight.enabled = true;
        _flickerTimer = 0;
        _flickerAt = Random.Range(5, 50);
    }

    /// <summary>
    /// Don't flicker the light.
    /// </summary>
    private void FlickerOff()
    {
        // Turn light off.
        _flickerLight.enabled = false;
        _lightOffTimer = 0;
    }
}