using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MMenu<Load> 
{
    // Declare variables.
    [SerializeField] private Text _loadText;
    [SerializeField] private Slider _loadSlider;
    [SerializeField] private Text _progressText;
    private int _clickCounter;
    
    /// <summary>
    /// Open the loading window.
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
    /// Open the gene selection menu.
    /// </summary>
    public void ShowGeneSelection()
    {
        Close();
        GeneSelection.Show();
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
    /// Calling by start.
    /// </summary>
    private void Start()
    {
        _loadText.text = "Double tap to loading";
        _clickCounter = 0;
    }

    /// <summary>
    /// Calling per frame.
    /// </summary>
    private void Update()
    {
        // Standalone input.
        if (Input.GetMouseButtonDown(0))
            CheckToStartForLoading();

        // Mobile input.
        if (Input.touches.Length <= 0)
            return;

        if (Input.touches[0].phase == TouchPhase.Began)
            CheckToStartForLoading();
    }

    /// <summary>
    /// Check, if you start loading or clicking menu buttons.
    /// </summary>
    private void CheckToStartForLoading()
    {
        // By double click, start loading.
        if (_clickCounter > 0)
            StartCoroutine(LoadingProgress(1));

        _clickCounter++;
    }

    /// <summary>
    /// Level loading process.
    /// </summary>
    /// <param name="level">Scene build index.</param>
    /// <returns>NULL (irrelevant).</returns>
    private IEnumerator LoadingProgress(int level)
    {
        // Declare variables.
        AsyncOperation async = SceneManager.LoadSceneAsync(level);
        
        _loadText.text = "Loading...";
        
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);

            _loadSlider.value = progress;
            _progressText.text = progress * 100.0f + "%";

            yield return null;
        }
    }
}