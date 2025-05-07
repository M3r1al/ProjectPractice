using System.Collections;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] private Vector3 topPosition;
    [SerializeField] private Vector3 defaultPosition;
    [SerializeField] private Vector3 crushPosition;
    [SerializeField] private float raiseSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration = 9.81f;

    private bool isRaising = false;
    private bool isReleasing = false;
    private bool raised = false;

    private void OnEnable() => ReleaseWall();

    public void RaiseWall()
    {
        raised = true;
        if (isReleasing)
            StopAllCoroutines();
        StartCoroutine(raiseCoroutine());
    }

    public void ReleaseWall()
    {
        raised = false;
        if (isRaising)
            StopAllCoroutines();
        StartCoroutine(releaseCoroutine());
    }

    private bool isDown() => Vector3.Distance(transform.position, defaultPosition) < Vector3.Distance(crushPosition, defaultPosition);

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && isDown())
        {
            Game.SetState(Game.GameState.Died);
            Debug.Log("Crushed by wall");
            other.gameObject.SetActive(false);
            // Destroy(other.gameObject);
        }
    }

    private IEnumerator raiseCoroutine()
    {
        if (raiseSpeed <= 0)
            yield break;
        
        isRaising = true;
        float t = 0;
        Vector3 from = transform.position;
        while (t < 1)
        {
            t += Time.deltaTime * raiseSpeed;
            transform.position = Vector3.Lerp(from, topPosition, t);
            yield return null;
        }
        transform.position = topPosition;
        isRaising = false;
    }

    private IEnumerator releaseCoroutine()
    {
        if (speed <= 0 && acceleration <= 0)
            yield break;
        
        isReleasing = true;
        float t = 0;
        float currentSpeed = speed;
        while (t < 1)
        {
            t += Time.deltaTime * currentSpeed;
            transform.position = Vector3.Lerp(topPosition, defaultPosition, t);
            currentSpeed += acceleration * Time.deltaTime;
            yield return null;
        }
        transform.position = defaultPosition;
        isReleasing = false;
    }
}
