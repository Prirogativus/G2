using UnityEngine;

public class LineLengthCalculator : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float length;

    void Start()
    {
        
    }
    private void Update()
    {
        length = GetLineLength(lineRenderer);
    }

    float GetLineLength(LineRenderer lr)
    {
        if (lr == null || lr.positionCount < 2)
        {
            return 0f;
        }

        float totalLength = 0f;

        for (int i = 0; i < lr.positionCount - 1; i++)
        {
            Vector3 pointA = lr.GetPosition(i);
            Vector3 pointB = lr.GetPosition(i + 1);
            totalLength += Vector3.Distance(pointA, pointB);
        }

        return totalLength;
    }
}