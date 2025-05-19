using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static float completeTime = 0;
    public static GameController Instance;
    [SerializeField] private KeyCode restartKey = KeyCode.R;
    [SerializeField] private KeyCode pauseKey = KeyCode.P;
    [SerializeField] private KeyCode leaveKey = KeyCode.Q;
    [SerializeField] private GameObject[] levelObjects;
    [SerializeField] private Rigidbody2D player1;
    [SerializeField] private Rigidbody2D player2;
    [SerializeField] private Vector3 firstSpawnPos;
    [SerializeField] private Vector3 secondSpawnPos;

    private void Awake()
    {
        Instance = this;
        RestartLevel();
    }

    private void Update()
    {
        completeTime += Time.deltaTime;
        if (Input.GetKeyDown(restartKey))
            RestartLevel();
        if (Input.GetKeyDown(pauseKey))
            Pause();
        if (Input.GetKeyDown(leaveKey))
            QuitLevel();
    }

    private Game.GameState gameState;
    private void Pause()
    {
        if (Time.timeScale > 0)
        {
            gameState = Game.State;
            Game.SetState(Game.GameState.Paused);
        }
        else
            Game.SetState(gameState);
        Time.timeScale = Time.timeScale > 0 ? 0 : 1;
    }

    public void RestartLevel()
    {
        completeTime = 0;

        foreach (var levelObject in levelObjects)
        {
            levelObject.SetActive(false);
            levelObject.SetActive(true);
        }
        
        MovePlayer(player1, firstSpawnPos);
        MovePlayer(player2, secondSpawnPos);
    }

    public void QuitLevel(bool completed = false)
    {
        SceneManager.LoadScene(0);
    }

    private void MovePlayer(Rigidbody2D player, Vector3 position)
    {
        player.gameObject.SetActive(false);
        player.position = position;
        player.gameObject.SetActive(true);
        player.linearVelocity = Vector3.zero;
        player.angularVelocity = 0;
    }
}
