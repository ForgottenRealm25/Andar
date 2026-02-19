using UnityEngine;

public class FightCamera : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    [Header("Zoom")]
    public float minZoom = 5f;
    public float maxZoom = 8f;
    public float zoomLimiter = 10f;

    [Header("Movimento")]
    public float smoothTime = 0.2f;

    [Header("Limites do Cenário")]
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector3 velocity;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (!player1 || !player2) return;

        MoveCamera();
        ZoomCamera();
    }

    void MoveCamera()
    {
        Vector3 centerPoint = (player1.position + player2.position) / 2f;

        float clampedX = Mathf.Clamp(centerPoint.x, minX, maxX);
        float clampedY = Mathf.Clamp(centerPoint.y, minY, maxY);

        Vector3 newPosition = new Vector3(clampedX, clampedY, transform.position.z);

        transform.position = Vector3.SmoothDamp(
            transform.position,
            newPosition,
            ref velocity,
            smoothTime
        );
    }

    void ZoomCamera()
    {
        float distance = Vector2.Distance(player1.position, player2.position);
        float targetZoom = Mathf.Lerp(minZoom, maxZoom, distance / zoomLimiter);

        cam.orthographicSize = Mathf.Lerp(
            cam.orthographicSize,
            targetZoom,
            Time.deltaTime
        );
    }
}
