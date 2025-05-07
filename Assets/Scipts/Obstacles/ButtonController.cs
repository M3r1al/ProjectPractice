using System.Collections;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private WallController wall;
    [SerializeField] private Transform button;
    [SerializeField] private Vector3 topPosition;
    [SerializeField] private Vector3 bottomPosition;
    [SerializeField] private float pressTime = 0.5f;
    [SerializeField] private float releaseTime = 1;
    private int count = 0;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            count++;
            wall.RaiseWall();
            Debug.Log("Is started to...");
            StartCoroutine(pressButton());
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            count--;
            if (count > 0)
                return;
            wall.ReleaseWall();
            StartCoroutine(releaseButton());
        }
    }

    private IEnumerator pressButton()
    {
        if (pressTime <= 0)
            yield break;
        Debug.Log("Is pressing");
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / pressTime;
            button.localPosition = Vector3.Lerp(topPosition, bottomPosition, t);
            yield return null;
        }
        button.localPosition = bottomPosition;
    }

    private IEnumerator releaseButton()
    {
        if (releaseTime <= 0)
            yield break;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / releaseTime;
            button.localPosition = Vector3.Lerp(bottomPosition, topPosition, t);
            yield return null;
        }
        button.localPosition = topPosition;
    }
}
