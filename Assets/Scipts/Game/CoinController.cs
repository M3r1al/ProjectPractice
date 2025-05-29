using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static int count;
    private bool isCollected = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (isCollected)
            return;
        if (other.gameObject.tag == "Player")
        {
            isCollected = true;
            count++;
            Debug.Log("Took coin");
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        count = 0;
        isCollected = false;
    }
}
