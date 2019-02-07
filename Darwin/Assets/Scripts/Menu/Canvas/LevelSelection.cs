using UnityEngine;

public class LevelSelection : MMenu<LevelSelection> 
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
    /// Open the main menu.
    /// </summary>
    public void ShowMainMenu()
    {
        Close();
        MainMenu.Show();
    }

    /// <summary>
    /// Open the gene selection menu.
    /// </summary>
    public void ShowGeneSelection()
    {
        Close();
        GeneSelection.Show();
    }
}