using UnityEngine;
public class CirclePath : MonoBehaviour
{
    public float radius;
    public int segments;
    public LineRenderer lineRenderer;
    public Transform[] objectsToMove;
    public float objectSpeed;
    private int[] currentSegment;
    private Vector3[] targetPosition;
    void Start()
    {
        lineRenderer.positionCount = segments + 1;
        lineRenderer.useWorldSpace = true;
        lineRenderer.transform.position = transform.position;
        float x, y;
        float angle = 20f;
        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
            angle += (360f / segments);
        }
        currentSegment = new int[objectsToMove.Length];
        targetPosition = new Vector3[objectsToMove.Length];
        for (int i = 0; i < objectsToMove.Length; i++)
        {
            float distance = float.MaxValue;
            int closestPoint = 0;
            for (int j = 0; j < segments; j++)
            {
                float d = Vector3.Distance(objectsToMove[i].position, lineRenderer.GetPosition(j));
                if (d < distance)
                {
                    distance = d;
                    closestPoint = j;
                }
            }
            currentSegment[i] = closestPoint;
            objectsToMove[i].position = lineRenderer.GetPosition(currentSegment[i]);
            targetPosition[i] = lineRenderer.GetPosition((currentSegment[i] + 1) % segments);
        }
    }
    void Update()
    {
        for (int i = 0; i < objectsToMove.Length; i++)
        {
            objectsToMove[i].position = Vector3.MoveTowards(objectsToMove[i].position, targetPosition[i], objectSpeed * Time.deltaTime);
            if (Vector3.Distance(objectsToMove[i].position, targetPosition[i]) < 0.1f)
            {
                currentSegment[i] = (currentSegment[i] + 1) % segments;
                targetPosition[i] = lineRenderer.GetPosition(currentSegment[i]);
            }
            objectsToMove[i].rotation = Quaternion.LookRotation(Vector3.forward, targetPosition[i] - objectsToMove[i].position);

        }
    }
}