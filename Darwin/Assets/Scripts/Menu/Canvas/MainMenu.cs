using UnityEngine;

public class MainMenu : MMenu<MainMenu> 
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
    /// Open the info about window.
    /// </summary>
    public void ShowInfoAbout()
    {
        Close();
        InfoAbout.Show();
    }

    /// <summary>
    /// Open the level selection menu.
    /// </summary>
    public void ShowLevelSelection()
    {
        Close();
        LevelSelection.Show();
    }

    /// <summary>
    /// Open the browser for feedback site.
    /// </summary>
    public void OpenFeedback()
    {
        Application.OpenURL(
            "https://docs.google.com/forms/d/e/1FAIpQLSc7SCt8OKixnDanhMopAiObF88EanNTQqHfIQTKs2abUcvOXg/viewform");
    }
}