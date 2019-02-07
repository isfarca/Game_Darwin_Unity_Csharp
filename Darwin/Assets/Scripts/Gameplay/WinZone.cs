using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour 
{
    /// <summary>
    /// Calling by trigger.
    /// </summary>
    /// <param name="other">Player.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Go to main menu.
        SceneManager.LoadScene(0);
    }
}