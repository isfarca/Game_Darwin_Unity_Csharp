using UnityEngine;

public class Help : MMenu<Help> 
{
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
    /// Open the settings menu.
    /// </summary>
    public void ShowSettings()
    {
        Close();
        Settings.Show();
    }

    /// <summary>
    /// Open the main menu.
    /// </summary>
    public void ShowMainMenu()
    {
        Close();
        MainMenu.Show();
    }
}