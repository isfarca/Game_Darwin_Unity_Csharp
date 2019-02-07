using System.Collections.Generic;
using UnityEngine;

public class MenuManager : Singleton<MenuManager>
{
    // Declare variables.
    private readonly Stack<Menu> _menuStack = new Stack<Menu>();
    [SerializeField] private Menu[] _menuPrefabs;

    /// <summary>
    /// Calling by start.
    /// </summary>
    private void Start()
    {
        MainMenu.Show();
    }

    /// <summary>
    /// Calling per frame.
    /// </summary>
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
            return;
        
        // Open and Close menu.
        if (_menuStack.Count > 0)
            _menuStack.Peek().OnBackPressed();
    }
    
    /// <summary>
    /// Create the instance of a menu.
    /// </summary>
    /// <typeparam name="T">Static menu.</typeparam>
    public void CreateInstance<T>() where T : Menu
    {
        // Declare variables.
        T prefab = GetPrefab<T>();

        Instantiate(prefab, transform);
    }

    /// <summary>
    /// Open the menu.
    /// </summary>
    /// <param name="instance">Static menu.</param>
    public void OpenMenu(Menu instance)
    {
        if (_menuStack.Count > 0)
        {
            if (instance.DisableMenusUnderneath)
            {
                foreach (Menu menu in _menuStack)
                {
                    // Search for menu with disableMenusUnderneath, disable it and end loop.
                    CanvasGroup cg = menu.GetComponent<CanvasGroup>();
                    
                    if (cg != null)
                        cg.interactable = false;
                    else
                        menu.gameObject.SetActive(false);
                    
                    if (menu.DisableMenusUnderneath)
                        break;
                }
            }

            Canvas topCanvas = instance.GetComponent<Canvas>();
            Canvas prevCanvas = _menuStack.Peek().GetComponent<Canvas>();

            topCanvas.sortingOrder = prevCanvas.sortingOrder + 1;
        }

        _menuStack.Push(instance);
    }

    /// <summary>
    /// Close the menu.
    /// </summary>
    /// <param name="instance">Static menu.</param>
    public void CloseMenu(Menu instance)
    {
        // If there are no open menus.
        if (_menuStack.Count <= 0)
        {
            Debug.LogErrorFormat("Stack is empty. {0} cannot be closed.", instance.GetType());
            return;
        }

        // If the menu u want to close is not the top menu.
        if (_menuStack.Peek() != instance)
        {
            Debug.LogErrorFormat("{0} is not the top menu.", instance.GetType());
            return;
        }

        // Else.
        CloseTopMenu();
    }

    /// <summary>
    /// Close the on the top menu.
    /// </summary>
    public void CloseTopMenu()
    {
        Menu instance = _menuStack.Pop();

        if (instance.DestroyWhenClosed)
            Destroy(instance.gameObject);
        else
            instance.gameObject.SetActive(false);

        // To activate the lower menu.
        foreach (Menu menu in _menuStack)
        {
            CanvasGroup cg = menu.GetComponent<CanvasGroup>();

            if (cg != null)
                cg.interactable = true;
            else
                menu.gameObject.SetActive(true);

            if (menu.DisableMenusUnderneath)
                break;
        }
    }
    
    /// <summary>
    /// Get the all menu prefabs.
    /// </summary>
    /// <typeparam name="T">Static menu.</typeparam>
    /// <returns>Menu prefab.</returns>
    /// <exception cref="MissingReferenceException">No prefab!</exception>
    private T GetPrefab<T>() where T : Menu
    {
        foreach (Menu menu in _menuPrefabs)
        {
            T prefab = menu as T;
            
            if (prefab != null)
                return prefab;
        }

        throw new MissingReferenceException("No prefab of type " + typeof(T) + " found!");
    }
}