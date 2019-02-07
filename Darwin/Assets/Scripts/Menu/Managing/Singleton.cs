using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // Declare variables.
    private static T _instance;

    /// <summary>
    /// Get the current instance of the singleton menu.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_instance != null)
                return _instance;
            
            _instance = (T)FindObjectOfType(typeof(T));
            if (_instance == null)
                Debug.LogErrorFormat("An instance of {0} is missing in this scene", typeof(T));

            return _instance;
        }
    }
}