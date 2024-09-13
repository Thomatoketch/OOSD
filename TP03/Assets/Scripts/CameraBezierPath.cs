using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBezierPath : MonoBehaviour
{
    public Transform[] controlPoints;  // Points de contr�le de la courbe de B�zier
    public float speed = 2f;           // Vitesse du d�placement de la cam�ra
    private float t = 0f;              // Variable pour l'interpolation le long de la courbe

    void Update()
    {
        if (controlPoints.Length == 4) // Pour une courbe de B�zier cubique
        {
            MoveCameraAlongBezierCurve();
        }
    }

    void MoveCameraAlongBezierCurve()
    {
        // Augmenter la valeur de t en fonction de la vitesse
        t += Time.deltaTime * speed / Vector3.Distance(controlPoints[0].position, controlPoints[3].position);

        if (t > 1f) t = 0f;  // R�initialise t pour faire une boucle (optionnel)

        // Calculer la position de la cam�ra sur la courbe
        Vector3 position = CalculateCubicBezierPoint(t, controlPoints[0].position, controlPoints[1].position, controlPoints[2].position, controlPoints[3].position);

        // D�placer la cam�ra
        transform.position = position;

        // Optionnel : faire regarder la cam�ra dans une direction sp�cifique, comme un point d'int�r�t
        // transform.LookAt(pointOfInterest);
    }

    // Calcul du point sur la courbe de B�zier cubique
    Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        return u * u * u * p0 + 3 * u * u * t * p1 + 3 * u * t * t * p2 + t * t * t * p3;
    }
}
