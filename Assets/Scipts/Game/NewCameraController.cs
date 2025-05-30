using UnityEngine;

public class NewCameraController : MonoBehaviour
{
    private const float lerpDistance = 0.1f;
    private const float lerpSize = 0.1f;
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
    [SerializeField] private float minimumSize;
    [SerializeField] private float defaultDistance;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float sideSpace = 1;
    [SerializeField] private float verticalOffset = 2f;
    private Camera _camera;
    private float _aspect;
    private float _edgeDistance;
    private float _minimumDistance;
    private float newSize;
    public Vector3 newPos;
    private readonly Vector3 offset = new Vector3(0, 0, -10);
    // private float lerpDistance = 0.1f;
    private float width;
    private float height;
    public float distance;

    private void Awake()
    {
        GetValues();
    }

    private void LateUpdate()
    {
        if (player1.gameObject.activeSelf && player2.gameObject.activeSelf)
            CalculateValues();
        else if (player1.gameObject.activeSelf || player2.gameObject.activeSelf)
            LerpOnePlayer();
        else
        {
            Destroy(this);
            return;
        }
        LerpValues();
    }

    private void GetValues()
    {
        _camera = gameObject.GetComponent<Camera>();
        _aspect = _camera.aspect;
    }

    #region two players
    private void CalculateValues()
    {
        float distanceX = Mathf.Abs(player1.position.x - player2.position.x) + sideSpace; // width
        float distanceY = Mathf.Abs(player1.position.y - player2.position.y) + sideSpace; // height
        // aspect = width / height

        distance = Mathf.Max(distanceY, distanceX / _aspect); // oSize = distance * 2

        if (distance < defaultDistance)
            newSize = minimumSize;
        else
            newSize = minimumSize * distance / defaultDistance;

        newPos = (player1.position + player2.position) / 2 + offset + new Vector3(0, verticalOffset, 0);
    }

    private void LerpValues()
    {
        if (Mathf.Abs(_camera.orthographicSize - newSize) > lerpSize)
            _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, newSize, lerpSpeed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, newPos) > lerpDistance)
            transform.position = Vector3.Lerp(transform.position, newPos, lerpSpeed * Time.deltaTime);
    }
    #endregion

    #region one player
    private void LerpOnePlayer()
    {
        if (player1.gameObject.activeSelf)
            newPos = player1.position + offset + new Vector3(0, verticalOffset, 0);
        else
            newPos = player2.position + offset + new Vector3(0, verticalOffset, 0);
        newSize = minimumSize;
    }
    #endregion
}
