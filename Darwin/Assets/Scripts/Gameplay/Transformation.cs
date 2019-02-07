using System.Collections;
using UnityEngine;

public class Transformation : MonoBehaviour
{
    // Declare variables.
    [SerializeField] private Sprite[] _playerSprites;
    private SpriteRenderer _playerSpriteRenderer;
    private ParticleSystem _transformationParticleSystem;

    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get the scripts and components.
        _playerSpriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        
        _transformationParticleSystem = GetComponent<ParticleSystem>();
        _transformationParticleSystem.gameObject.SetActive(false); // Disable transformation particle.
    }

    /// <summary>
    /// Start the co routine for transformation set.
    /// </summary>
    /// <param name="currentMutation">Selected mutation.</param>
    public void Change(string currentMutation)
    {
        // Activate transformation game object.
        _transformationParticleSystem.gameObject.SetActive(true);
        
        switch (currentMutation)
        {
            case "Normal":
                StartCoroutine(SetTransformation(_playerSprites[0], 0.0f));
                break;
            case "Elephant":
                StartCoroutine(SetTransformation(_playerSprites[1], 0.0f));
                break;
            case "Fish":
                StartCoroutine(SetTransformation(_playerSprites[2], -90.0f));
                break;
            case "Hawk":
                StartCoroutine(SetTransformation(_playerSprites[3], 0.0f));
                break;
            case "Rhino":
                StartCoroutine(SetTransformation(_playerSprites[4], 0.0f));
                break;
            case "Turtle":
                StartCoroutine(SetTransformation(_playerSprites[5], 0.0f));
                break;
            default:
                return;
        }
    }

    /// <summary>
    /// Change the sprites.
    /// </summary>
    /// <param name="sprite">Mutation.</param>
    /// <param name="rotationZ">Horizontal or Vertical position.</param>
    /// <returns>Seconds.</returns>
    private IEnumerator SetTransformation(Sprite sprite, float rotationZ)
    {
        // Wait one second.
        yield return new WaitForSeconds(1);

        // Override the sprite renderer with another sprite.
        _playerSpriteRenderer.sprite = sprite;
        GameObject.FindGameObjectWithTag("Player").transform.rotation =
            Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotationZ);
        _transformationParticleSystem.gameObject.SetActive(false);
        StopAllCoroutines();
    }
}