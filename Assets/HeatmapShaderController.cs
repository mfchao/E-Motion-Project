using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatmapShaderController : MonoBehaviour
{
    public Material heatmapMaterial;
    public float changeInterval = 1f;

    private float nextChangeTime;
    private float pulseSpeed;
    private float strength;
    public float baseScale = 1.0f;
    public float pulseScale = 0.1f;
    public float frequency = 1.0f;

    public Color color0;
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;

    private Color currentColor0;
    private Color currentColor1;
    private Color currentColor2;
    private Color currentColor3;
    private Color currentColor4;

    public Shader shader;
    public Renderer renderer;


    private void Start()
    {
        nextChangeTime = Time.time + changeInterval;
        pulseSpeed = heatmapMaterial.GetFloat("_PulseSpeed");
        strength = heatmapMaterial.GetFloat("_Strength");

        renderer.material.shader = shader;
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

    public void OnValueChanged(string key, float value)
    {
        if (value >= 50f) {
         if (key == "enjoyment")
        {
            float normalizedValueE = value / 100f;
            Color targetColor0 = new Color(normalizedValueE, color0.g, color0.b);
            currentColor0 = Color.Lerp(currentColor0, targetColor0, Time.deltaTime);
        }
        else if (key == "focus")
        {
            float normalizedValueF = value / 100f;
            Color targetColor1 = new Color(color1.r, normalizedValueF, color1.b);
            currentColor1 = Color.Lerp(currentColor1, targetColor1, Time.deltaTime);
        }
        else if (key == "zone_state")
        {
            float normalizedValueZ = value / 100f;
            Color targetColor2 = new Color(color2.r, color2.g, normalizedValueZ);
            currentColor2 = Color.Lerp(currentColor2, targetColor2, Time.deltaTime);
        }

        // set the shader properties with the new colors
        renderer.material.SetColor("_Color0", color0);
        renderer.material.SetColor("_Color1", color1);
        renderer.material.SetColor("_Color2", color2);
        renderer.material.SetColor("_Color3", color3);
        renderer.material.SetColor("_Color4", color4);
    }
        else {
            // Smoothly transition to random colors
        Color[] colors = new Color[5];
        switch (Random.Range(0, 3))
        {
            case 0:
                colors[0] = new Color(0f, 0f, 0f, 1f);
                colors[1] = new Color(.9f, .1f, .8f, 1f);
                colors[2] = new Color(.2f, .6f, .9f, 1f);
                colors[3] = new Color(.8f, .4f, .2f, 1f);
                colors[4] = new Color(.2f, .4f, .9f, 1f);
                break;
            case 1:
                colors[0] = new Color(0f, 0f, 0f, 1f);
                colors[1] = new Color(.1f, .8f, .1f, 1f);
                colors[2] = new Color(.7f, .2f, .4f, 1f);
                colors[3] = new Color(.4f, .7f, .1f, 1f);
                colors[4] = new Color(.2f, .5f, .1f, 1f);
                break;
            case 2:
                colors[0] = new Color(0f, 0f, 0f, 1f);
                colors[1] = new Color(.4f, .6f, .9f, 1f);
                colors[2] = new Color(1f, .6f, .2f, 1f);
                colors[3] = new Color(.9f, 1f, .3f, 1f);
                colors[4] = new Color(.9f, .7f, .1f, 1f);
                break;
        }
        StartCoroutine(SwitchColorsSmoothly(colors, 1f));
        }
    
}
private IEnumerator SwitchColorsSmoothly(Color[] colors, float duration)
{
    Color[] startColors = new Color[5];
    for (int i = 0; i < colors.Length; i++)
    {
        startColors[i] = renderer.material.GetColor("_Color" + i);
    }

    float timeElapsed = 0f;
    while (timeElapsed < duration)
    {
        float t = timeElapsed / duration;
        for (int i = 0; i < colors.Length; i++)
        {
            Color lerpedColor = Color.Lerp(startColors[i], colors[i], t);
            renderer.material.SetColor("_Color" + i, lerpedColor);
        }
        yield return null;
        timeElapsed += Time.deltaTime;
    }

    // Set final colors
    for (int i = 0; i < colors.Length; i++)
    {
        renderer.material.SetColor("_Color" + i, colors[i]);
    }
}
}
