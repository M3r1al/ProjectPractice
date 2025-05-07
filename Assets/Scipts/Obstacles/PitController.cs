using UnityEngine;

public class PitController : MonoBehaviour
{
    // different script from water cause in water in future maybe i'll add
    // ability to survive even if u end in it
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Game.SetState(Game.GameState.Died);
            Debug.Log("Fell in pit");
            other.gameObject.SetActive(false);
            // Destroy(other.gameObject);
        }
    }
}
