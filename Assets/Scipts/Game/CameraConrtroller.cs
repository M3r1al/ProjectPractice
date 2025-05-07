using UnityEngine;

public class CameraConrtroller : MonoBehaviour
{
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
    [SerializeField] private float minimumSize;
    [SerializeField] private float defaultDistance;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float sizeMultiplier = 1.1f;
    private Camera _camera;
    private float _edgeDistance;
    private float _minimumDistance;
    private float newSize;
    public Vector3 newPos;
    private readonly Vector3 offset = new Vector3(0, 0, -10);
    private float lerpDistance = 0.1f;

    private void Awake()
    {
        _camera = gameObject.GetComponent<Camera>();
        _edgeDistance = 6 * minimumSize - defaultDistance;
        _minimumDistance = defaultDistance + _edgeDistance;
    }

    private void LateUpdate()
    {
        CalculateValues();
        LerpValues();
    }

    private void CalculateValues()
    {
        float distanceX = Mathf.Abs(player1.position.x - player2.position.x);
        float distanceY = Mathf.Abs(player1.position.y - player2.position.y);
        float distance = Mathf.Max(distanceX, distanceY) + _edgeDistance;

        if (distance < _minimumDistance)
            newSize = minimumSize;
        else
            newSize = sizeMultiplier * minimumSize * distance / _minimumDistance;

        newPos = (player1.position + player2.position) / 2 + offset;
    }

    private void LerpValues()
    {
        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, newSize, lerpSpeed * Time.deltaTime); // проблема - при большом расстоянии между игроками они становятся не видны. Логику надо пересмотреть
        if (Vector3.Distance(transform.position, newPos) > lerpDistance)
            transform.position = Vector3.Lerp(transform.position, newPos, lerpSpeed * Time.deltaTime);
    }
}
