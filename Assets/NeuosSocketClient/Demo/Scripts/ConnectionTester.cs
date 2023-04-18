using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionTester : MonoBehaviour
{

    public float gyroSensitivity = 0.2f; // Adjust this value to control gyroscope sensitivity
    private Vector3 gyroSmoothValue; 
    public Light myLight;

    void Start()
    {
        // Initialize smoothed gyroscope value to zero
        gyroSmoothValue = Vector3.zero; 
    }

    public void OnArrayValueChanged(string key, float[] value)
    {
        // here we store the value into our dictionary
        if (key == "Gyroscope") {
            // Apply exponential smoothing to gyroscope value
            gyroSmoothValue = Vector3.Lerp(gyroSmoothValue, new Vector3(value[0], value[1], value[2]), gyroSensitivity);

            // Update game object's position
            gameObject.transform.position = new Vector3(gyroSmoothValue.x, gyroSmoothValue.y, gyroSmoothValue.z);
        }
    }

    public void OnValueChanged(string key, float value)
    {
        if (key == "enjoyment")
        {
            // Update light's color based on enjoyment value
            float normalizedValueE = value / 100f; 
            Color currentColor = myLight.color;
            myLight.color = new Color(normalizedValueE, currentColor.g, currentColor.b); 
        }
        else if (key == "focus")
        {
            // Update light's color based on focus value
            float normalizedValueF = value / 100f; 
            Color currentColor = myLight.color;
            myLight.color = new Color(currentColor.r, normalizedValueF, currentColor.b); 
        }
        else if (key == "zone_state")
        {
            // Update light's color based on zone state value
            float normalizedValueZ = value / 100f; 
            Color currentColor = myLight.color;
            myLight.color = new Color(currentColor.r, currentColor.g, normalizedValueZ); 
        }
    }


}
