using UnityEngine;

[System.Serializable]
public class BezierCurve
{
    public Vector3[] Points;
    //public LineManager lineManager;

    public BezierCurve()
    {
        Points = new Vector3[4];
        /*
        if (lineManager != null)
        {
            Points = lineManager.points;
        }*/
    }

    public BezierCurve(Vector3[] Points)
    {
        this.Points = Points;
        //this.Points = lineManager.points;
    }

    public Vector3 StartPosition
    {
        get
        {
            return Points[0];
        }
    }

    public Vector3 EndPosition
    {
        get
        {
            return Points[3];
        }
    }

    public Vector3 GetSegment(float Time)
    {
        //int repetitionModificator = 3;
        /*Vector3 p0 = Points[(Points.Length - 4) - curveRepeatitionCount * repetitionModificator];
        Vector3 p1 = Points[(Points.Length - 3) - curveRepeatitionCount * repetitionModificator];
        Vector3 p2 = Points[(Points.Length - 2) - curveRepeatitionCount * repetitionModificator];
        Vector3 p3 = Points[(Points.Length - 2) - curveRepeatitionCount * repetitionModificator];*/
        Time = Mathf.Clamp01(Time);
        float time = 1 - Time;
        return (time * time * time * Points[0]) //p0
            + (3 * time * time * Time * Points[1]) //p1
            + (3 * time * Time * Time * Points[2]) //p2
            + (Time * Time * Time * Points[3]); //p3
    }

    public Vector3[] GetSegments(int Subdivisions)
    {
        Vector3[] segments = new Vector3[Subdivisions];

        float time;
        for (int i = 0; i < Subdivisions; i++)
        {
            time = (float)i / Subdivisions;
            segments[i] = GetSegment(time);
        }

        return segments;
    }
}
