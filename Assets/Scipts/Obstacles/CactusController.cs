using UnityEngine;

public class CactusController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 from;
    [SerializeField] private Vector3 to;
    private float t;

    private void OnEnable() => t = 0;

    private void Update()
    {
        t += Time.deltaTime;
        transform.position = PingPong(from, to, t, moveSpeed);
    }

    private Vector3 PingPong(Vector3 a, Vector3 b, float d, float f) => Vector3.Lerp(from, to, Mathf.PingPong(d * moveSpeed, 1));

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Game.SetState(Game.GameState.Died);
            Debug.Log("Killed by cactus");
            other.gameObject.SetActive(false);
            // Destroy(other.gameObject);
        }
    }
}
