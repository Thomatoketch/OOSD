using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBezierPath : MonoBehaviour
{
    public Transform[] controlPoints;  // Points de contrôle de la courbe de Bézier
    public float speed = 2f;           // Vitesse du déplacement de la caméra
    private float t = 0f;              // Variable pour l'interpolation le long de la courbe

    void Update()
    {
        if (controlPoints.Length == 4) // Pour une courbe de Bézier cubique
        {
            MoveCameraAlongBezierCurve();
        }
    }

    void MoveCameraAlongBezierCurve()
    {
        // Augmenter la valeur de t en fonction de la vitesse
        t += Time.deltaTime * speed / Vector3.Distance(controlPoints[0].position, controlPoints[3].position);

        if (t > 1f) t = 0f;  // Réinitialise t pour faire une boucle (optionnel)

        // Calculer la position de la caméra sur la courbe
        Vector3 position = CalculateCubicBezierPoint(t, controlPoints[0].position, controlPoints[1].position, controlPoints[2].position, controlPoints[3].position);

        // Déplacer la caméra
        transform.position = position;

        // Optionnel : faire regarder la caméra dans une direction spécifique, comme un point d'intérêt
        // transform.LookAt(pointOfInterest);
    }

    // Calcul du point sur la courbe de Bézier cubique
    Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        return u * u * u * p0 + 3 * u * u * t * p1 + 3 * u * t * t * p2 + t * t * t * p3;
    }
}
