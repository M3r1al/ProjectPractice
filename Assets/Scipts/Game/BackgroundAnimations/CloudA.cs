using UnityEngine;

public class CloudA : MonoBehaviour
{
    public float amplitude = 0.2f;   
    public float speed = 1f;         

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = startPos + new Vector3(0, newY, 0);
    }
}
