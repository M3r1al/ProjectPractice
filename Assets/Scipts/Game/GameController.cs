using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private KeyCode restartKey = KeyCode.R;
    [SerializeField] private KeyCode pauseKey = KeyCode.P;
    [SerializeField] private GameObject[] levelObjects;
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
    [SerializeField] private Vector3 firstSpawnPos;
    [SerializeField] private Vector3 secondSpawnPos;

    private void Awake() => RestartLevel();

    private void Update()
    {
        if (Input.GetKeyDown(restartKey))
            RestartLevel();
        if (Input.GetKeyDown(pauseKey))
            Pause();
    }

    private void Pause()
    {
        Time.timeScale = Time.timeScale > 0 ? 0 : 1;
    }

    private void RestartLevel()
    {
        foreach (var levelObject in levelObjects)
            levelObject.SetActive(true);
        
        MovePlayer(player1, firstSpawnPos);
        MovePlayer(player2, secondSpawnPos);
    }

    private void MovePlayer(Transform player, Vector3 position)
    {
        player.gameObject.SetActive(false);
        player.position = position;
        player.gameObject.SetActive(true);
    }
}
