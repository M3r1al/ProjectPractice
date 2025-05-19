using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static int count;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            count++;
            Debug.Log("Took coin");
            gameObject.SetActive(false);
        }
    }
}
