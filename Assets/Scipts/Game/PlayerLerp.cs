using UnityEngine;

public class PlayerLerp : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float lerpSpeed;
    private Vector3 offset;

    private void OnValidate()
    {
        if (target == null)
            target = transform.parent;
    }

    private void Awake() => offset = transform.position - target.position;
    
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpSpeed * Time.deltaTime);
    }
}
