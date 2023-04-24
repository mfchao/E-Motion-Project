using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatmapShaderController : MonoBehaviour
{
    public Material heatmapMaterial;
    public float pulseSpeedMin = 0f;
    public float pulseSpeedMax = 5f;
    public float strengthMin = 0.1f;
    public float strengthMax = 4f;
    public float changeInterval = 1f;

    private float nextChangeTime;
    private float pulseSpeed;
    private float strength;
     public float baseScale = 1.0f;
    public float pulseScale = 0.1f;
    public float speed = 1.0f;
    public float frequency = 1.0f;



    private void Start()
    {
        nextChangeTime = Time.time + changeInterval;
        pulseSpeed = heatmapMaterial.GetFloat("_PulseSpeed");
        strength = heatmapMaterial.GetFloat("_Strength");
    }

    private void Update()
    {
        if (Time.time >= nextChangeTime)
        {
        float scale = baseScale * pulseScale * Mathf.PerlinNoise(Time.time * frequency, 0.0f);

        float newPulseSpeed = scale; // Example: Pulse speed changes over time
        float newStrength = scale; // Example: Strength oscillates between 0.1 and 2.1

        heatmapMaterial.SetFloat("_PulseSpeed", newPulseSpeed);
        heatmapMaterial.SetFloat("_Strength", newStrength);
        }
    }
}
