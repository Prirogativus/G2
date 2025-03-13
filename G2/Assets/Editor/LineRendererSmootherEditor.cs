using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRendererSmoother : MonoBehaviour
{
    public LineRenderer Line;
    public int smoothingLength = 20; // Длина сглаживания
    public int smoothingSections = 20; // Количество секций для сглаживания

    private BezierCurve[] Curves;
    private Vector3[] initialState; // Хранит начальные позиции

    private void Start()
    {

        initialState = new Vector3[Line.positionCount];
        Line.GetPositions(initialState);

        EnsureCurvesMatchLineRendererPositions();
    }

    private void Update()
    {
        SmoothPath();

        if (Input.GetKeyDown(KeyCode.R)) // Нажмите R для восстановления
        {
            RestoreDefault();
        }
    }

    public void SmoothPath()
    {
        if (Curves == null || Curves.Length < 1)
        {
            Debug.LogWarning("Недостаточно точек для сглаживания!");
            return;
        }

        Line.positionCount = Curves.Length * smoothingSections;
        int index = 0;

        for (int i = 0; i < Curves.Length; i++)
        {
            Vector3[] segments = Curves[i].GetSegments(smoothingSections);
            for (int j = 0; j < segments.Length; j++)
            {
                Line.SetPosition(index, segments[j]);
                index++;
            }
        }
    }

    private void RestoreDefault()
    {
        if (initialState != null && initialState.Length > 0)
        {
            Line.positionCount = initialState.Length;
            Line.SetPositions(initialState);
            EnsureCurvesMatchLineRendererPositions();
        }
    }

    private void EnsureCurvesMatchLineRendererPositions()
    {
        if (Line == null)
        {
            return;
        }

        if (Curves == null || Curves.Length != Line.positionCount - 1)
        {
            Curves = new BezierCurve[Line.positionCount - 1];
            for (int i = 0; i < Curves.Length; i++)
            {
                Curves[i] = new BezierCurve();
            }
        }

        for (int i = 0; i < Curves.Length; i++)
        {
            Curves[i].Points[0] = Line.GetPosition(i); // Начальная точка
            Curves[i].Points[3] = Line.GetPosition(i + 1); // Конечная точка

            Vector3 direction = (Curves[i].Points[3] - Curves[i].Points[0]).normalized;
            Curves[i].Points[1] = Curves[i].Points[0] + direction * smoothingLength;
            Curves[i].Points[2] = Curves[i].Points[3] - direction * smoothingLength;
        }
    }
}
