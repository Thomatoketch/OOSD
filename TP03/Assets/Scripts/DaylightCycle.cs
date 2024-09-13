using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaylightCycle : MonoBehaviour
{
    public float dayDuration = 120f;
    private float timeOfDay = 0f;
    private Light sunLight;
    public Gradient lightColor;
    public AnimationCurve lightIntensityCurve;

    void Start()
    {
        sunLight = GetComponent<Light>();
    }

    void Update()
    {
        timeOfDay += Time.deltaTime / dayDuration;
        if (timeOfDay >= 1f) timeOfDay = 0f;

        transform.localRotation = Quaternion.Euler((timeOfDay * 360f) - 90f, 170f, 0f);

        sunLight.color = lightColor.Evaluate(timeOfDay);

        sunLight.intensity = lightIntensityCurve.Evaluate(timeOfDay);
    }
}
