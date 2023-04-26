using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
  
    // Material mMaterial;
    // MeshRenderer mMeshRenderer;

    public float gyroSensitivity = 0.5f; // Adjust this value to control gyroscope sensitivity
    private Vector3 gyroSmoothValue; 
    // public Light myLight;


    public GameObject projectile;
    public GameObject quad;

    // private float quadSize;

    // float[] mPoints;
    // int mHitCount;

    // private float interval = 1f; // interval in seconds
    // private float timer = 0f;
   


    void Start()
    {
        // Initialize smoothed gyroscope value to zero
        gyroSmoothValue = Vector3.zero; 

        // mMeshRenderer = GetComponent<MeshRenderer>();
        // mMaterial = mMeshRenderer.material;

        // mPoints = new float[100 * 3]; //32 point 

        // Initialize hit count
        //  mHitCount = 0;
      
        
    }

    // void Update()
    // {
    //     // increment timer
    //     timer += Time.deltaTime;

    //     // check if interval has passed
    //     if (timer >= interval)
    //     {
    //     // add current position to hit point list
    //     // addHitPoint(projectile.transform.position.x * 4 - 2, projectile.transform.position.y, projectile.transform.position.z );
       

    //     // calculate texture coordinates of current position
    //     Vector3 quadPos = quad.transform.position;
    //     Vector3 quadSize = quad.transform.localScale;
    //     Vector3 projectilePos = projectile.transform.position;
    //     Vector2 texCoords = new Vector2(
    //         (projectilePos.x - quadPos.x + quadSize.x / 2) / quadSize.x,
    //         (projectilePos.z - quadPos.z + quadSize.y / 2) / quadSize.y);

    //     // add current texture coordinates to hit point list
    //     addHitPoint(texCoords.x, texCoords.y);
    //      Debug.Log("Added hit " + texCoords.x + "," + texCoords.y);

    //     // reset timer
    //     timer = 0f;
    //     }

    // }

    public void OnArrayValueChanged(string key, float[] value)
    {
        // here we store the value into our dictionary
        if (key == "Gyroscope") {

            // Apply exponential smoothing to gyroscope value
            gyroSmoothValue = Vector3.Lerp(gyroSmoothValue, new Vector3(value[0], value[1], value[2]), gyroSensitivity);

             // Normalize gyroscope data
            float normalizedX = Mathf.Clamp01(Mathf.Abs(gyroSmoothValue.x) / 50f);
            float normalizedZ = Mathf.Clamp01(Mathf.Abs(gyroSmoothValue.z) / 50f);

            // Map gyroscope data to quad grid
            float quadWidth = quad.transform.localScale.x;
            float quadHeight = quad.transform.localScale.z;

            Vector3 quadPosition = quad.transform.position;
            float mappedX = (normalizedX * quadWidth) - (quadWidth / 2f) + quadPosition.x;
            float mappedZ = (normalizedZ * quadHeight) - (quadHeight / 2f) + quadPosition.z;

            // Update projectile position
            float newX = Mathf.Clamp(mappedX, quadPosition.x - quadWidth/2, quadPosition.x + quadWidth/2);
            float newZ = Mathf.Clamp(mappedZ, quadPosition.z - quadHeight/2, quadPosition.z + quadHeight/2);

            projectile.transform.position = new Vector3(newX, 0, newZ);
         
            
        }
    }

    // public void addHitPoint(float xp, float yp)
    // {
    // mPoints[mHitCount * 3] = xp;
    // mPoints[mHitCount * 3 + 1] = yp;
    // mPoints[mHitCount * 3 + 2] = Random.Range(1f,3f);
    // // increment hit count
    // mHitCount++;
    // mHitCount%=32;

    // mMaterial.SetFloatArray("_Hits", mPoints);
    // mMaterial.SetInt("_HitCount", mHitCount);
    
    // Debug.Log("Hit it " + mPoints[mHitCount * 3] + mPoints[mHitCount * 3 + 1]);

    
    // }


}
