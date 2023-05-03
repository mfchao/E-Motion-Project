using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadScript : MonoBehaviour
{
  Material mMaterial;
  MeshRenderer mMeshRenderer;

  float[] mPoints;
  int mHitCount;

  // float mDelay;
  public GameObject projectile;
  public GameObject quad;

  private float oscillationValue = 0f;
  private float colorIndex = 0f;

  private float interval = 0.2f; // interval in seconds
  private float timer = 0f;


  void Start()
  {
    // mDelay = 3;

    mMeshRenderer = GetComponent<MeshRenderer>();
    mMaterial = mMeshRenderer.material;

    mPoints = new float[200 * 3]; //32 point 

  } 

   void Update()
    {
        // increment timer
        timer += Time.deltaTime;

        oscillationValue += Time.deltaTime * 0.5f; // adjust speed as needed
        float oscillationRange = Mathf.PingPong(oscillationValue, 4f) + 1f;

        // colorIndex = Random.Range(1, 6);

        // check if interval has passed
        if (timer >= interval)
        {
      
        // calculate texture coordinates of current position
        Vector3 quadPos = quad.transform.position;
        Vector3 quadSize = quad.transform.localScale;
        Vector3 projectilePos = projectile.transform.position;
        Vector2 texCoords = new Vector2(
            (projectilePos.x - quadPos.x + quadSize.x / 2) / quadSize.x,
            (projectilePos.z - quadPos.z + quadSize.y / 2) / quadSize.y);

        // add current texture coordinates to hit point list
        addHitPoint(texCoords.x, texCoords.y, oscillationRange);
         Debug.Log("Added hit " + texCoords.x + "," + texCoords.y);

        // reset timer
        timer = 0f;
        }

        

    }

  

  // private void OnCollisionEnter(Collision collision)
  // {
  //   foreach (ContactPoint cp in collision.contacts)
  //   {
  //       Debug.Log("Contact with object " + cp.otherCollider.gameObject.name);

  //       Vector3 startOfRay = new Vector3(cp.point.x, 0.5f, cp.point.z); // set y component to 0 to fix the direction of the ray in the x-z plane
  //       Vector3 rayDir = new Vector3(0,-1, 0); 

  //       Ray ray = new Ray(startOfRay, rayDir);
  //       RaycastHit hit;

  //       bool hitIt = Physics.Raycast(ray, out hit, 10f, LayerMask.GetMask("HeatMapLayer"));

  //       if (hitIt)
  //       {
  //           Debug.Log("Hit Object " + hit.collider.gameObject.name);
  //           Debug.Log("Hit Texture coordinates = " + hit.textureCoord.x + "," + hit.textureCoord.y);
  //           addHitPoint(hit.textureCoord.x * 4 - 2, 0, cp.point.z * 4 - 2);
  //       }

  //       Destroy(cp.otherCollider.gameObject);
  //   }
  // }

  public void addHitPoint(float xp, float yp, float oscillationRange)
    {
    mPoints[mHitCount * 3] = xp;
    mPoints[mHitCount * 3 + 1] = yp;
    mPoints[mHitCount * 3 + 2] = Random.Range(1f, oscillationRange);
    // mPoints[mHitCount * 3 + 3] = colorSetNumber; 
    // increment hit count
    mHitCount++;
    mHitCount%=200;

    mMaterial.SetFloatArray("_Hits", mPoints);
    mMaterial.SetInt("_HitCount", mHitCount);
    
    Debug.Log("Hit it " + mPoints[mHitCount * 3] + mPoints[mHitCount * 3 + 1]);
    Debug.Log("Intensity " + Random.Range(1f, oscillationRange));
    // Debug.Log("color index " + colorIndex);
    
    }


}
