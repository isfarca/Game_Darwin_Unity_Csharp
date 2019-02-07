using UnityEngine;
using UnityEngine.UI;

public class Settings : MMenu<Settings>
{
    // Declare variables.
    [SerializeField] private Button _controlsButton;
    
    /// <summary>
    /// Open this menu.
    /// </summary>
    public static void Show()
    {
        Open();
    }
    
    /// <summary>
    /// Close the game.
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Open the main menu.
    /// </summary>
    public void ShowMainMenu()
    {
        Close();
        MainMenu.Show();
    }

    /// <summary>
    /// Open the control menu.
    /// </summary>
    public void ShowControls()
    {
        Close();
        Controls.Show();
    }

    /// <summary>
    /// Open the help menu.
    /// </summary>
    public void ShowHelp()
    {
        Close();
        Help.Show();
    }

    /// <summary>
    /// Calling by start.
    /// </summary>
    private void Start()
    {
        // Controls setting is just for android user.
        _controlsButton.interactable = Application.platform == RuntimePlatform.Android;
    }
}