using UnityEngine;

public class GeiserController : MonoBehaviour
{
    [SerializeField] private Vector3 centerOffset;
    [SerializeField] private float force;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Rigidbody2D rb))
        {
            Vector3 direction = (other.transform.position - transform.position - centerOffset).normalized;
            rb.AddForce(direction * force);
        }
    }
}
