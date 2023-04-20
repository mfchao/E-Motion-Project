using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
  // void Update()
  // {
  //   transform.position = transform.position + new Vector3(0f, 0f, 1f) * Time.deltaTime;
  // }

   public float gyroSensitivity = 0.5f; // Adjust this value to control gyroscope sensitivity
    private Vector3 gyroSmoothValue; 
    // public Light myLight;

    public GameObject projectilePrefab; 
    private GameObject mProjectile;
    public GameObject quad;

    private float quadSize;


    void Start()
    {
        // Initialize smoothed gyroscope value to zero
        gyroSmoothValue = Vector3.zero; 

       
      
        
    }

    public void OnArrayValueChanged(string key, float[] value)
    {
        // here we store the value into our dictionary
        if (key == "Gyroscope") {
          // If the projectile hasn't been instantiated yet, instantiate it
            if (mProjectile == null)
            {
                mProjectile = Instantiate(projectilePrefab);
               
            }

            // Apply exponential smoothing to gyroscope value
            gyroSmoothValue = Vector3.Lerp(gyroSmoothValue, new Vector3(value[0], value[1], value[2]), gyroSensitivity);

             // Normalize gyroscope data
            float normalizedX = Mathf.Clamp01(Mathf.Abs(gyroSmoothValue.x) / 120f);
            float normalizedY = Mathf.Clamp01(Mathf.Abs(gyroSmoothValue.y) / 120f);

            // Map gyroscope data to quad grid
            float quadWidth = quad.transform.localScale.x;
            float quadHeight = quad.transform.localScale.y;

            Vector3 quadPosition = quad.transform.position;
            float mappedX = (normalizedX * quadWidth) + (quadPosition.x - 1);
            float mappedY = (normalizedY * quadHeight) + (quadPosition.y - 1);

            // Update projectile position
            float newX = Mathf.Clamp(mappedX, quadPosition.x - quadWidth/2, quadPosition.x + quadWidth/2);
            float newY = Mathf.Clamp(mappedY, quadPosition.y - quadHeight/2, quadPosition.y + quadHeight/2);

            mProjectile.transform.position = new Vector3(newX, newY, quadPosition.z);


            

            // // Update projectile's position
            // mProjectile.transform.position = new Vector3(gyroSmoothValue.x, gyroSmoothValue.y, gyroSmoothValue.z);

            
         
            
        }
    }

}
