using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    public GameObject prefab2, prefab4, prefab8, prefab16, prefab32, prefab64, prefab128, prefab256, prefab512, prefab1024, prefab2048, prefab4096;
    [SerializeField] GameObject parent;
    private void Start()
    {
        parent = GameObject.FindGameObjectWithTag("Spawnner");
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            if (Bard.instance.CubeID > collision.gameObject.GetComponent<Bard>().CubeID)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                string currentTag = gameObject.tag;

                // Only instantiate the new object if it is not already instantiated
                GameObject newGameObject = null;
                if (newGameObject == null)
                {
                    float randomVal = Random.Range(-20, 20);
                    Vector3 randomRotation = Vector3.one * randomVal;
                    switch (currentTag)
                    {
                        
                        case "2":
                            newGameObject = Instantiate(prefab4, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                            newGameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 350);
                            newGameObject.GetComponent<Rigidbody>().AddTorque(randomRotation);
                            break;
                        case "4":
                            newGameObject = Instantiate(prefab8, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                            newGameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 350);
                            newGameObject.GetComponent<Rigidbody>().AddTorque(randomRotation);
                            break;
                        case "8":
                            newGameObject = Instantiate(prefab16, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                            newGameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 350);
                            newGameObject.GetComponent<Rigidbody>().AddTorque(randomRotation);
                            break;
                        case "16":
                            newGameObject = Instantiate(prefab32, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                            newGameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 350);
                            newGameObject.GetComponent<Rigidbody>().AddTorque(randomRotation);
                            break;
                        case "32":
                            newGameObject = Instantiate(prefab64, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                            newGameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 350);
                            newGameObject.GetComponent<Rigidbody>().AddTorque(randomRotation);
                            break;
                        case "64":
                            newGameObject = Instantiate(prefab128, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                            newGameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 350);
                            newGameObject.GetComponent<Rigidbody>().AddTorque(randomRotation);
                            break;
                        case "128":
                            newGameObject = Instantiate(prefab256, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                            newGameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 350);
                            newGameObject.GetComponent<Rigidbody>().AddTorque(randomRotation);
                            break;
                        case "256":
                            newGameObject = Instantiate(prefab512, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                            newGameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 350);
                            newGameObject.GetComponent<Rigidbody>().AddTorque(randomRotation);
                            break;
                        case "512":
                            newGameObject = Instantiate(prefab1024, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                            newGameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 350);
                            newGameObject.GetComponent<Rigidbody>().AddTorque(randomRotation);
                            break;
                        case "1024":
                            newGameObject = Instantiate(prefab2048, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                            newGameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 350);
                            newGameObject.GetComponent<Rigidbody>().AddTorque(randomRotation);
                            break;
                        case "2048":
                            newGameObject = Instantiate(prefab4096, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                            newGameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 350);
                            newGameObject.GetComponent<Rigidbody>().AddTorque(randomRotation);
                            break;
                        case "4096":
                            Debug.Log("Game Complete");
                            break;
                        default:
                            break;
                    }
                    Debug.Log("Called");
                }
                else
                {
                    Debug.Log("Not working");
                }
            }
        }
    }
}
