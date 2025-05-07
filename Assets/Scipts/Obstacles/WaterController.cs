using UnityEngine;

public class WaterController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Game.SetState(Game.GameState.Died);
            Debug.Log("Drowned in water");
            other.gameObject.SetActive(false);
            // Destroy(other.gameObject);
        }
    }
}
