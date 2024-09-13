using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    public Transform[] controlPoints; // Array of control points (3 for quadratic, 4 for cubic)
    public LineRenderer lineRenderer; // LineRenderer to visualize the curve
    public int curveResolution = 50;  // Number of points along the curve

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>(); // Get the LineRenderer component
    }

    void Update()
    {
        if (controlPoints.Length == 3)
        {
            DrawQuadraticBezierCurve();
        }
        else if (controlPoints.Length == 4)
        {
            DrawCubicBezierCurve();
        }
    }

    // Quadratic Bézier Curve (3 control points)
    void DrawQuadraticBezierCurve()
    {
        lineRenderer.positionCount = curveResolution + 1;
        for (int i = 0; i <= curveResolution; i++)
        {
            float t = i / (float)curveResolution;
            Vector3 point = CalculateQuadraticBezierPoint(t, controlPoints[0].position, controlPoints[1].position, controlPoints[2].position);
            lineRenderer.SetPosition(i, point);
        }
    }

    // Cubic Bézier Curve (4 control points)
    void DrawCubicBezierCurve()
    {
        lineRenderer.positionCount = curveResolution + 1;
        for (int i = 0; i <= curveResolution; i++)
        {
            float t = i / (float)curveResolution;
            Vector3 point = CalculateCubicBezierPoint(t, controlPoints[0].position, controlPoints[1].position, controlPoints[2].position, controlPoints[3].position);
            lineRenderer.SetPosition(i, point);
        }
    }

    // Calculate point on a quadratic Bézier curve
    Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        return u * u * p0 + 2 * u * t * p1 + t * t * p2;
    }

    // Calculate point on a cubic Bézier curve
    Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        return u * u * u * p0 + 3 * u * u * t * p1 + 3 * u * t * t * p2 + t * t * t * p3;
    }
}
