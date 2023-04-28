using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
  
    // Material mMaterial;
    // MeshRenderer mMeshRenderer;

    public float gyroSensitivity = 1.5f; // Adjust this value to control gyroscope sensitivity
    private Vector3 gyroSmoothValue; 
    // public Light myLight;


    public GameObject projectile;
    public GameObject quad;

    private Vector3 lastTargetPosition;


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

    // public void OnArrayValueChanged(string key, float[] value)
    // {
    //     // here we store the value into our dictionary
    //     if (key == "Gyroscope") {

    //         // Apply exponential smoothing to gyroscope value
    //         gyroSmoothValue = Vector3.Lerp(gyroSmoothValue, new Vector3(value[0], value[1], value[2]), gyroSensitivity);

    //         Vector3 direction = new Vector3(gyroSmoothValue.x/20f, 0, gyroSmoothValue.z/20f).normalized;

    //         // Move the projectile in the direction of the gyroscope data
    //         StartCoroutine(MoveProjectile(direction));


       
    //     }
    // }

    // private IEnumerator MoveProjectile(Vector3 direction)
// {
//     float elapsedTime = 0;
//     float moveDuration = 0.1f; // adjust as needed
//     float moveDistance = 0.01f; // adjust as needed
//     Vector3 startPosition = projectile.transform.position;
//     Vector3 targetPosition = startPosition;

//     while (elapsedTime < moveDuration)
//     {
//         // Calculate the new target position based on the direction vector and the move distance
//         Vector3 newTargetPosition = targetPosition + direction * moveDistance;

//         // Clamp the new target position to the bounds of the quad
//         float quadWidth = quad.transform.localScale.x;
//         float quadHeight = quad.transform.localScale.y;
//         Vector3 quadPosition = quad.transform.position;
//         float halfQuadWidth = quadWidth / 2f;
//         float halfQuadHeight = quadHeight / 2f;
//         float clampedX = Mathf.Clamp(newTargetPosition.x, quadPosition.x - halfQuadWidth, quadPosition.x + halfQuadWidth);
//         float clampedZ = Mathf.Clamp(newTargetPosition.z, quadPosition.z - halfQuadHeight, quadPosition.z + halfQuadHeight);
//         newTargetPosition = new Vector3(clampedX, 0, clampedZ);

//         // Calculate the new position of the projectile based on the elapsed time
//         float t = elapsedTime / moveDuration;
//         Vector3 newPosition = Vector3.Lerp(startPosition, newTargetPosition, t);

//         // Update the position of the projectile
//         projectile.transform.position = newPosition;

//         // Wait for the next frame
//         yield return null;

//         // Update the elapsed time
//         elapsedTime += Time.deltaTime;

//         // Update the target position for the next iteration
//         targetPosition = newTargetPosition;
//     }

//     // Set the final position of the projectile to the target position
//     projectile.transform.position = targetPosition;
// }

// private Vector3 acceleration = Vector3.zero;
// private Vector3 velocity = Vector3.zero;
// private Vector3 displacement = Vector3.zero;
// private float timeElapsed = 0;

// public void OnArrayValueChanged(string key, float[] value)
// {
//     // here we store the value into our dictionary
//     if (key == "Accelerometer") {

//          // Store the acceleration value
//         acceleration = new Vector3(value[0], value[1], value[2]);

//         // Calculate the velocity and displacement
//         velocity += acceleration * Time.deltaTime;
//         displacement += velocity * Time.deltaTime;
//         timeElapsed += Time.deltaTime;

//         // Calculate the direction vector
//         Vector3 direction = displacement.normalized;

//         // Call the MoveProjectile function with the direction vector
//         StartCoroutine(MoveProjectile(direction));
//     }
// }

// private IEnumerator MoveProjectile(Vector3 direction)
// {
//     float elapsedTime = 0;
//     float moveDuration = 0.1f; // adjust as needed
//     float moveDistance = 0.01f; // adjust as needed
//     Vector3 startPosition = projectile.transform.position;
//     Vector3 targetPosition = startPosition;

//     while (elapsedTime < moveDuration)
//     {
//         // Calculate the new target position based on the direction vector and the move distance
//         Vector3 newTargetPosition = targetPosition + direction * moveDistance;

//         // Clamp the new target position to the bounds of the quad
//         float quadWidth = quad.transform.localScale.x;
//         float quadHeight = quad.transform.localScale.y;
//         Vector3 quadPosition = quad.transform.position;
//         float halfQuadWidth = quadWidth / 2f;
//         float halfQuadHeight = quadHeight / 2f;
//         float clampedX = Mathf.Clamp(newTargetPosition.x, quadPosition.x - halfQuadWidth, quadPosition.x + halfQuadWidth);
//         float clampedZ = Mathf.Clamp(newTargetPosition.z, quadPosition.z - halfQuadHeight, quadPosition.z + halfQuadHeight);
//         newTargetPosition = new Vector3(clampedX, 0, clampedZ);

//         // Calculate the new position of the projectile based on the elapsed time
//         float t = elapsedTime / moveDuration;
//         Vector3 newPosition = Vector3.Lerp(startPosition, newTargetPosition, t);

//         // Clamp the new position to the bounds of the quad
//         float clampedNewX = Mathf.Clamp(newPosition.x, quadPosition.x - halfQuadWidth, quadPosition.x + halfQuadWidth);
//         float clampedNewZ = Mathf.Clamp(newPosition.z, quadPosition.z - halfQuadHeight, quadPosition.z + halfQuadHeight);
//         newPosition = new Vector3(clampedNewX, 0, clampedNewZ);

//         // Update the position of the projectile
//         projectile.transform.position = newPosition;

//         // Wait for the next frame
//         yield return null;

//         // Update the elapsed time
//         elapsedTime += Time.deltaTime;

//         // Update the target position for the next iteration
//         targetPosition = newTargetPosition;
//     }

//     // Set the final position of the projectile to the target position
//     projectile.transform.position = targetPosition;
// }

float dirX;
float dirZ;
float moveSpeed = 0.5f;
float lerpSpeed = 0.2f;

public void OnArrayValueChanged(string key, float[] value)
    {
        // here we store the value into our dictionary
        if (key == "Accelerometer") {
        float halfXWidth = 1f;
        float halfZWidth = 0.5f;

        dirX = Mathf.Clamp(value[1], -1f, 1f) * moveSpeed;
        dirZ = Mathf.Clamp(value[0], -1f, 1f) * moveSpeed;
        float newXPos = Mathf.Clamp(projectile.transform.position.x + dirX, -halfXWidth, halfXWidth);
        float newZPos = Mathf.Clamp(projectile.transform.position.z + dirZ, -halfZWidth, halfZWidth);

        Vector3 targetPosition = new Vector3(newXPos, 0.5f, newZPos);
        projectile.transform.position = Vector3.Lerp(projectile.transform.position, targetPosition, lerpSpeed);

        }
    }





}
