using UnityEngine;

public class InfoAbout : MMenu<InfoAbout> 
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
    /// Open the play store entry of this game.
    /// </summary>
    public void OpenRateAnAppUrl()
    {
        // Application.OpenUrl();
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