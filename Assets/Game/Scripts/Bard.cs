using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bard : MonoBehaviour
{
    static int staticId = 0;
  
    [HideInInspector] public int CubeID;
    //private Dictionary<string, GameObject> tagToPrefabMap;
    public static Bard instance;
    private void Awake()
    {
        CubeID = staticId++;
        Debug.Log("ID is = "+CubeID);
    }
    void Start()
    {
        instance = this;
        //tagToPrefabMap = new Dictionary<string, GameObject>() {
        //    {"2", prefab2},
        //    {"4", prefab4},
        //    {"8", prefab8},
        //    {"16", prefab16},
        //    {"32", prefab32},
        //};
    }
    //bool isOn;
    private bool collisionProcessed = false;

    
}
//using System.Collections;
//using UnityEngine;

//public class Bard : MonoBehaviour
//{
//    public GameObject prefab2, prefab4, prefab8, prefab16, prefab32;
//    private static bool collisionProcessed = false;

//    void Update()
//    {
//        if (!collisionProcessed)
//        {
//            // Replace this ray with your own detection logic
//            Ray ray = new Ray(transform.position, transform.forward);
//            RaycastHit hit;

//            // Check for collision along the ray
//            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
//            {
//                GameObject otherObject = hit.collider.gameObject;

//                if (otherObject.CompareTag(gameObject.tag))
//                {
//                    collisionProcessed = true;

//                    string currentTag = otherObject.tag;

//                    // Your instantiation logic...
//                    InstantiateNewCube(currentTag, otherObject.transform.position);

//                    Debug.Log("Called");

//                    // Destroy the colliding objects after instantiating the new one
//                    Destroy(otherObject);
//                    Destroy(gameObject);

//                    StartCoroutine(WaitForCollisionReset());
//                }
//            }
//        }
//    }

//    void InstantiateNewCube(string tag, Vector3 position)
//    {
//        switch (tag)
//        {
//            case "2":
//                Instantiate(prefab4, position, Quaternion.identity);
//                break;
//            case "4":
//                Instantiate(prefab8, position, Quaternion.identity);
//                break;
//            // Add cases for other tags...

//            default:
//                // Invalid tag
//                break;
//        }
//    }

//    IEnumerator WaitForCollisionReset()
//    {
//        yield return new WaitForSeconds(0.5f);
//        collisionProcessed = false;
//    }
//}