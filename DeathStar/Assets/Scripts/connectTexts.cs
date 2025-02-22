using UnityEngine;

public class connectTexts : MonoBehaviour
{
    [SerializeField] private Transform point;

    private float lineWidth = 0.0008f;
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
    }

    void Start()
    {
        lineRenderer.positionCount = 2; // Dos puntos
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.yellow;
        lineRenderer.endColor = Color.yellow;
    }

    void Update()
    {
        if (point != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, point.position);
        }
    }
}
