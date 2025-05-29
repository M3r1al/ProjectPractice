using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] private GameObject completePanel;
    private int playerCount = 0;
    private GameObject previousPlayer = null;

    private void OnEnable()
    {
        playerCount = 0;
        completePanel.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == previousPlayer)
            return;
        if (other.gameObject.tag == "Player" && Game.State == Game.GameState.None)
        {
            playerCount++;
            Debug.Log("Entered portal");
            other.gameObject.SetActive(false);
            previousPlayer = other.gameObject;
            if (playerCount == 2)
                CompleteGame();
        }
    }

    private void CompleteGame()
    {
        Game.SetState(Game.GameState.Completed);
        completePanel.SetActive(true);
    }
}
