using UnityEngine;

public abstract class MMenu<T> : Menu where T : MMenu<T>
{
    // Declare variables.
    private static T Instance { get; set; }
    
    /// <summary>
    /// Calling before start.
    /// </summary>
    protected virtual void Awake()
    {
        Instance = (T)this;
    }

    /// <summary>
    /// Calling, when this script destroyed.
    /// </summary>
    protected virtual void OnDestroy()
    {
        Instance = null;
    }
    
    /// <summary>
    /// Open the current menu.
    /// </summary>
    protected static void Open()
    {
        if (Instance == null)
            MenuManager.Instance.CreateInstance<T>();
        else
            Instance.gameObject.SetActive(true);

        MenuManager.Instance.OpenMenu(Instance);
    }

    /// <summary>
    /// Close the current menu.
    /// </summary>
    protected static void Close()
    {
        if (Instance == null)
        {
            Debug.LogErrorFormat("No menu of type {0} is currently open.", typeof(T));
            return;
        }

        MenuManager.Instance.CloseMenu(Instance);
    }

    /// <inheritdoc/>
    public override void OnBackPressed()
    {
        Close();
    }
}

public abstract class Menu : MonoBehaviour
{
    // Declare variables.
    public bool DestroyWhenClosed = true;
    public bool DisableMenusUnderneath = true;

    /// <summary>
    /// Go back.
    /// </summary>
    public abstract void OnBackPressed();
}