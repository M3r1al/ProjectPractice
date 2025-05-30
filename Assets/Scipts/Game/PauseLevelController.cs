using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLevelController : MonoBehaviour
{
    [Header("UI")]
    public GameObject pauseMenuCanvas;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        isPaused = !isPaused;
        pauseMenuCanvas.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void OnRestartPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnLobbyPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lobby");
    }

    public void OnSettingsPressed()
    {
        Debug.Log("Settings clicked (todo)");
    }
}
